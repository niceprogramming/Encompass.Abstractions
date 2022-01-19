using System;
using EllieMae.Encompass.BusinessObjects.Loans;
using Encompass.Abstractions.BusinessObjects.Loans;

namespace Encompass.Abstractions.BusinessObjects.Loans
{
    public class BorrowerPairWrapper : IBorrowerPair
    {
        private readonly BorrowerPair _borrowerPair;

        public BorrowerPairWrapper(BorrowerPair value)
        {
            _borrowerPair = value; 


        }

        public Borrower Borrower => _borrowerPair.Borrower;

        public Borrower CoBorrower => _borrowerPair.CoBorrower;

        public string ToString() => _borrowerPair.ToString();

        public static implicit operator BorrowerPairWrapper(BorrowerPair value) => new BorrowerPairWrapper(value);
        public static implicit operator BorrowerPair(BorrowerPairWrapper value) => value._borrowerPair;
    }
}
