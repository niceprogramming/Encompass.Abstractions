using EllieMae.Encompass.BusinessObjects.Loans;
using EllieMae.Encompass.BusinessObjects.Loans.Logging;
using Encompass.Abstractions.BusinessObjects.Loans;

namespace Encompass.Abstractions.BusinessObjects.Loans
{
    public class MilestoneEventArgsWrapper : IMilestoneEventArgs
    {
        private readonly MilestoneEventArgs _milestoneEventArgs;

        public MilestoneEventArgsWrapper(MilestoneEventArgs value)
        {
            _milestoneEventArgs = value; 


        }

        public ILoan Loan => (LoanWrapper) _milestoneEventArgs.Loan;

        public MilestoneEvent MilestoneEvent => _milestoneEventArgs.MilestoneEvent;

        public static implicit operator MilestoneEventArgsWrapper(MilestoneEventArgs value) => new MilestoneEventArgsWrapper(value);
        public static implicit operator MilestoneEventArgs(MilestoneEventArgsWrapper value) => value._milestoneEventArgs;
    }
}
