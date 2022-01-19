using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Fasterflect;

namespace Encompass.Abstractions.Generator
{
    public class CodeGenerator
    {
        private HashSet<Type> _types;
        private readonly Stack<Type> _current = new Stack<Type>();
       

        private async Task Generate(Type dependency)
        {
            if (dependency.Namespace.StartsWith("EllieMae.EMLite"))
            {
                throw new InvalidOperationException(
                    "Unable to create code for types in the EllieMae.EMLite namespaces");
            }

            var test = dependency.GetConstructors(BindingFlags.Instance|BindingFlags.NonPublic);
            
            _current.Push(dependency);
            var name = dependency.Name();
            var properties =
                dependency.Properties(Flags.Public | Flags.Instance | Flags.Static | Flags.ExcludeHiddenMembers);
            var events = dependency.GetEvents();
            var methods = dependency.Methods(Flags.Public | Flags.Instance | Flags.Static | Flags.ExcludeHiddenMembers);
            Console.WriteLine(name);
            var childTypes = FindTypesInMembers(properties, events, methods);
            var usingStatements = BuildNamespaces(childTypes);
            usingStatements.Add(dependency.Namespace);
            await BuildInterface(dependency, properties, events, methods, usingStatements);

            await BuildClass(dependency, properties, events, methods, usingStatements);
            _current.Pop();
        }

        public async Task Generate(IEnumerable<Type> dependency)
        {
            _types = new HashSet<Type>(dependency);
            foreach (var type in _types)
            {
                await Generate(type);
            }
        }

        private SortedSet<string> BuildNamespaces(List<(Type type, TypeLocation location)> childTypes)
        {
            var set = new SortedSet<string>(new UsingComparer());
            //  var normal = childTypes.Where(x => !_types.Contains(x.type));

            var wrapped = childTypes.Where(x => !x.type.Namespace.Contains("EMLite")).GroupBy(x => _types.Contains(x.type));

            var normal = wrapped.FirstOrDefault(x => !x.Key);
            var specifed = wrapped.FirstOrDefault(x => x.Key);
            if (normal.Any())
            {
                foreach (var data in normal)
                {
                    set.Add(data.type.Namespace);

                }
            }

            if (specifed is null)
            {
                return set;
            }
            foreach (var data in specifed)
            {
                var name = data.type.Name();
                var childContains = set.Contains(data.type.Namespace);
                var contains = _types.Contains(data.type);
                var notCurrent = _current.Peek() != data.type;

                if (data.location == TypeLocation.MethodParameter)
                {
                    
                    set.Add(
                        $"Encompass.Abstractions.{data.type.Namespace.Split('.').Skip(2).Aggregate((current, next) => $"{current}.{next}")}");
                    continue;
                }

                if (childContains && notCurrent)
                {
                    set.Add(
                        $"I{data.type.Name()} = Encompass.Abstractions.{data.type.Namespace.Split('.').Skip(2).Aggregate((current, next) => $"{current}.{next}")}.I{data.type.Name()}");
                    set.Add(
                        $"Encompass.Abstractions.{data.type.Namespace.Split('.').Skip(2).Aggregate((current, next) => $"{current}.{next}")}");
                    continue;
                }

                if (notCurrent)
                {
                    set.Add(
                        $"Encompass.Abstractions.{data.type.Namespace.Split('.').Skip(2).Aggregate((current, next) => $"{current}.{next}")}");
                }
            }

            return set;
        }

        private List<(Type type, TypeLocation location)> FindTypesInMembers(IList<PropertyInfo> properties, EventInfo[] events,
            IList<MethodInfo> methods)
        {
            var types = new List<(Type, TypeLocation)>();

            foreach (var info in properties)
            {
                types.Add((info.PropertyType, TypeLocation.Property));
            }

            foreach (var info in events)
            {
                types.Add((info.EventHandlerType.GetMethod("Invoke").GetParameters()[1].ParameterType, TypeLocation.Event));
            }

            foreach (var info in methods)
            {
                var name = info.Name;
                if (info.Name.ToLower().Contains("wrap"))
                {
                    continue;
                }
                types.AddRange(info.GetParameters().Where(x => !x.ParameterType.Namespace.Contains("EMLite")).Select(x => (x.ParameterType, TypeLocation.MethodParameter)));
                types.Add((info.ReturnType, TypeLocation.Method)); 
            }

            return types;
        }

