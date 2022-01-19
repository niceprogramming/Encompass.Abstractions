using System;
using EllieMae.Encompass.BusinessObjects.Loans;
using EllieMae.Encompass.BusinessObjects.Loans.Logging;
using Encompass.Abstractions.BusinessObjects.Loans;

namespace Encompass.Abstractions.BusinessObjects.Loans
{
    public class CancelableMilestoneEventArgsWrapper : ICancelableMilestoneEventArgs
    {
        private readonly CancelableMilestoneEventArgs _cancelableMilestoneEventArgs;

        public CancelableMilestoneEventArgsWrapper(CancelableMilestoneEventArgs value)
        {
            _cancelableMilestoneEventArgs = value; 


        }

        public bool Cancel
        {
            get => _cancelableMilestoneEventArgs.Cancel;
            set => _cancelableMilestoneEventArgs.Cancel = value;
        }

        public ILoan Loan => (LoanWrapper) _cancelableMilestoneEventArgs.Loan;

        public MilestoneEvent MilestoneEvent => _cancelableMilestoneEventArgs.MilestoneEvent;

        public static implicit operator CancelableMilestoneEventArgsWrapper(CancelableMilestoneEventArgs value) => new CancelableMilestoneEventArgsWrapper(value);
        public static implicit operator CancelableMilestoneEventArgs(CancelableMilestoneEventArgsWrapper value) => value._cancelableMilestoneEventArgs;
    }
}
