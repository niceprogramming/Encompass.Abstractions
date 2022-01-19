using EllieMae.Encompass.Client;

namespace Encompass.Abstractions.Client
{
    public class DisconnectedEventArgsWrapper : IDisconnectedEventArgs
    {
        private readonly DisconnectedEventArgs _disconnectedEventArgs;

        public DisconnectedEventArgsWrapper(DisconnectedEventArgs value)
        {
            _disconnectedEventArgs = value; 


        }

        public DisconnectReason Reason => _disconnectedEventArgs.Reason;

        public static implicit operator DisconnectedEventArgsWrapper(DisconnectedEventArgs value) => new DisconnectedEventArgsWrapper(value);
        public static implicit operator DisconnectedEventArgs(DisconnectedEventArgsWrapper value) => value._disconnectedEventArgs;
    }
}
