using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public Dictionary<string, Dictionary<string, int>> Request;
    public Dictionary<string, int> Order;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        Order = new Dictionary<string, int>();
        Order.Add("ice cream", 2);
        Order.Add("fry", 1);

        Request = new Dictionary<string, Dictionary<string, int>>();
        Request.Add("TopLeft", Order);
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
