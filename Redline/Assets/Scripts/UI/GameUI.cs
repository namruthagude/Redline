using UnityEngine;
using UnityEngine.Rendering;

public class GameUI : MonoBehaviour
{
    public static GameUI Instance;
    [SerializeField]
    private HUDUI script_hud;
    [SerializeField]
    private MenuUI script_menu;
    [SerializeField]
    private SettingsUI script_settings;
    [SerializeField]
    private GameOverUI script_gameover;
    [SerializeField]
    private StoryUI script_story;
    [SerializeField]
    private PauseUI script_pause;
    [SerializeField]
    private LeaderboardUI script_leaderboard;
    [SerializeField]
    private SetPlayerName script_playername;

    private GameManager gameManager;

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
        gameManager = GameManager.Instance;
        gameManager.OnGamePlaying += GameManager_OnGamePlaying;
        gameManager.OnGameOver += GameManager_OnGameOver;
        gameManager.OnGameMenu += GameManager_OnGameMenu;
        ShowMenu();
    }

    private void GameManager_OnGameMenu()
    {
        ShowMenu();
    }

    private void GameManager_OnGameOver()
    {
        ShowGameOver();
    }

    private void GameManager_OnGamePlaying()
    {
        ShowHud();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TurnOffAllPanels()
    {
        script_hud.gameObject.SetActive(false);
        script_gameover.gameObject.SetActive(false);
        script_leaderboard.gameObject.SetActive(false);
        script_story.gameObject.SetActive(false);
        script_pause.gameObject.SetActive(false);
        script_menu.gameObject.SetActive(false);
        script_settings.gameObject.SetActive(false);
        script_playername.gameObject.SetActive(false);
    }

    public void ShowHud()
    {
        TurnOffAllPanels();
        script_hud.gameObject.SetActive(true);
    }

    public void ShowMenu()
    {
        TurnOffAllPanels();
        script_menu.gameObject.SetActive(true);
    }

    public void ShowSettings()
    {
        script_settings.gameObject.SetActive(true);
    }

    public void HideSettings()
    {
        script_settings.gameObject.SetActive(false);
    }

    public void ShowPauseUI()
    {
        script_pause.gameObject.SetActive(true );
    }

    public void HidePauseUI()
    {
        script_pause.gameObject.SetActive(false);
    }

    public void ShowLeaderboard()
    {
        script_leaderboard.gameObject.SetActive (true);
    }

    public void HideLeaderboard()
    {
        script_leaderboard.gameObject.SetActive(false);
    }

    public void ShowStory()
    {
        TurnOffAllPanels();
        script_story.gameObject.SetActive(true);
    }

    public void ShowGameOver()
    {
        TurnOffAllPanels();
        script_gameover.gameObject.SetActive(true);
    }
    public void UpdateLives()
    {
        script_hud.UpdateLives();
    }

    public void ShowPlayerName()
    {
        script_playername.gameObject.SetActive(true);
    }

    public void HidePlayerName()
    {
        script_playername.gameObject.SetActive(false);
    }

    public void UpdateGameState(GameManager.GameState gameState)
    {
        gameManager.UpdateState(gameState);
    }

    public void UpdateMyScore(string rank, string playername, string score)
    {
        script_leaderboard.UpdateMyRank(rank, playername, score);
    }

    public void UpdateOneScore(int index,string rank, string playername, string score)
    {
        script_leaderboard.UpdateOneScore(index, rank, playername, score);
    }

    public void UpdateTime(int hours, int minutes, int seconds)
    {
        script_hud.UpdateTime(hours, minutes, seconds);
    }


}
