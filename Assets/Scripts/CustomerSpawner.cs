using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> customerObjects = new List<GameObject>();
    [SerializeField] private float customerCooldownTime = 3f; // Time before a customer can return

    private GameObject currentActiveCustomer;
    private Dictionary<GameObject, float> customerLastActiveTime = new Dictionary<GameObject, float>();

    private void Start()
    {
        // Ensure all customers are initially deactivated
        foreach (GameObject customer in customerObjects)
        {
            customer.SetActive(false);
            customerLastActiveTime[customer] = -customerCooldownTime; // Initialize with negative cooldown so they're available immediately
        }

        // Activate a random customer to start
        ActivateRandomCustomer();
    }

    public void ActivateRandomCustomer()
    {
        // Check if we have any customers
        if (customerObjects.Count == 0)
        {
            Debug.LogWarning("No customer objects assigned to CustomerManager!");
            return;
        }

        // Deactivate current customer if one exists
        if (currentActiveCustomer != null)
        {
            currentActiveCustomer.SetActive(false);

            // Record when this customer was deactivated
            customerLastActiveTime[currentActiveCustomer] = Time.time;
        }

        // Find a new random customer (different from current one)
        GameObject newCustomer = GetRandomCustomer();

        // Activate the new customer
        newCustomer.SetActive(true);
        currentActiveCustomer = newCustomer;

        // Optional: Generate a new order for the customer if it has the script
        Customer customerScript = newCustomer.GetComponent<Customer>();
        if (customerScript != null)
        {
            customerScript.RegenerateOrder();
        }
    }

    private GameObject GetRandomCustomer()
    {
        // Create a list of customers that aren't the current one and haven't been seen recently
        List<GameObject> preferredCustomers = new List<GameObject>();
        List<GameObject> allAvailableCustomers = new List<GameObject>();

        float currentTime = Time.time;

        foreach (GameObject customer in customerObjects)
        {
            // Skip the current active customer
            if (customer == currentActiveCustomer)
                continue;

            // Check if this customer has been inactive long enough
            float timeSinceLastActive = currentTime - customerLastActiveTime[customer];

            // Add to preferred list if they've been away for the cooldown period
            if (timeSinceLastActive >= customerCooldownTime)
            {
                preferredCustomers.Add(customer);
            }

            // Add to backup list regardless of cooldown
            allAvailableCustomers.Add(customer);
        }

        // Use preferred customers if available
        if (preferredCustomers.Count > 0)
        {
            int randomIndex = Random.Range(0, preferredCustomers.Count);
            return preferredCustomers[randomIndex];
        }

        // If no preferred customers (everyone on cooldown), use any available customer
        if (allAvailableCustomers.Count > 0)
        {
            int randomIndex = Random.Range(0, allAvailableCustomers.Count);
            return allAvailableCustomers[randomIndex];
        }

        // If for some reason there are no other customers, reuse current one
        return currentActiveCustomer ?? customerObjects[0];
    }

    // Method to call when you want to change customers (like from a button)
    public void NextCustomer()
    {
        ActivateRandomCustomer();
    }
}