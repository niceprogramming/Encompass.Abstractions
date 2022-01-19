using System;
using EllieMae.Encompass.BusinessObjects.Loans;
using EllieMae.Encompass.BusinessObjects.Loans.Logging;
using Encompass.Abstractions.BusinessObjects.Loans;

namespace Encompass.Abstractions.BusinessObjects.Loans
{
    public interface ICancelableMilestoneEventArgs
    {    
        bool Cancel { get; set; }

        ILoan Loan { get; }

        MilestoneEvent MilestoneEvent { get; }

    }
}
