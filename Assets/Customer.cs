using TMPro;
using UnityEngine;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Customer : MonoBehaviour
{
    [SerializeField] TMP_Text customerName;
    [SerializeField] TMP_Text customerOrder;
    [SerializeField] TMP_Text customerSpecialRequest;
    //[SerializeField] TMP_Text customerSpecialResponse;

    [Header("Customer Info")]
    [SerializeField] string customerFirstName;

    [Header("Order Settings")]
    [SerializeField] int maxDifferentItems = 3; // Maximum number of different food items per order

    [Header("Order Preferences")]
    [SerializeField] bool canOrderNuggets = true;
    [SerializeField] bool canOrderFries = true;
    [SerializeField] bool canOrderPopcorn = false;
    [SerializeField] bool canOrderIceCream = false;
    [SerializeField] bool canOrderHotDogs = false;
    [SerializeField] bool canOrderBuns = false;
    [SerializeField] bool canOrderSausages = false;
    [SerializeField] bool canOrderFishPopcorn = false;
    [SerializeField] bool canOrderFishAndChips = false;
    [SerializeField] bool canOrderNuggetsOnFries = false;
    [SerializeField] bool canOrderIceCreamOnFries = false;
    [SerializeField] bool canOrderDrink = true;
    [SerializeField] bool canOrderFish = false;

    [Header("Order Quantity Ranges")]
    [SerializeField] Vector2Int nuggetsRange = new Vector2Int(3, 7);
    [SerializeField] Vector2Int friesRange = new Vector2Int(1, 3);
    [SerializeField] Vector2Int popcornRange = new Vector2Int(1, 2);
    [SerializeField] Vector2Int iceCreamRange = new Vector2Int(1, 2);
    [SerializeField] Vector2Int hotDogsRange = new Vector2Int(1, 3);
    [SerializeField] Vector2Int bunsRange = new Vector2Int(1, 3);
    [SerializeField] Vector2Int sausagesRange = new Vector2Int(2, 5);
    [SerializeField] Vector2Int fishPopcornRange = new Vector2Int(3, 6);
    [SerializeField] Vector2Int fishAndChipsRange = new Vector2Int(1, 2);
    [SerializeField] Vector2Int nuggetsOnFriesRange = new Vector2Int(1, 1);
    [SerializeField] Vector2Int iceCreamOnFriesRange = new Vector2Int(1, 1);
    [SerializeField] Vector2Int drinkRange = new Vector2Int(1, 2);
    [SerializeField] Vector2Int fishRange = new Vector2Int(1, 3);

    // Strings to store the generated content
    private string nameString;
    private string orderString;
    private string specialRequestString;
    private string specialResponseString = "Thank you!";

    // Dictionary to store the actual order quantities
    private Dictionary<string, int> orderQuantities = new Dictionary<string, int>();

    private void Start()
    {
        GenerateOrder();
        UpdateUI();
    }

    public void GenerateOrder()
    {
        // Generate the name string
        nameString = $"NOW SERVING: {customerFirstName}";

        // Generate the order
        GenerateOrderQuantities();
        orderString = CreateOrderString();

        // Generate special request
        specialRequestString = GenerateSpecialRequest();
    }

    private void GenerateOrderQuantities()
    {
        orderQuantities.Clear();

        // Create a list of possible food items this customer can order
        List<FoodItemOption> possibleItems = new List<FoodItemOption>();

        if (canOrderNuggets)
            possibleItems.Add(new FoodItemOption("nugget", nuggetsRange));

        if (canOrderFries)
            possibleItems.Add(new FoodItemOption("fry", friesRange));

        if (canOrderPopcorn)
            possibleItems.Add(new FoodItemOption("popcorn", popcornRange));

        if (canOrderIceCream)
            possibleItems.Add(new FoodItemOption("ice cream", iceCreamRange));

        if (canOrderHotDogs)
            possibleItems.Add(new FoodItemOption("hot dog", hotDogsRange));

        if (canOrderBuns)
            possibleItems.Add(new FoodItemOption("bun", bunsRange));

        if (canOrderSausages)
            possibleItems.Add(new FoodItemOption("sausage", sausagesRange));

        if (canOrderFishPopcorn)
            possibleItems.Add(new FoodItemOption("fish popcorn", fishPopcornRange));

        if (canOrderFishAndChips)
            possibleItems.Add(new FoodItemOption("fish and chips", fishAndChipsRange));

        if (canOrderNuggetsOnFries)
            possibleItems.Add(new FoodItemOption("nuggets on fries", nuggetsOnFriesRange));

        if (canOrderIceCreamOnFries)
            possibleItems.Add(new FoodItemOption("ice cream on fries", iceCreamOnFriesRange));

        if (canOrderDrink)
            possibleItems.Add(new FoodItemOption("drink", drinkRange));

        if (canOrderFish)
            possibleItems.Add(new FoodItemOption("fish", fishRange));

        // Shuffle the list to randomize selection
        possibleItems = possibleItems.OrderBy(x => Random.value).ToList();

        // Determine how many different items to include (up to maximum)
        int itemCount = Mathf.Min(maxDifferentItems, possibleItems.Count);

        // Choose the first N items after shuffling
        for (int i = 0; i < itemCount; i++)
        {
            FoodItemOption item = possibleItems[i];
            int quantity = Random.Range(item.quantityRange.x, item.quantityRange.y + 1);
            orderQuantities[item.name] = quantity;
        }
    }

    private string CreateOrderString()
    {
        StringBuilder sb = new StringBuilder();
        bool isFirst = true;

        foreach (var item in orderQuantities)
        {
            // Skip items with quantity 0
            if (item.Value <= 0)
                continue;

            // Add comma between items
            if (!isFirst)
                sb.Append(", ");
            else
                isFirst = false;

            // Add the item with its quantity
            sb.Append($"{item.Value} {GetPluralForm(item.Key, item.Value)}");
        }

        // If nothing was added, give a fallback
        if (sb.Length == 0)
            sb.Append("Nothing today");

        return sb.ToString();
    }

    private string GetPluralForm(string item, int quantity)
    {
        if (quantity <= 1)
            return item;

        // Handle irregular plurals
        switch (item)
        {
            case "fry":
                return "fries";
            // Add other irregular plurals as needed
            default:
                // Regular pluralization rules
                if (item.EndsWith("s") || item.Contains("fish") || item.Contains("cream"))
                    return item;
                else
                    return item + "s";
        }
    }

    private string GenerateSpecialRequest()
    {
        // Define possible special requests
        string[] specialRequests = {
            "Please place {0} {1} in each corner",
            "Put {0} {1} in the top corners only",
            "I want {0} {1} in the bottom corners",
            "Can you arrange {0} {1} in a square?",
            "Line up {0} {1} along the edges"
        };

        // Choose a random item from the order to be in the special request
        List<string> orderedItems = new List<string>();
        foreach (var item in orderQuantities)
        {
            if (item.Value > 0)
                orderedItems.Add(item.Key);
        }

        // If no items were ordered, return empty string
        if (orderedItems.Count == 0)
            return "";

        // Pick a random item and a random request
        string randomItem = orderedItems[Random.Range(0, orderedItems.Count)];
        string requestTemplate = specialRequests[Random.Range(0, specialRequests.Length)];

        // Determine a reasonable quantity for the special request
        int quantity = 1;
        if (orderQuantities[randomItem] >= 4)
            quantity = Random.Range(1, Mathf.Min(4, orderQuantities[randomItem] / 2 + 1));

        // Format the special request
        return string.Format(requestTemplate, quantity, GetPluralForm(randomItem, quantity));
    }

    private void UpdateUI()
    {
        if (customerName != null)
            customerName.text = nameString;

        if (customerOrder != null)
            customerOrder.text = orderString;

        if (customerSpecialRequest != null)
            customerSpecialRequest.text = specialRequestString;

        //if (customerSpecialResponse != null)
            //customerSpecialResponse.text = specialResponseString;
    }

    // Call this method when you want to regenerate the order
    public void RegenerateOrder()
    {
        GenerateOrder();
        UpdateUI();
    }

    // You can call this when the order is completed successfully
    public void SetSpecialResponse(string response)
    {
        //specialResponseString = response;
        //if (customerSpecialResponse != null)
            //customerSpecialResponse.text = specialResponseString;
    }

    // Helper class to store food item options
    private class FoodItemOption
    {
        public string name;
        public Vector2Int quantityRange;

        public FoodItemOption(string name, Vector2Int quantityRange)
        {
            this.name = name;
            this.quantityRange = quantityRange;
        }
    }
}