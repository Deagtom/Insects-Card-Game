using UnityEngine;
using Mirror;

public class GameNetworkManager : NetworkManager
{
    private int readyPlayers = 0;

    public void NotifyPlayerReady()
    {
        readyPlayers++;

        if (readyPlayers >= 2)
            ServerChangeScene("Game");
    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);

        Debug.Log("Новый игрок подключен. Ожидаем второго.");
    }
}