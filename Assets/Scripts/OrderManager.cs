using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class OrderManager : MonoBehaviour
{
    public Customer customer; // Reference to the current customer
    public GameObject sendButton;
    public GameObject tray; // Reference to the tray

    private Dictionary<string, int> playerOrder = new Dictionary<string, int>();

    private void Awake()
    {
        if (tray == null)
            tray = GameObject.Find("tray");

        if (sendButton != null)
            sendButton.SetActive(true);

        // Try to find the active customer from CustomerManager
        CustomerManager manager = FindFirstObjectByType<CustomerManager>();
        if (manager != null)
        {
            Debug.Log("made it here");
            GameObject activeCustomerGO = manager.GetCurrentCustomer();
            if (activeCustomerGO != null)
            {
                customer = activeCustomerGO.GetComponent<Customer>();
            }
        }
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SubmitOrder();
        }
    }

    public void SubmitOrder()
    {
        GetPlayerOrder();
        bool correct = CheckOrder();

        if (correct)
        {
            Debug.Log("Order is correct!");
            customer.SetSpecialResponse("Perfect! Here's your tip!");
            SceneLoader.Instance.LoadScene(SceneLoader.Scene.CustomerTest); // Reload scene on success
        }
        else
        {
            Debug.Log("Order is incorrect!");
            customer.SetSpecialResponse("Hmm... that's not quite right.");
        }
    }

    private void GetPlayerOrder()
    {
        playerOrder.Clear();

        
        playerOrder["nugget"] = 4;
        playerOrder["fries"] = 2;

        // TODO: Replace this with actual tray scanning logic when TrayController is implemented
    }

    private bool CheckOrder()
    {
        Dictionary<string, int> correctOrder = customer.GetOrder();

        if (correctOrder.Count != playerOrder.Count)
            return false;

        foreach (var item in correctOrder)
        {
            if (!playerOrder.ContainsKey(item.Key) || playerOrder[item.Key] != item.Value)
                return false;
        }

        return true;
    }
}