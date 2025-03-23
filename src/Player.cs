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

// Put it in your backpack. 
// Inspect returned values. 
// If the item doesn't fit your backpack, put it back in the chest. 
// Communicate to the user what's happening. 
// Return true/false for success/failure 
return false; 
} 
public bool DropToChest(string itemName) 
{ 
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
    public void Move()
    {
        Damage(5); // Decrease health by a fixed amount each time the player moves
    }
}