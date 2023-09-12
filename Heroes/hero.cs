using DungeonMaster.Heroes;
using System;
using System.Collections.Generic;

public class Hero
{
    public string Name { get; set; }
    public int Level { get; set; }
    public TotalAttributes LevelAttributes { get; set; }
    public List<string> Equipment { get; set; }
    public List<string> ValidWeaponTypes { get; protected set; }
    public List<string> ValidArmorTypes { get; protected set; }

    public Hero(string name)
    {
        Name = name;
        Level = 1;
        LevelAttributes = new TotalAttributes(0, 0, 0);
        Equipment = new List<string>();
    }

    public virtual void LevelUp()
    {
        Level++;
    }

    public void Equip(string item)
    {
        Equipment.Add(item);
    }





    public virtual void Display()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Level: {Level}");
        Console.WriteLine($"Attributes:");
        Console.WriteLine($"Strength: {LevelAttributes.Strength}");
        Console.WriteLine($"Dexterity: {LevelAttributes.Dexterity}");
        Console.WriteLine($"Intelligence: {LevelAttributes.Intelligence}");
        Console.WriteLine($"Equipment:");
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
        LevelAttributes = new TotalAttributes(1, 1, 8);

    }

    public override void Display()
    {
        Console.WriteLine("Wizard:");
        base.Display();
    }
    public override void LevelUp()
    {
        base.LevelUp();
        LevelAttributes.Increase(1, 1, 5);
    }
}

public class Archer : Hero
{
    public Archer(string name) : base(name)
    {
        ValidWeaponTypes = new List<string> { "Bow" };
        ValidArmorTypes = new List<string> { "Leather", "Mail" };
        LevelAttributes = new TotalAttributes(1, 7, 1);
    }
    public override void LevelUp()
    {
        base.LevelUp();
        LevelAttributes.Increase(1, 5, 1);
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
        LevelAttributes = new TotalAttributes(2, 6, 1);
    }
    public override void LevelUp()
    {
        base.LevelUp();
        LevelAttributes.Increase(1, 4, 1);
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
        LevelAttributes = new TotalAttributes(5, 2, 1);
    }

    public override void LevelUp()
    {
        base.LevelUp();
        LevelAttributes.Increase(3, 2, 1);
    }
    public override void Display()
    {
        Console.WriteLine("Barbarian:");
        base.Display();
    }
}


