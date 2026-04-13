using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField]
    private AudioSource as_background;
    [SerializeField]
    private AudioSource as_gameSounds;
    [SerializeField]
    private AudioSource as_uiSounds;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGameSound(AudioClip clip)
    {
        as_gameSounds.PlayOneShot(clip);
    }

    public void PlaySFXSound(AudioClip clip)
    {
        as_uiSounds.PlayOneShot(clip);
    }

    public void UpdateMusicVolume(float volume)
    {
        as_background.volume = volume;
        as_gameSounds.volume = volume;
    }

    public void UpdateSFXVolume(float volume)
    {
        as_uiSounds.volume = volume;
    }
}
