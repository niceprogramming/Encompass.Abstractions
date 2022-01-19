using System;
using EllieMae.Encompass.BusinessObjects.Loans;
using EllieMae.Encompass.Client;

namespace Encompass.Abstractions.BusinessObjects.Loans
{
    public class FieldDescriptorWrapper : IFieldDescriptor
    {
        private readonly FieldDescriptor _fieldDescriptor;

        public FieldDescriptorWrapper(FieldDescriptor value)
        {
            _fieldDescriptor = value; 


        }

        public string FieldID => _fieldDescriptor.FieldID;

        public LoanFieldFormat Format => _fieldDescriptor.Format;

        public string Description => _fieldDescriptor.Description;

        public FieldOptions Options => _fieldDescriptor.Options;

        public int MaxLength => _fieldDescriptor.MaxLength;

        public bool ReadOnly => _fieldDescriptor.ReadOnly;

        public bool RequiresExclusiveLock => _fieldDescriptor.RequiresExclusiveLock;

        public bool MultiInstance => _fieldDescriptor.MultiInstance;

        public MultiInstanceSpecifierType InstanceSpecifierType => _fieldDescriptor.InstanceSpecifierType;

        public bool IsBorrowerPairSpecific => _fieldDescriptor.IsBorrowerPairSpecific;

        public object InstanceSpecifier => _fieldDescriptor.InstanceSpecifier;

        public bool IsInstance => _fieldDescriptor.IsInstance;

        public IFieldDescriptor ParentDescriptor => (FieldDescriptorWrapper) _fieldDescriptor.ParentDescriptor;

        public bool IsCustomField => _fieldDescriptor.IsCustomField;

        public bool IsVirtualField => _fieldDescriptor.IsVirtualField;

        public bool IsNumeric() => _fieldDescriptor.IsNumeric();

        public bool IsDateValued() => _fieldDescriptor.IsDateValued();

        public string GetFieldInstanceID(object instanceIndexOrSpecifier) => _fieldDescriptor.GetFieldInstanceID(instanceIndexOrSpecifier);

        public IFieldDescriptor GetInstanceDescriptor(object instanceIndexOrSpecifier) => (FieldDescriptorWrapper) _fieldDescriptor.GetInstanceDescriptor(instanceIndexOrSpecifier);

        public bool AppliesToEdition(EncompassEdition edition) => _fieldDescriptor.AppliesToEdition(edition);

        public string ToString() => _fieldDescriptor.ToString();

        public int CompareTo(object obj) => _fieldDescriptor.CompareTo(obj);

        public string FormatValue(string value) => _fieldDescriptor.FormatValue(value);

        public string UnformatValue(string value) => _fieldDescriptor.UnformatValue(value);

        public object ConvertToNativeType(string value) => _fieldDescriptor.ConvertToNativeType(value);

        public string ValidateInput(string value) => _fieldDescriptor.ValidateInput(value);

        public IFieldDescriptor CreateUndefined(string fieldId) => (FieldDescriptorWrapper) FieldDescriptor.CreateUndefined(fieldId);

        public static implicit operator FieldDescriptorWrapper(FieldDescriptor value) => new FieldDescriptorWrapper(value);
        public static implicit operator FieldDescriptor(FieldDescriptorWrapper value) => value._fieldDescriptor;
    }
}
