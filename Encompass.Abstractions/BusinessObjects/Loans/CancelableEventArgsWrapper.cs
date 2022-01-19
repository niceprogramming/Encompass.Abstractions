using System;
using EllieMae.Encompass.BusinessObjects.Loans;
using Encompass.Abstractions.BusinessObjects.Loans;

namespace Encompass.Abstractions.BusinessObjects.Loans
{
    public class CancelableEventArgsWrapper : ICancelableEventArgs
    {
        private readonly CancelableEventArgs _cancelableEventArgs;

        public CancelableEventArgsWrapper(CancelableEventArgs value)
        {
            _cancelableEventArgs = value; 


        }

        public ILoan Loan => (LoanWrapper) _cancelableEventArgs.Loan;

        public bool Cancel
        {
            get => _cancelableEventArgs.Cancel;
            set => _cancelableEventArgs.Cancel = value;
        }

        public static implicit operator CancelableEventArgsWrapper(CancelableEventArgs value) => new CancelableEventArgsWrapper(value);
        public static implicit operator CancelableEventArgs(CancelableEventArgsWrapper value) => value._cancelableEventArgs;
    }
}
