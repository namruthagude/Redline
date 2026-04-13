using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private Image slider_heatbar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FillHeatBar(1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FillHeatBar(float value)
    {
        slider_heatbar.fillAmount = value;

        if(value >= 0.75f)
        {
            slider_heatbar.color = Color.forestGreen;
        }
        else if(value >= 0.3f)
        {
            slider_heatbar.color = Color.coral;
        }
        else
        {
            slider_heatbar.color = Color.softRed;
        }
    }
}
