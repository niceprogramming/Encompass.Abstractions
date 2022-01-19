using System;
using EllieMae.Encompass.BusinessObjects;

namespace Encompass.Abstractions.BusinessObjects
{
    public interface IPersistentObjectEventArgs
    {    
        string ObjectID { get; }

    }
}
