using TMPro;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    
    void SetScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }

    int GetScore()
    {
        return score;
    }

    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
