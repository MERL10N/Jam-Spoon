using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.InputSystem;

public class OrderManager : MonoBehaviour
{
    public Player Player;
    public GameObject SendButton;
    public GameObject TopLeft;
    public GameObject TopRight;
    public GameObject BottomLeft;
    public GameObject BottomRight;
    public Dictionary<string, int> Order;
    public GameObject Tray;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        //Player = GameObject.Find("player").GetComponent<Player>();
        Tray = GameObject.Find("tray");
        TopLeft = GameObject.Find("TopLeft");
        TopRight = GameObject.Find("TopRight");
        BottomLeft = GameObject.Find("BottomLeft");
        BottomRight = GameObject.Find("BottomRight");
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
    void CheckOrder()
    {
        Dictionary<string, int> CorrectOrder = Player.Order;
        Dictionary<string, Dictionary<string, int>> SpecialRequest = Player.Request;
        //dictionary1.Should().Equal(dictionary2);
        Debug.Log(Equals(Order, CorrectOrder));
    }

    private bool Equals(Dictionary<string, int> x, Dictionary<string, int> y)
    {
        // Check whether the dictionaries are equal
        return x.Count == y.Count && !x.Except(y).Any();
    }
}
