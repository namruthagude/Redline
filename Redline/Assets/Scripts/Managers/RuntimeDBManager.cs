using UnityEngine;

public class RuntimeDBManager : MonoBehaviour
{
    public static RuntimeDBManager Instance;
    [SerializeField]
    private string PlayerName;
    [SerializeField]
    private bool IsLeaderboardLocked;
    [SerializeField]
    private bool Won;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetPlayerName()
    {
        return PlayerName;
    }

    public void SetPlayerName(string playerName)
    {
        PlayerName = playerName;
    }

    public bool GetIsLeaderboardLocked()
    {
        return IsLeaderboardLocked;
    }

    public void SetIsLeaderboardLocked(bool isLeaderboardLocked)
    {
        IsLeaderboardLocked = isLeaderboardLocked;
    }

    public void SetWon(bool won)
    {
        Won = won;
    }

    public bool GetWon()
    {
        return Won;
    }
}
