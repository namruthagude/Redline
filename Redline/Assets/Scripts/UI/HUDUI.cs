using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDUI : MonoBehaviour
{
    [SerializeField]
    private List<Image> list_slider_lives = new List<Image>();
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

    public void UpdateLives()
    {
        list_slider_lives[0].fillAmount -= 0.5f;

        if(list_slider_lives[0].fillAmount <= 0)
        {
            list_slider_lives.RemoveAt(0);
        }
    }

    public void UpdateTime(int hours, int minutes, int seconds)
    {
        text_time.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }


}
