using System;
using EllieMae.Encompass.BusinessObjects.Loans;
using EllieMae.Encompass.Client;

namespace Encompass.Abstractions.BusinessObjects.Loans
{
    public interface IFieldDescriptor
    {    
        string FieldID { get; }

        LoanFieldFormat Format { get; }

        string Description { get; }

        FieldOptions Options { get; }

        int MaxLength { get; }

        bool ReadOnly { get; }

        bool RequiresExclusiveLock { get; }

        bool MultiInstance { get; }

        MultiInstanceSpecifierType InstanceSpecifierType { get; }

        bool IsBorrowerPairSpecific { get; }

        object InstanceSpecifier { get; }

        bool IsInstance { get; }

        IFieldDescriptor ParentDescriptor { get; }

        bool IsCustomField { get; }

        bool IsVirtualField { get; }

        bool IsNumeric();

        bool IsDateValued();

        string GetFieldInstanceID(object instanceIndexOrSpecifier);

        IFieldDescriptor GetInstanceDescriptor(object instanceIndexOrSpecifier);

        bool AppliesToEdition(EncompassEdition edition);

        string ToString();

        int CompareTo(object obj);

        string FormatValue(string value);

        string UnformatValue(string value);

        object ConvertToNativeType(string value);

        string ValidateInput(string value);

        IFieldDescriptor CreateUndefined(string fieldId);

    }
}
