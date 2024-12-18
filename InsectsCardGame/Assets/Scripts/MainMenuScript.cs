using UnityEngine;
using UnityEngine.UI;
using Mirror;
using TMPro;

public class MainMenuScript : MonoBehaviour
{
    private bool _isSearching = false;
    [SerializeField] private Button _button;

    public void OnFindGameClicked()
    {
        if (_isSearching)
            return;

        _isSearching = true;
        _button.GetComponentInChildren<TextMeshProUGUI>().text = "Поиск игры...";

        NetworkManager.singleton.StartClient();
    }

    public void QuitGame() => Application.Quit();
}