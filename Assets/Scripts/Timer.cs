using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float timer;
    
    void Start()
    {
        timer = 0.0f;
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
        if (timer <= 0)
        {
            timer = 0;
        }
    }
}
