using System;
using EllieMae.Encompass.BusinessObjects.Loans;
using Encompass.Abstractions.BusinessObjects.Loans;
using IFieldDescriptor = Encompass.Abstractions.BusinessObjects.Loans.IFieldDescriptor;

namespace Encompass.Abstractions.BusinessObjects.Loans
{
    public interface ILoanField
    {    
        string UnformattedValue { get; }

        string OriginalValue { get; }

        bool Locked { get; set; }

        bool ReadOnly { get; }

        string ID { get; }

        LoanFieldFormat Format { get; }

        string FormattedValue { get; }

        object Value { get; set; }

        IFieldDescriptor Descriptor { get; }

        string GetValueForBorrowerPair(IBorrowerPair pair);

        void SetValueForBorrowerPair(IBorrowerPair pair, string value);

        bool IsEmpty();

        string ToString();

        int ToInt();

        decimal ToDecimal();

        DateTime ToDate();

    }
}
