using System;
class Hero()
{
    private readonly int color;
    public int Color
    {
        get
        {
            return color;
        }
        init
        {
            color = value;
        }
    }
    private readonly string name;
    public string Name
    {
        get
        {
            return name;
        }
        init
        {
            name = value;
        }
    }
    internal int maxHealth;
    public int MaxHealth
    {
        get
        {
            return maxHealth;
        }
        set
        {
            maxHealth = value;
        }
    }
    private int health;
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            if (health > MaxHealth) health = MaxHealth;
        }
    }
    internal int maxForce;
    public int MaxForce
    {
        get
        {
            return maxForce;
        }
        set
        {
            maxForce = value;
        }
    }
    private int force;
    public int Force
    {
        get
        {
            return force;
        }
        set
        {
            force = value;
            if (force > MaxForce) force = MaxForce;
            if (force < 0) force = 0;
        }
    }
    public Hero(string Name, int MaxHealth, int MaxForce, int Color) : this()
    {
        this.Name = Name;
        this.MaxHealth = MaxHealth;
        this.MaxForce = MaxForce;
        this.Color = Color;
        Health = MaxHealth;
        Force = MaxForce;
    }

    public string Fight(Hero enemy)
    {
        Random rnd = new();
        int Attack = Force + rnd.Next(1, 10);
        Force -= enemy.Health / 2;
        enemy.Health -= Attack;
        string outcome = $"Герой {Name} наносит удар по врагу {enemy.Name} на {Attack} урона\n";
        if (enemy.Health <= 0)
        {
            outcome += $"Враг сокрушён!\nУровень повышен!";
            LevelUp();
        }
        if (enemy.Health > 0)
        {
            Attack = enemy.Force;
            Health -= Attack;
            outcome += $"Враг оказался сильнее! Герой {Name} получает {Attack} урона!";
        }
        return outcome;
    }
    private void LevelUp()
    {
        MaxHealth += 50;
        MaxForce += 25;
    }
    public string Heal()
    {
        if (Health == MaxHealth)
        {
            return "Здоровье достигло максимума!";
        }
        Health += Force;
        int HealValue = Force;
        Force /= 2;
        return $"Герой {Name} исцеляет себя на {HealValue}";
    }
    public string Wait()
    {
        if (Force == MaxForce)
        {
            return "Сила достигла максимума!";
        }
        Force += (MaxForce / 4);
        return $"Герой {Name} отдохнул. Запас сил восстановлен на {MaxForce/4}.";
    }
}
