using UnityEngine;

public class DoorController : MonoBehaviour
{
    private GameManager gameManager;
    private RuntimeDBManager runtimeDBManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameManager.Instance;
        runtimeDBManager = RuntimeDBManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(gameManager.GetRound() < 3)
            {
                gameManager.UpdateRound();
            }
            else
            {
                runtimeDBManager.SetWon(true);
                gameManager.UpdateState(GameManager.GameState.Over);
            }
        }
    }
}
