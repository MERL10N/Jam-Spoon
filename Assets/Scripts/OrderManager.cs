using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.InputSystem;

public class OrderManager : MonoBehaviour
{
    public Player Player;
    public GameObject SendButton;
    public Dictionary<string, int> Order;
    public GameObject Tray;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        //Player = GameObject.Find("player").GetComponent<Player>();
        Tray = GameObject.Find("tray");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetOrder();
            CheckOrder();
        }
    }

    void GetOrder()
    {
        Order = Tray.GetComponent<TrayOrder>().Order;
    }
    bool CheckOrder()
    {
        Dictionary<string, int> CorrectOrder = Player.Order;
        return Equals(Order, CorrectOrder);
    }

    private bool Equals(Dictionary<string, int> x, Dictionary<string, int> y)
    {
        // Check whether the dictionaries are equal
        return x.Count == y.Count && !x.Except(y).Any();
    }
}
