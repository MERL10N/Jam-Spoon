using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    [SerializeField]
    Button playButton;
    void Start()
    {
       playButton.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        SceneLoader.instance.LoadScene(SceneLoader.Scene.Gameplay);
    }
}
