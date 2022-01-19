using System;
using EllieMae.Encompass.BusinessObjects.Loans;

namespace Encompass.Abstractions.BusinessObjects.Loans
{
    public class ExtensionInvocationEventArgsWrapper : IExtensionInvocationEventArgs
    {
        private readonly ExtensionInvocationEventArgs _extensionInvocationEventArgs;

        public ExtensionInvocationEventArgsWrapper(ExtensionInvocationEventArgs value)
        {
            _extensionInvocationEventArgs = value; 


        }

        public Type Target
        {
            get => _extensionInvocationEventArgs.Target;
            set => _extensionInvocationEventArgs.Target = value;
        }

        public ExtensionInvocationType InvocationType
        {
            get => _extensionInvocationEventArgs.InvocationType;
            set => _extensionInvocationEventArgs.InvocationType = value;
        }

        public TimeSpan? Elapsed
        {
            get => _extensionInvocationEventArgs.Elapsed;
            set => _extensionInvocationEventArgs.Elapsed = value;
        }

        public static implicit operator ExtensionInvocationEventArgsWrapper(ExtensionInvocationEventArgs value) => new ExtensionInvocationEventArgsWrapper(value);
        public static implicit operator ExtensionInvocationEventArgs(ExtensionInvocationEventArgsWrapper value) => value._extensionInvocationEventArgs;
    }
}
