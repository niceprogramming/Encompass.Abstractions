using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encompass.Abstractions.BusinessObjects.Loans;

namespace Encompass.Abstractions.Sample.Tests
{
    public class FakeFieldChange : IFieldChangeEventArgs
    {
        public FakeFieldChange(string fieldId, string newValue, string priorValue = "", IBorrowerPair borrowerPair = null)
        {
            FieldID = fieldId;
            NewValue = newValue;
            PriorValue = priorValue;
            BorrowerPair = borrowerPair;
        }

        public string FieldID { get; }

        public IBorrowerPair BorrowerPair { get; }

        public string PriorValue { get; }

        public string NewValue { get; }
    }
}
