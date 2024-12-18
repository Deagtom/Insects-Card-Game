using UnityEngine;
using Mirror;

public class GameNetworkManager : NetworkManager
{
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);

        Debug.Log($"Игрок подключен. Всего игроков: {numPlayers}");

        if (numPlayers == 2)
        {
            Debug.Log("Два игрока подключены. Начинаем игру.");
            ServerChangeScene("Game");
        }
    }
}