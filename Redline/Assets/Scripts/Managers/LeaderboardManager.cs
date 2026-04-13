using UnityEngine;
using Unity.Services.Authentication;
using Unity.Services.Leaderboards;
using Unity.Services.Core;
using Unity.Services.Leaderboards.Models;

public class LeaderboardManager : MonoBehaviour
{
    public const string LEADERBOARD_ID = "Time_To_Escape";
    private GameUI gameUI;
    private RuntimeDBManager runtimeDBManager;

    private async void Awake()
    {
        await UnityServices.InitializeAsync();

        if (!AuthenticationService.Instance.IsSignedIn)
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
        }
    }
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void UpdateScoreInLeaderboard(string playername, int time)
    {
        await LeaderboardsService.Instance.AddPlayerScoreAsync(LEADERBOARD_ID, time);
    }

    public async void GetMyScore()
    {
       LeaderboardEntry myentry = await LeaderboardsService.Instance.GetPlayerScoreAsync(LEADERBOARD_ID);

        string rank = myentry.Rank.ToString();
        string playername = runtimeDBManager.GetPlayerName();
        string score = myentry.Score.ToString();

        gameUI.UpdateMyScore(rank, playername, score);
    }

    public async void GetTop3Scores()
    {
      LeaderboardScoresPage scores =  await LeaderboardsService.Instance.GetScoresAsync(LEADERBOARD_ID, new GetScoresOptions()
        {
            Limit = 3
        });

        int i = 0;
        foreach(LeaderboardEntry entry in scores.Results)
        {
            string rank = entry.Rank.ToString();
            string playername = entry.PlayerName.ToString();
            string score = entry.Score.ToString();
            gameUI.UpdateOneScore(i, rank, playername, score);
            i++;

        }
    }
}
