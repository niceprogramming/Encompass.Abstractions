using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EllieMae.Encompass.BusinessObjects.Loans;
using IBorrowerPair = Encompass.Abstractions.BusinessObjects.Loans.IBorrowerPair;
using IFieldDescriptor = Encompass.Abstractions.BusinessObjects.Loans.IFieldDescriptor;
using ILoanField = Encompass.Abstractions.BusinessObjects.Loans.ILoanField;

namespace Encompass.Abstractions.Sample.Tests
{
    //might just wanna create a bunch of testing helpers for all the types
    public class FakeLoanField : ILoanField
    {
        private object _value;

        public FakeLoanField(string id, string value)
        {
            _value = value;
            ID = id;
        }
        public string UnformattedValue => Value.ToString();
        public string OriginalValue => Value.ToString();
        public bool Locked { get; set; }
        public bool ReadOnly { get; }
        public string ID { get; }
        public LoanFieldFormat Format { get; }
        public string FormattedValue { get; }

        public object Value
        {
            get => _value;
            set => _value = value;
        }
        public IFieldDescriptor Descriptor { get; }
        public string GetValueForBorrowerPair(IBorrowerPair pair)
        {
            throw new NotImplementedException();
        }

        public void SetValueForBorrowerPair(IBorrowerPair pair, string value)
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty() => string.IsNullOrWhiteSpace(UnformattedValue);

        public int ToInt()
        {
            throw new NotImplementedException();
        }

        public decimal ToDecimal()
        {
            throw new NotImplementedException();
        }

        public DateTime ToDate()
        {
            throw new NotImplementedException();
        }

        public override string ToString() => UnformattedValue;
    }
}
