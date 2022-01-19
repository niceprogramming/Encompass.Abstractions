using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encompass.Abstractions.Generator
{
    public class TypeEqualityComparer : IEqualityComparer<Type>
    {

        public bool Equals(Type x, Type y)
        {
            return x.Name == y.Name && x.Namespace == y.Namespace;
        }

        public int GetHashCode(Type obj)
        {
            var code = obj.Name.GetHashCode() ^ obj.Namespace.GetHashCode();
            return code.GetHashCode();
        }


    }

    public class TypeComparer : IComparer<Type>
    {
        private HashSet<Type> types;

        public TypeComparer(HashSet<Type> types)
        {
            this.types = types;
        }

        public int Compare(Type x, Type y)
        {
            if (types.Contains(x) && types.Contains(y))
            {
                return x.Name.CompareTo(y.Name);
            }

            if (types.Contains(x))
            {
                return 1;
            }

            if (types.Contains(y))
            {
                return -1;
            }

            return x.Name.CompareTo(y.Name);
        }

       


    }
}
