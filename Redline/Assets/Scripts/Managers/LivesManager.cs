using UnityEngine;

public class LivesManager : MonoBehaviour
{
    public static LivesManager Instance;

    [SerializeField]
    private int numberLives = 6;

    private GameUI gameUI;
    private RuntimeDBManager runtimeDBManager;
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
        gameUI = GameUI.Instance;
        runtimeDBManager = RuntimeDBManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveLife()
    {
        numberLives --;
         //Update UI
        if(numberLives < 0)
        {
            runtimeDBManager.SetWon(false);
            gameUI.UpdateGameState(GameManager.GameState.Over);
        }
        gameUI.UpdateLives();
    }



}
