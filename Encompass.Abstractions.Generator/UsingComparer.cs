using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encompass.Abstractions.Generator
{
    public class UsingComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x.StartsWith("System") && y.StartsWith("System"))
            {
                return x.CompareTo(y);
            }

            if (x.StartsWith("System"))
            {
                return -1;
            }

            if (y.StartsWith("System"))
            {
                return 1;
            }

            return x.CompareTo(y);
        }
    }
}
