using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    [SerializeField]
    Button playButton;
    [SerializeField]
    AudioClip menuMusic;
    [SerializeField]
    AudioSource musicSource;
    void Start()
    { 
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        playButton.onClick.AddListener(StartGame);
        AudioManager.instance.PlayMusic(menuMusic, musicSource);
    }

    private void StartGame()
    {
        AudioManager.instance.StopMusic();
        SceneLoader.Instance.LoadScene(SceneLoader.Scene.joy);
    }
}
