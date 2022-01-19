using System;
using EllieMae.Encompass.Client;

namespace Encompass.Abstractions.Client
{
    public class ServerMessageEventArgsWrapper : IServerMessageEventArgs
    {
        private readonly ServerMessageEventArgs _serverMessageEventArgs;

        public ServerMessageEventArgsWrapper(ServerMessageEventArgs value)
        {
            _serverMessageEventArgs = value; 


        }

        public string Source => _serverMessageEventArgs.Source;

        public string Text => _serverMessageEventArgs.Text;

        public string ToString() => _serverMessageEventArgs.ToString();

        public static implicit operator ServerMessageEventArgsWrapper(ServerMessageEventArgs value) => new ServerMessageEventArgsWrapper(value);
        public static implicit operator ServerMessageEventArgs(ServerMessageEventArgsWrapper value) => value._serverMessageEventArgs;
    }
}
