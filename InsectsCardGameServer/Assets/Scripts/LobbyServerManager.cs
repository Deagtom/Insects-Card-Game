using Mirror;
using UnityEngine;

public class ServerLobbyManager : NetworkManager
{
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        Debug.Log("Player added: " + conn.connectionId);
        Debug.Log("Remaining connections: " + NetworkServer.connections.Count);

        base.OnServerAddPlayer(conn);
    }

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        Debug.Log("Player disconnected: " + conn.connectionId);
        Debug.Log("Remaining connections: " + NetworkServer.connections.Count);

        base.OnServerDisconnect(conn);
    }
}