using TMPro;
using UnityEngine;

public class LeaderboardCell : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text_rank;

    [SerializeField]
    private TMP_Text text_playername;

    [SerializeField]
    private TMP_Text text_time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateRank(string rank, string playername, string time)
    {
        text_rank.text = rank;
        text_playername.text = playername;
        text_time.text = time;
    }

   
}
