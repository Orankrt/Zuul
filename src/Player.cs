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
    public int ShowHealth()
    {
        return health;
    }

}