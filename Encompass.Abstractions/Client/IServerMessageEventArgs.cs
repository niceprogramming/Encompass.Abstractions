using System;
using EllieMae.Encompass.Client;

namespace Encompass.Abstractions.Client
{
    public interface IServerMessageEventArgs
    {    
        string Source { get; }

        string Text { get; }

        string ToString();

    }
}
