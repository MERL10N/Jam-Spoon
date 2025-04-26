using System;
using UnityEditor;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField]
    private AudioSource MusicSource;
    [SerializeField]
    private AudioSource SFX_Source;
    
    
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
    
    
    // Update is called once per frame
    public void PlayMusic(AudioClip MusicClip, AudioSource MusicSource)
    {
        this.MusicSource = MusicSource;
        
        if (MusicSource != null && MusicClip != null)
        {
            MusicSource.clip = MusicClip;
            MusicSource.loop = true;
            MusicSource.Play();
        }
    }

    public void PlaySFX(AudioClip SoundClip, AudioSource SFX_Source)
    {
        this.SFX_Source = SFX_Source;
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
