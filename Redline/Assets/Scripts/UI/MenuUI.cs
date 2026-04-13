using UnityEngine;

public class MenuUI : MonoBehaviour
{
    private GameUI gameUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameUI = GameUI.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayButtonClick()
    {
        gameUI.UpdateGameState(GameManager.GameState.Playing);
    }

    public void OnSettingsButtonClick()
    {
        gameUI.ShowSettings();
    }

    public void OnLeaderboardButtonClick()
    {
        gameUI.ShowLeaderboard();
    }
}
