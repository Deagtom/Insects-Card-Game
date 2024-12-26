using UnityEngine;
using Mirror;

public class MainMenuScript : MonoBehaviour
{
    public void OnFindGameClicked() => NetworkManager.singleton.StartClient();

    public void QuitGame() => Application.Quit();
}