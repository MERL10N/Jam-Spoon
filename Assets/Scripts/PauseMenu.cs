using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused;
    public GameObject pauseMenuUI;
    
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button quitButton;

    void Start()
    {
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
    }
    
    
    void Update()
    {
        resumeButton.onClick.AddListener(Resume);
        quitButton.onClick.AddListener(Quit);
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        AudioManager.instance.ResumeMusic();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void Pause()
    {
        if (!pauseMenuUI)
        {
            Debug.LogError("pauseMenuUI is not assigned!");
            return;
        }

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        AudioManager.instance.PauseMusic();
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
        AudioManager.instance.StopMusic();
    }
    
}
