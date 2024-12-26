using Mirror;
using UnityEngine;

public class ServerLobbyManager : NetworkManager
{
    private bool _isGameStarted = false;

    public override void Awake()
    {
        EnsurePlayersListExists();
        base.Awake();
    }

    private void EnsurePlayersListExists()
    {
        if (PlayersList.Instance == null)
        {
            Debug.LogWarning("PlayersList.Instance is missing. Creating a new one.");
            GameObject playersListObj = new GameObject("PlayersList");
            playersListObj.AddComponent<PlayersList>();
        }
    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        PlayersList.Instance.AddPlayerInList(conn.connectionId);
        Debug.Log("Player added: " + conn.connectionId);
        Debug.Log("Remaining connections: " + NetworkServer.connections.Count);
        Debug.Log("Players in list: " + PlayersList.Instance.CountPlayersInList());
        
        if (!_isGameStarted && NetworkServer.connections.Count >= 2)
        {
            _isGameStarted = true;
            NetworkManager.singleton.ServerChangeScene("Game");
        }

        base.OnServerAddPlayer(conn);
    }

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        PlayersList.Instance.RemovePlayerFromList(conn.connectionId);
        Debug.Log("Player disconnected: " + conn.connectionId);
        Debug.Log("Remaining connections: " + NetworkServer.connections.Count);
        Debug.Log("Players in list: " + PlayersList.Instance.CountPlayersInList());

        base.OnServerDisconnect(conn);
    }
}