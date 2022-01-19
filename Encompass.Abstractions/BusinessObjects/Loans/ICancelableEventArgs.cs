using System;
using EllieMae.Encompass.BusinessObjects.Loans;
using Encompass.Abstractions.BusinessObjects.Loans;

namespace Encompass.Abstractions.BusinessObjects.Loans
{
    public interface ICancelableEventArgs
    {    
        ILoan Loan { get; }

        bool Cancel { get; set; }

    }
}
