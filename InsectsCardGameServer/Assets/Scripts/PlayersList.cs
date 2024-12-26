using Mirror;

public class PlayersList : NetworkBehaviour
{
    public static PlayersList Instance { get; private set; }

    private readonly SyncList<int> _playerList = new SyncList<int>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void AddPlayerInList(int playerId)
    {
        _playerList.Add(playerId);
    }

    public void RemovePlayerFromList(int playerId)
    {
        _playerList.Remove(playerId);
    }

    public int CountPlayersInList()
    {
        return _playerList.Count;
    }
}