using EllieMae.Encompass.BusinessObjects.Loans;
using EllieMae.Encompass.BusinessObjects.Loans.Logging;
using Encompass.Abstractions.BusinessObjects.Loans;

namespace Encompass.Abstractions.BusinessObjects.Loans
{
    public interface ILogEntryEventArgs
    {    
        ILoan Loan { get; }

        LogEntry LogEntry { get; }

    }
}
