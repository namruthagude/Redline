using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField]
    private Slider slider_music;
    [SerializeField]
    private Slider slider_volume;

    private GameUI gameUI;
    private AudioManager audioManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameUI = GameUI.Instance;
        audioManager = AudioManager.Instance;
        InitializeValues();
        slider_music.onValueChanged.AddListener(UpdateMusicVolume);
        slider_volume.onValueChanged.AddListener(UpdateSFXVolume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private  void InitializeValues()
    {
        slider_music.value = 1f;
        slider_volume.value = 1f;
    }

    private void UpdateMusicVolume(float volume)
    {
        audioManager.UpdateMusicVolume(volume);
    }

    private void UpdateSFXVolume(float volume)
    {
        audioManager.UpdateSFXVolume(volume);
    }

    public void OnBack()
    {
        gameUI.HideSettings();
    }
}
