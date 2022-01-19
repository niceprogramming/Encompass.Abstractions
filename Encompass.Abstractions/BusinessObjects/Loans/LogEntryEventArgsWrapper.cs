using EllieMae.Encompass.BusinessObjects.Loans;
using EllieMae.Encompass.BusinessObjects.Loans.Logging;
using Encompass.Abstractions.BusinessObjects.Loans;

namespace Encompass.Abstractions.BusinessObjects.Loans
{
    public class LogEntryEventArgsWrapper : ILogEntryEventArgs
    {
        private readonly LogEntryEventArgs _logEntryEventArgs;

        public LogEntryEventArgsWrapper(LogEntryEventArgs value)
        {
            _logEntryEventArgs = value; 


        }

        public ILoan Loan => (LoanWrapper) _logEntryEventArgs.Loan;

        public LogEntry LogEntry => _logEntryEventArgs.LogEntry;

        public static implicit operator LogEntryEventArgsWrapper(LogEntryEventArgs value) => new LogEntryEventArgsWrapper(value);
        public static implicit operator LogEntryEventArgs(LogEntryEventArgsWrapper value) => value._logEntryEventArgs;
    }
}
