using System;
using UnityEditor;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource MusicSource;
    public AudioSource SFX_Source;

    [Header("Audio Clips")]
    public AudioClip MenuMusic;
    public AudioClip GameMusic;
    
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
            // Works only for root GameObject
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayMusic(MenuMusic);
    }

    // Update is called once per frame
    public void PlayMusic(AudioClip MusicClip)
    {
        if (MusicSource != null && MusicClip != null)
        {
            MusicSource.clip = MusicClip;
            MusicSource.loop = true;
            MusicSource.Play();
        }
    }

    public void PlaySFX(AudioClip SoundClip)
    {
        if (SFX_Source != null && SoundClip != null)
        {
            SFX_Source.PlayOneShot(SoundClip);
        }
    }

    public void StopMusic()
    {
        if (MusicSource != null)
        {
            MusicSource.Stop();
        }
    }
}
