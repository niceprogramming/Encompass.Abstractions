using System;
using EllieMae.Encompass.BusinessObjects.Loans;
using Encompass.Abstractions.BusinessObjects.Loans;

namespace Encompass.Abstractions.BusinessObjects.Loans
{
    public class FieldChangeEventArgsWrapper : IFieldChangeEventArgs
    {
        private readonly FieldChangeEventArgs _fieldChangeEventArgs;

        public FieldChangeEventArgsWrapper(FieldChangeEventArgs value)
        {
            _fieldChangeEventArgs = value; 


        }

        public string FieldID => _fieldChangeEventArgs.FieldID;

        public IBorrowerPair BorrowerPair => (BorrowerPairWrapper) _fieldChangeEventArgs.BorrowerPair;

        public string PriorValue => _fieldChangeEventArgs.PriorValue;

        public string NewValue => _fieldChangeEventArgs.NewValue;

        public static implicit operator FieldChangeEventArgsWrapper(FieldChangeEventArgs value) => new FieldChangeEventArgsWrapper(value);
        public static implicit operator FieldChangeEventArgs(FieldChangeEventArgsWrapper value) => value._fieldChangeEventArgs;
    }
}
