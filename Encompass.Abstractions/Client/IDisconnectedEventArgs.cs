using EllieMae.Encompass.Client;

namespace Encompass.Abstractions.Client
{
    public interface IDisconnectedEventArgs
    {    
        DisconnectReason Reason { get; }

    }
}
