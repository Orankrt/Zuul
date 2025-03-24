class Player
{
    private int health;
    // auto property 
    public Room CurrentRoom { get; set; }
    private Inventory backpack;
    // constructor 
    public Player()
    {
        CurrentRoom = null;
        health = 100;
        backpack = new Inventory(15);
    }

    // methods 

    public bool TakeFromChest(string itemName)
    {
        // Remove the Item from the Room 
        if (CurrentRoom.Chest != null)
        {
            Item takenItem = CurrentRoom.Chest.Get(itemName);
            if (takenItem == null)
            {
                Console.WriteLine($"There is no {takenItem} in the chest!");
                return false;
            }
            if (takenItem.Weight > backpack.FreeWeight())
            {
                Console.WriteLine("This item is too heavy for your inventory. You can't take that item.");
            }
            else
            {
                backpack.Put(itemName, takenItem);
                Console.WriteLine("You put this item in your backpack.");
                Console.WriteLine("Taken item: " + itemName);
            }
        }
        // Put it in your backpack. 
        // Inspect returned values. 
        // If the item doesn't fit your backpack, put it back in the chest. 
        // Communicate to the user what's happening. 
        // Return true/false for success/failure 
        return false;
    }
    public bool DropToChest(string itemName)
    {
        Item droppedItem = backpack.Get(itemName);
        if (droppedItem != null)
        {
            CurrentRoom.Chest.Put(itemName, droppedItem);
            Console.WriteLine("You have dropped the item.");
        }
        Console.WriteLine("You dont have the item in your backpack.");
        // Remove Item from your inventory. 
        // Add the Item to the Room 
        // Inspect returned values 
        // Communicate to the user what's happening 
        // Return true/false for success/failure 
        return false;
    }
    public void Damage(int damage)
    {
        health -= damage; // health = health - damage
        if (health <= 0)
        {
            Console.WriteLine("You have died!");
        }
    }
    public void Heal(int hp)
    {
        health += hp; // health = health + hp
        if (health > 100)
        {
            health = 100;
        }
    }
    public bool IsAlive()
    {
        return health > 0;
    }
    public string GetHealthStatus() // Shows the status
    {
        return $"Your current health is: {health}";
    }
    public string ShowBackpackItems() // Shows the items in the inventory
    {
        return backpack.ShowBackpackItems();
    }
    public void Move()
    {
        Damage(5); // Decrease health by a fixed amount each time the player moves
    }

    public void Use(Command command) //
    {
        string itemName = command.SecondWord;
        string itemName2 = command.ThirdWord;
        if (itemName == "medicineBottle")
        {
            health += 10;
        }
        if (itemName == "medKit")
        {
            health += 40;
        }
        if (itemName == "medicalBag")
        {
            health += 80;
        }
        if (itemName == "scalpel")
        {

        }
        if (itemName == "crowbar")
        {
            health -= 5;
            Console.WriteLine("While you used your crowbar, you got injured yourself.");
            Console.WriteLine("Your health is now: " + health);
            if (!IsAlive())
            {
                Console.WriteLine("You have died from your injuries while using the crowbar.");
                Environment.Exit(0); // End the game if player is dead from the crowbar
            }
            if (itemName2 == "east")
            {
                Console.WriteLine("You have opened the door with the crowbar.");
                Console.WriteLine("Congratulations! You won!");
                Environment.Exit(0); // End the game if player wins
            }
        }
        
    }
}