        private async Task BuildInterface(Type type, IList<PropertyInfo> properties, EventInfo[] events,
            IList<MethodInfo> methods, SortedSet<string> usingStatements)
        {
            var folder = type.Namespace.Split('.').Skip(2).Aggregate((current, next) => $"{current}/{next}");
            var interfaceName = $"I{type.Name}";
            var nameSpace = $"Encompass.Abstractions.{folder.Replace('/', '.')}";
            var interfaceBuilder = new StringBuilder();

            await BuildMembers(type, properties, events, methods, interfaceBuilder);


            interfaceBuilder.Insert(0, $@"{string.Join(Environment.NewLine, usingStatements.Select(x => $"using {x};"))}

namespace {nameSpace}
{{
    public interface {interfaceName}
    {{    
");
            interfaceBuilder.AppendLine($@"    }}{Environment.NewLine}}}");

            var dir = Directory.CreateDirectory($"../../../../Encompass.Abstractions/{folder}");

            //Console.WriteLine(interfaceBuilder);
            File.WriteAllText($"{dir.FullName}/{interfaceName}.cs", interfaceBuilder.ToString());
        }

        private async Task BuildClass(Type type, IList<PropertyInfo> properties, EventInfo[] events,
            IList<MethodInfo> methods, SortedSet<string> usingStatements)
        {
            var folder = type.Namespace.Split('.').Skip(2).Aggregate((current, next) => $"{current}/{next}");
            
            var className = $"{type.Name}Wrapper";
            var privateName = $"_{char.ToLower(type.Name[0]) + type.Name.Substring(1)}";
            var nameSpace = $"Encompass.Abstractions.{folder.Replace('/', '.')}";


            var classBuilder = new StringBuilder();
            var classConstructor = new StringBuilder();
            var qualify = type.Namespace.EndsWith($"{type.Name()}");
            var modifier = string.Empty;
            await BuildMembers(type, properties, events, methods, classBuilder, true, classConstructor);
            var instanceMembers = type.Members(Flags.InstancePublic);
            var privateTypeName = qualify ? $"{type.Namespace}.{type.Name()}" : type.Name();
            classBuilder.Insert(0, $@"{string.Join(Environment.NewLine, usingStatements.Select(x => $"using {x};"))}

namespace {nameSpace}
{{
    public class {className} : I{type.Name()}
    {{{(instanceMembers.Count == 0 ? $@"
        public {className}()
        {{
{classConstructor}                       
        }}" : $@"
        private readonly {privateTypeName} {privateName};

        public {className}({privateTypeName} value)
        {{
            {privateName} = value; 

{classConstructor}
        }}")}

");
            if (instanceMembers.Count != 0)
            {
                classBuilder.AppendLine(
                    $@"        public static implicit operator {className}({privateTypeName} value) => new {className}(value);");
                classBuilder.AppendLine(
                    $@"        public static implicit operator {privateTypeName}({className} value) => value.{privateName};");
            }

            classBuilder.AppendLine($@"    }}{Environment.NewLine}}}");

            var dir = Directory.CreateDirectory($"../../../../Encompass.Abstractions/{folder}");
            //Console.WriteLine(classBuilder);
            File.WriteAllText($"{dir.FullName}/{className}.cs", classBuilder.ToString());
            
        }

        private async Task BuildMembers(Type type, IList<PropertyInfo> properties, EventInfo[] events,
            IList<MethodInfo> methods, StringBuilder builder, bool forClass = false, StringBuilder classConstructor = null)
        {
            var privateField = $"_{char.ToLower(type.Name[0]) + type.Name.Substring(1)}";
            foreach (var info in properties)
            {
                BuildPropertyBody(info, builder, forClass, privateField);
            }

            foreach (var info in events)
            {
                await BuildEventBody(info, builder, forClass, privateField, classConstructor);
            }

            foreach (var info in methods)
            {
                var name = info.Name;
                if (info.Name.ToLower().Contains("wrap") || info.IsSpecialName ||
                    info.Name.ToLower() == "gethashcode" || info.Name.ToLower() == "equals")
                {
                    continue;
                }

                BuildMethodBody(info, builder, forClass, privateField);
            }
        }

        private void BuildMethodBody(MethodInfo info, StringBuilder bodyBuilder, bool forClass, string privateName)
        {
            if (info.DeclaringType == typeof(object))
            {
                return;
            }

            var name = info.Name;
            var access = forClass ? " public" : string.Empty;
            var modifier = string.Empty;
            var returnName = _types.Contains(info.ReturnType) ? $"I{info.ReturnType.Name()}" : info.ReturnType.Name();
            var wrapperName = _types.Contains(info.ReturnType) ? $" ({info.ReturnType.Name()}Wrapper)" : string.Empty;

            var wrapperParameters = info.ParameterSignature(_types);
            var baseParameters = info.ParameterNames(_types);

            bodyBuilder.Append($@"       {access}{modifier} {returnName} {info.Name}");

            if (forClass)
            {
                bodyBuilder.Append(
                    $"({wrapperParameters}) =>{wrapperName} {(info.IsStatic ? info.DeclaringType.Name() : privateName)}.{info.Name}");
                bodyBuilder.AppendLine($"({baseParameters});").AppendLine();
            }
            else
            {
                bodyBuilder.AppendLine($"({wrapperParameters});").AppendLine();
            }
        }

        private async Task BuildEventBody(EventInfo info, StringBuilder bodyBuilder, bool forClass, string privateName, StringBuilder classConstructor)
        {
            var access = forClass ? " public" : string.Empty;
            var returnName = _types.Contains(info.EventHandlerType)
                ? $"{info.EventHandlerType.Name()}Wrapper"
                : info.EventHandlerType.Name();
            var useableName = info.AddMethod.IsStatic() ? info.DeclaringType.Name() : privateName;
            var map = info.EventHandlerType.Method("Invoke").GetParameters()[1].ParameterType;
            var genericParameter =
                map.Namespace.Contains("System") ? map.Name() : $"I{map.Name()}";
            var constuctorName = info.AddMethod.IsStatic() ? info.DeclaringType.Name() : "value";
            bodyBuilder.AppendLine($@"       {access} event EventHandler<{genericParameter}> {info.Name};");

            if (forClass)
            {
                if (!map.Namespace.Contains("System"))
                {
                    await Generate(map);
                }
                bodyBuilder.AppendLine($@"        private void on{info.Name}(object source, {map.Name()} e)
        {{  
            try
            {{      
                {info.Name}?.Invoke(source, ({(map.Namespace.Contains("System") ? map.Name() : $"{map.Name()}Wrapper")}) e);
            }}
            catch(Exception exception)
            {{
            }}
        }}");

                classConstructor.AppendLine($@"           {constuctorName}.{info.Name} += on{info.Name};");
            }

            bodyBuilder.AppendLine();
        }

        private void BuildPropertyBody(PropertyInfo info, StringBuilder bodyBuilder, bool forClass,
            string proxyPropertyName)
        {
            var test = info.Name;
            var access = forClass ? " public" : string.Empty;
            var wrapperName = _types.Contains(info.PropertyType)
                ? $" ({info.PropertyType.Name()}Wrapper)"
                : string.Empty;

            var name = _types.Contains(info.PropertyType)
                ? $"I{info.PropertyType.Name()}"
                : info.PropertyType.Name();

            var indexer = false;

            if (info.GetIndexParameters().Length > 0)
            {
                indexer = true;
                bodyBuilder.Append($"       {access} {name} this[string id]");
            }
            else
            {
                bodyBuilder.Append($"       {access} {name} {info.Name}");
            }

            var useableName = info.IsStatic() ? info.DeclaringType.Name() : proxyPropertyName;
            if (forClass)
            {
                if (info.CanWrite)
                {
                    bodyBuilder.AppendLine($@"
        {{
            get => {useableName}.{info.Name};
            set => {useableName}.{info.Name} = value;
        }}"
                    );
                }
                else if (!indexer)
                {
                    bodyBuilder.AppendLine($@" =>{wrapperName} {useableName}.{info.Name};");
                }
                else
                {
                    bodyBuilder.AppendLine($@" =>{wrapperName} {useableName}[id];");
                }
            }
            else
            {
                bodyBuilder.AppendLine(info.CanWrite ? @" { get; set; }" : @" { get; }");
            }

            bodyBuilder.AppendLine();
        }
    }
}