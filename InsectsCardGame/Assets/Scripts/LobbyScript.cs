using UnityEngine;
using Mirror;

public class LobbyScript : MonoBehaviour
{
    public void Disconnect() => NetworkManager.singleton.StopClient();
}