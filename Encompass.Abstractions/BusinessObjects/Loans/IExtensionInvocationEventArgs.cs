using System;
using EllieMae.Encompass.BusinessObjects.Loans;

namespace Encompass.Abstractions.BusinessObjects.Loans
{
    public interface IExtensionInvocationEventArgs
    {    
        Type Target { get; set; }

        ExtensionInvocationType InvocationType { get; set; }

        TimeSpan? Elapsed { get; set; }

    }
}
