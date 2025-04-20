using UnityEngine;

public class GameScene : MonoBehaviour
{
    [SerializeField]
    AudioClip menuMusic;
    [SerializeField]
    AudioSource musicSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        AudioManager.instance.PlayMusic(menuMusic, musicSource);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
