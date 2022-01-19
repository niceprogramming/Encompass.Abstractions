using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Fasterflect;

namespace Encompass.Abstractions.Generator
{
    public static class TypeExtensions
    {
        public static string ParameterSignature(this MethodInfo mi, IEnumerable<Type> createTypes)
        {
            var param = mi.GetParameters()
                .Select(p => $"{(p.ParameterType.IsByRef ? "ref " : string.Empty)}{(createTypes.Contains(p.ParameterType) ? $"I{p.ParameterType.Name()}" : p.ParameterType.Name().TrimEnd('&'))} {p.Name}")
                .ToArray();


            return string.Join(", ", param);
        }

        public static string ParameterNames(this MethodInfo mi, IEnumerable<Type> createdTypes)
        {
            var param = mi.GetParameters()
                .Select(p => $"{(p.ParameterType.IsByRef ? "ref " : string.Empty)}{(createdTypes.Contains(p.ParameterType) ?  $"({p.ParameterType.Name()}Wrapper) {p.Name}" : p.Name)}")
                .ToArray();


            return string.Join(", ", param);
        }

    }
}
