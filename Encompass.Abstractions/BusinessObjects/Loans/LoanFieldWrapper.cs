using System;
using EllieMae.Encompass.BusinessObjects.Loans;
using Encompass.Abstractions.BusinessObjects.Loans;
using IFieldDescriptor = Encompass.Abstractions.BusinessObjects.Loans.IFieldDescriptor;

namespace Encompass.Abstractions.BusinessObjects.Loans
{
    public class LoanFieldWrapper : ILoanField
    {
        private readonly LoanField _loanField;

        public LoanFieldWrapper(LoanField value)
        {
            _loanField = value; 


        }

        public string UnformattedValue => _loanField.UnformattedValue;

        public string OriginalValue => _loanField.OriginalValue;

        public bool Locked
        {
            get => _loanField.Locked;
            set => _loanField.Locked = value;
        }

        public bool ReadOnly => _loanField.ReadOnly;

        public string ID => _loanField.ID;

        public LoanFieldFormat Format => _loanField.Format;

        public string FormattedValue => _loanField.FormattedValue;

        public object Value
        {
            get => _loanField.Value;
            set => _loanField.Value = value;
        }

        public IFieldDescriptor Descriptor => (FieldDescriptorWrapper) _loanField.Descriptor;

        public string GetValueForBorrowerPair(IBorrowerPair pair) => _loanField.GetValueForBorrowerPair((BorrowerPairWrapper) pair);

        public void SetValueForBorrowerPair(IBorrowerPair pair, string value) => _loanField.SetValueForBorrowerPair((BorrowerPairWrapper) pair, value);

        public bool IsEmpty() => _loanField.IsEmpty();

        public string ToString() => _loanField.ToString();

        public int ToInt() => _loanField.ToInt();

        public decimal ToDecimal() => _loanField.ToDecimal();

        public DateTime ToDate() => _loanField.ToDate();

        public static implicit operator LoanFieldWrapper(LoanField value) => new LoanFieldWrapper(value);
        public static implicit operator LoanField(LoanFieldWrapper value) => value._loanField;
    }
}
