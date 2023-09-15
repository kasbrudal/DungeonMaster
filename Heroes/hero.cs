using DungeonMaster.Equipment;
using DungeonMaster.Heroes;
using System;
using System.Collections.Generic;
using System.Text;

public class Hero
{
    public string Name { get; set; }
    public int Level { get; set; }
    public TotalAttributes LevelAttributes { get; set; }
    public List<Item> Equipment { get; set; }
    public List<string> ValidWeaponTypes { get; protected set; }
    public List<string> ValidArmorTypes { get; protected set; }

    public Hero(string name)
    {
        Name = name;
        Level = 1;
        LevelAttributes = new TotalAttributes(0, 0, 0);
        Equipment = new List<Item>();
    }

    public virtual void LevelUp()
    {
        Level++;
    }

    public void Equip(Item item)
    {
        Equipment.Add(item);
    }
    /*
    public double CalculateDamage()
    {
        double heroDamage = 0.0;

        if (Equipment.ContainsKey(Slot.Weapon) && Equipment[Slot.Weapon] is Weapon equippedWeapon)
        {
            double baseWeaponDamage = equippedWeapon.WeaponDamage;

            int damagingAttribute = 0;

            if (this is Barbarian)
            {
                damagingAttribute = CalculateTotalAttributes().Strength;
            }
            else if (this is Wizard)
            {
                damagingAttribute = CalculateTotalAttributes().Intelligence;
            }
            else if (this is Archer || this is Swashbuckler)
            {
                damagingAttribute = CalculateTotalAttributes().Dexterity;
            }

            heroDamage = baseWeaponDamage * (1 + damagingAttribute / 100.0);
        }
        else
        {
            heroDamage = 1.0;
        }

        return heroDamage;
    }
    */

    public TotalAttributes CalculateTotalAttributes()
    {
        TotalAttributes totalAttributes = new TotalAttributes(0,0,0);

        totalAttributes.Strength += LevelAttributes.Strength;
        totalAttributes.Dexterity += LevelAttributes.Dexterity;
        totalAttributes.Intelligence += LevelAttributes.Intelligence;

        foreach (var equippedItem in Equipment)
        {
            if (equippedItem is Armor armor)
            {
                totalAttributes.Strength += armor.ArmorAttributes.Strength;
                totalAttributes.Dexterity += armor.ArmorAttributes.Dexterity;
                totalAttributes.Intelligence += armor.ArmorAttributes.Intelligence;
            }
        }

        return totalAttributes;
    }



    public string Display()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Name: {Name}");
        sb.AppendLine($"Class: {this.GetType().Name}");
        sb.AppendLine($"Level: {Level}");

        sb.AppendLine($"Total Strength: {LevelAttributes.Strength}");
        sb.AppendLine($"Total Dexterity: {LevelAttributes.Dexterity}");
        sb.AppendLine($"Total Intelligence: {LevelAttributes.Intelligence}");

        return sb.ToString();
    }


    

}


