using UnityEngine;
using Mirror;

public class GameNetworkManager : NetworkManager
{
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);

        Debug.Log($"����� ���������. ����� �������: {numPlayers}");

        if (numPlayers == 2)
        {
            Debug.Log("��� ������ ����������. �������� ����.");
            ServerChangeScene("Game");
        }
    }
}