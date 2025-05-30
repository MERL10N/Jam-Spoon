using System.Collections.Generic;
using UnityEngine;

public class TrayOrder : MonoBehaviour
{
    public Dictionary<string, int> Order;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private void Awake()
    {
        Order = new Dictionary<string, int>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "SendButton")
        {
            Debug.Log(collision.gameObject.tag + " on tray");
            if (!Order.ContainsKey(collision.gameObject.tag))
            {
                Order.Add(collision.gameObject.tag, 1);
            }
            else
            {
                Order[collision.gameObject.tag] += 1;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag + " off tray");
        if (Order.ContainsKey(collision.gameObject.tag))
        {
            Order[collision.gameObject.tag] -= 1;
        }

        if (Order[collision.gameObject.tag] <= 0)
        {
            Order.Remove(collision.gameObject.tag);
        }
    }
}
