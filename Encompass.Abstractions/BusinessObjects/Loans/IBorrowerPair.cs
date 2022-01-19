using System;
using EllieMae.Encompass.BusinessObjects.Loans;
using Encompass.Abstractions.BusinessObjects.Loans;

namespace Encompass.Abstractions.BusinessObjects.Loans
{
    public interface IBorrowerPair
    {    
        Borrower Borrower { get; }

        Borrower CoBorrower { get; }

        string ToString();

    }
}
