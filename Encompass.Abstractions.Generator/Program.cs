using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EllieMae.Encompass.Automation;
using EllieMae.Encompass.BusinessObjects.Loans;
using EllieMae.Encompass.BusinessObjects.Users;
using EllieMae.Encompass.Client;
using Fasterflect;

namespace Encompass.Abstractions.Generator
{
    class Program
    {
        public static List<Type> CreateTypes = new List<Type>();

        static async Task Main(string[] args)
        {
            var types = new List<Type>()
            {
                typeof(User),
                typeof(EncompassApplication),
                typeof(Session),
                typeof(Users),
                typeof(Macro),
                typeof(StateLicense),
                typeof(StateLicenses),
                typeof(Loan),
                typeof(LoanFields),
                typeof(LoanField),
                typeof(BorrowerPair),
                typeof(FieldDescriptor)

            };
            await new CodeGenerator().Generate(types);

        }
    }
}