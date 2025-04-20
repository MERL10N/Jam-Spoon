using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float timer;
    [SerializeField] private TextMeshProUGUI timerText;

    private float referenceTimer;
    
    void Start()
    {
        referenceTimer = timer;
        GetComponent<TextMeshProUGUI>().color = Color.green;
    }

    public void SetTimer(float timer)
    {
        this.timer = timer;
    }

    public float GetTimer()
    {
        return timer;
    }

    // Update is called once per frame
    void Update()
    { 
        timer -= Time.deltaTime;

        if (timer < 0.5 * referenceTimer)
        {
            GetComponent<TextMeshProUGUI>().color = Color.yellow;
        }
        
        if (timer <= 0.25 * referenceTimer)
        {
            GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        
        if (timer <= 0)
        {
            timer = 0;
        }
        
        timerText.SetText("Time Left: " + timer.ToString("0"));
        
    }
}
