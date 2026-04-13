using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardUI : MonoBehaviour
{
    [SerializeField]
    private List<LeaderboardCell> list_top3  = new List<LeaderboardCell>();

    [SerializeField]
    private LeaderboardCell myRank;

    private GameUI gameUI;

   // private Lea
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameUI = GameUI.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMyRank(string rank, string playername, string score)
    {
        if (myRank == null)
        {
            myRank.UpdateRank(rank, playername, score);
        }
    }

    public void UpdateOneScore(int index, string rank, string playername, string time)
    {
        list_top3[index].UpdateRank(rank,playername, time);
    }

    public void OnClose()
    {
        gameUI.HideLeaderboard();
    }
}
