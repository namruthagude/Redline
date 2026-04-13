using TMPro;
using UnityEngine;

public class SetPlayerName : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField input_name;

    private RuntimeDBManager runtimeDBManager;
    private GameUI gameUI;
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

    public void SetName()
    {
        runtimeDBManager.SetPlayerName(input_name.text);
        
    }
}
