using DungeonMaster.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMaster.Equipment
{
    public abstract class Item
    {
        public string Name { get; }
        public int RequiredLevel { get; }
        public Slot Slot { get; }

        public Item(string name, int requiredLevel, Slot slot)
        {
            Name = name;
            RequiredLevel = requiredLevel;
            Slot = slot;
        }
        
        public bool equipItem(Hero hero)
        {
            return hero.Level >= RequiredLevel;
        }
    }



    public enum Slot
    {
        Weapon,
        Head,
        Body, 
        Legs
    }

    public class Armor : Item
    {
        public ArmorTypes armorTypes { get; set;}
        public TotalAttributes ArmorAttribute { get; set;}
        public object Armor { get; internal set; }

        public Armor(string name, int requiredLevel, ArmorTypes armorTypes, TotalAttributes armorAttribute) 
            :base(name, requiredLevel, GetArmorSlot(armorTypes))
        {
            ArmorTypes = armorTypes;
            ArmorAttribute = armorAttribute;
        }
        private static Slot GetArmorSlot(ArmorTypes armorTypes)
        {

        }
    }

    public class Weapon : Item
    {
        public WeaponTypes weaponTypes { get; }
        public int WeaponDamage { get; }
        public WeaponTypes WeaponTypes { get; internal set; }

        public Weapon(string name, int requiredLevel, WeaponTypes weaponTypes, int weaponDamage) : 
                        base (name, requiredLevel, Slot.Weapon)
        {
            WeaponTypes = weaponTypes;
            WeaponDamage = weaponDamage;
        }

}
