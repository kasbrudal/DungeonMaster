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
        public Weapon.WeaponTypes WeaponTypes { get; }
        public int RequiredLevel { get; }
        public Slot Slot { get; }

        public Item(string name, Weapon.WeaponTypes weaponTypes, int requiredLevel, Slot slot)
        {
            Name = name;
            WeaponTypes = weaponTypes;
            RequiredLevel = requiredLevel;
            Slot = slot;
        }

        protected Item(string name, int requiredLevel, Slot slot)
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
}
