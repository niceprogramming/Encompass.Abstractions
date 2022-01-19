using System;
using EllieMae.Encompass.BusinessObjects.Loans;
using Encompass.Abstractions.BusinessObjects.Loans;

namespace Encompass.Abstractions.BusinessObjects.Loans
{
    public interface IFieldChangeEventArgs
    {    
        string FieldID { get; }

        IBorrowerPair BorrowerPair { get; }

        string PriorValue { get; }

        string NewValue { get; }

    }
}
