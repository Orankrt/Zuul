class Player
{
    private int health;
    // auto property 
    public Room CurrentRoom { get; set; }
    // constructor 
    public Player()
    {
        CurrentRoom = null;
        health = 100;
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