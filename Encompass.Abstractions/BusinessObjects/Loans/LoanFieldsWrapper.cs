using System;
using EllieMae.Encompass.BusinessObjects.Loans;
using Encompass.Abstractions.BusinessObjects.Loans;

namespace Encompass.Abstractions.BusinessObjects.Loans
{
    public class LoanFieldsWrapper : ILoanFields
    {
        private readonly LoanFields _loanFields;

        public LoanFieldsWrapper(LoanFields value)
        {
            _loanFields = value; 


        }

        public ILoanField this[string id] => (LoanFieldWrapper) _loanFields[id];

        public ILoanField GetFieldAt(string fieldId, int itemIndex) => (LoanFieldWrapper) _loanFields.GetFieldAt(fieldId, itemIndex);

        public static implicit operator LoanFieldsWrapper(LoanFields value) => new LoanFieldsWrapper(value);
        public static implicit operator LoanFields(LoanFieldsWrapper value) => value._loanFields;
    }
}
