using System;
using System.Collections.Generic;

public class Hero
{
    public string Name { get; set; }
    public int Level { get; set; }
    public Dictionary<string, int> LevelAttributes { get; set; }
    public List<string> Equipment { get; set; }
    public List<string> ValidWeaponTypes { get; protected set; }
    public List<string> ValidArmorTypes { get; protected set; }

    public Hero(string name)
    {
        Name = name;
        Level = 1;
        LevelAttributes = new Dictionary<string, int>
        {
            { "Strength", 0 },
            { "Dexterity", 0 },
            { "Intelligence", 0 }
        };
        Equipment = new List<string>();
    }

    public void LevelUp()
    {
        Level++;
    }

    public void Equip(string item)
    {
        Equipment.Add(item);
    }

    

    public Dictionary<string, int> TotalAttributes()
    {
        return LevelAttributes;
    }

    public virtual void Display()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Level: {Level}");
        Console.WriteLine("Attributes:");
        foreach (var kvp in LevelAttributes)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
        Console.WriteLine("Equipment:");
        foreach (var item in Equipment)
        {
            Console.WriteLine(item);
        }
    }
}

public class Wizard : Hero
{
    public Wizard(string name) : base(name)
    {
        ValidWeaponTypes = new List<string> { "Staff", "Wand" };
        ValidArmorTypes = new List<string> { "Cloth" };
    }

    public override void Display()
    {
        Console.WriteLine("Wizard:");
        base.Display();
    }
}

public class Archer : Hero
{
    public Archer(string name) : base(name)
    {
        ValidWeaponTypes = new List<string> { "Bow" };
        ValidArmorTypes = new List<string> { "Leather", "Mail" };
    }

    public override void Display()
    {
        Console.WriteLine("Archer:");
        base.Display();
    }
}

public class Swashbuckler : Hero
{
    public Swashbuckler(string name) : base(name)
    {
        ValidWeaponTypes = new List<string> { "Sword", "Dagger" };
        ValidArmorTypes = new List<string> { "Leather", "Mail" };
    }

    public override void Display()
    {
        Console.WriteLine("Swashbuckler:");
        base.Display();
    }
}

public class Barbarian : Hero
{
    public Barbarian(string name) : base(name)
    {
        ValidWeaponTypes = new List<string> { "Hatchet", "Mace", "Sword" };
        ValidArmorTypes = new List<string> { "Plate", "Mail" };
    }

    public override void Display()
    {
        Console.WriteLine("Barbarian:");
        base.Display();
    }
}


