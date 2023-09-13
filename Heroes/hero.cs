using DungeonMaster.Equipment;
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

    public TotalAttributes CalculateTotalAttributes()
    {
        TotalAttributes totalAttributes = new TotalAttributes();

        totalAttributes.Strength += LevelAttributes.Strength;
        totalAttributes.Dexterity += LevelAttributes.Dexterity;
        totalAttributes.Intelligence += LevelAttributes.Intelligence;

        foreach(var slot in new[] {Slot.Head, Slot.Body, Slot.Legs})
        {
            if(Equipment.ContainsKey(slot) && Equipment[slot] is Armor armor)
            {
                totalAttributes.Strength += armor.ArmorAttributes.Strength;
                totalAttributes.Dexterity += armor.ArmorAttributes.Dexterity;
                totalAttributes.Intelligence += armor.ArmorAttributes.Intelligence;
            }
        }
        return totalAttributes;
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


