using System;
using EllieMae.Encompass.BusinessObjects;

namespace Encompass.Abstractions.BusinessObjects
{
    public class PersistentObjectEventArgsWrapper : IPersistentObjectEventArgs
    {
        private readonly PersistentObjectEventArgs _persistentObjectEventArgs;

        public PersistentObjectEventArgsWrapper(PersistentObjectEventArgs value)
        {
            _persistentObjectEventArgs = value; 


        }

        public string ObjectID => _persistentObjectEventArgs.ObjectID;

        public static implicit operator PersistentObjectEventArgsWrapper(PersistentObjectEventArgs value) => new PersistentObjectEventArgsWrapper(value);
        public static implicit operator PersistentObjectEventArgs(PersistentObjectEventArgsWrapper value) => value._persistentObjectEventArgs;
    }
}
