using System;
using EllieMae.Encompass.BusinessObjects.Loans;
using Encompass.Abstractions.BusinessObjects.Loans;

namespace Encompass.Abstractions.BusinessObjects.Loans
{
    public interface ILoanFields
    {    
        ILoanField this[string id] { get; }

        ILoanField GetFieldAt(string fieldId, int itemIndex);

    }
}
