using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]
    private GameObject go_caught;
    [SerializeField]
    private GameObject go_escaped;
    [SerializeField]
    private GameObject go_leaderboardlocked;
    [SerializeField]
    private GameObject go_leaderboard;

    private GameUI gameUI;
    private RuntimeDBManager runtimeDBManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(gameUI == null)
        {
            gameUI = GameUI.Instance;
        }

        if(runtimeDBManager == null)
        {
            runtimeDBManager = RuntimeDBManager.Instance;
        }
    }

    private void OnEnable()
    {
        if (gameUI == null)
        {
            gameUI = GameUI.Instance;
        }
        if (runtimeDBManager == null)
        {
            runtimeDBManager = RuntimeDBManager.Instance;
        }

        if (runtimeDBManager.GetWon())
        {
            go_escaped.SetActive(false);
            go_caught.SetActive(true);
        }
        else
        {
            go_caught.SetActive(true);
            go_escaped.SetActive(false) ;
        }
        if (runtimeDBManager.GetIsLeaderboardLocked())
        {
            go_leaderboard.SetActive(false);
            go_leaderboardlocked.SetActive(true);
        }
        else
        {
            go_leaderboard.SetActive(true);
            go_leaderboardlocked.SetActive(false);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnRetry()
    {
        gameUI.UpdateGameState(GameManager.GameState.Retry);
    }

    public void OnLeaderboard()
    {
        gameUI.ShowLeaderboard();
    }

    public void OnMenu()
    {
        gameUI.UpdateGameState(GameManager.GameState.Menu);
    }
}
