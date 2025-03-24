class Inventory
{
    private int maxWeight;
    private Dictionary<string, Item> items;
    public Inventory(int maxWeight)
    {
        this.maxWeight = maxWeight;
        this.items = new Dictionary<string, Item>();
    }
    // methods 
    public string ShowItems()
    {
        string s = "";
        s += "You see the following items:\n";
        foreach (var itemName in items.Keys)
        {
            Item i = items[itemName];
            s += "- " + itemName + " : " + i.Description + "\n";
        }
        return s;
    }
    public string ShowBackpackItems()
    {
        string s2 = "";
        s2 += "Orhan\n";
        foreach (var itemName in this.items.Keys)
        {
            s2 += itemName;
        }
        return s2;
    }

    public bool Put(string itemName, Item item)
    {
        int freeWeight = FreeWeight();
        // Check the Weight of the Item and check for enough space in the Inventory 
        // Does the Item fit? 
        if (item.Weight > FreeWeight())
        {
            Console.WriteLine($"The {itemName} is too heavy to fit in your inventory.");
            return false;
        }
        // Console.WriteLine(itemName + " is added to the inventory. You still have " + freeWeight + " capacity in your inventory}");
        // Put Item in the items Dictionary 
        items.Add(itemName, item);
        // Return true/false for success/failure 
        return true;
    }
    public Item Get(string itemName)
    {
        if (items.TryGetValue(itemName, out Item item))
        {
            items.Remove(itemName);
            return item;
        }
        // Find Item in items Dictionary 
        // remove Item from items Dictionary if found 
        // return Item or null 
        return null;
    }

    public int TotalWeight()
    {
        // loop through the items, and add all the weights
        int total = 0;
        foreach (Item i in items.Values)
        {
            total += i.Weight;
        }
        // loop through the items, and add all the weights 
        return total;
    }
    public int FreeWeight()
    {
        // compare MaxWeight and TotalWeight() 
        return maxWeight - TotalWeight();
    }
}