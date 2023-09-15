using System;
using DungeonMaster.Equipment;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using DungeonMaster.Heroes;
using static DungeonMaster.Equipment.Armor;


namespace DungeonMaster.Equipment
{
    public class Equipment
    {
        private readonly Dictionary<Slot, Item> equipment;
        private readonly Hero hero;
        public Equipment(Hero hero)
        {
            this.hero = hero;
            equipment = new Dictionary<Slot, Item>
            {
                { Slot.Weapon, null },
                { Slot.Head, null},
                { Slot.Body, null},
                { Slot.Legs, null}
            };
        }


        public void canEquipWeapon(Weapon weapon)
        {
            if (weapon.RequiredLevel > hero.Level)
            {
                throw new InvalidWeaponException("The weapon's level requirement is too high for your hero's level.");
            }

            if (hero is Wizard)
            {
                if (weapon.WeaponType != Weapon.WeaponTypes.Staff && weapon.WeaponType != Weapon.WeaponTypes.Wand)
                {
                    throw new InvalidWeaponException("Wizards can only use Staff or Wand.");
                }
            }
            else if (hero is Archer)
            {
                if (weapon.WeaponType != Weapon.WeaponTypes.Bow)
                {
                    throw new InvalidWeaponException("Archers can only use Bow.");
                }
            }
            else if (hero is Swashbuckler)
            {
                if (weapon.WeaponType != Weapon.WeaponTypes.Dagger && weapon.WeaponType != Weapon.WeaponTypes.Sword)
                {
                    throw new InvalidWeaponException("Swashbucklers can only use Dagger or Sword.");
                }
            }
            else if (hero is Barbarian)
            {
                if (weapon.WeaponType != Weapon.WeaponTypes.Hatchet && weapon.WeaponType != Weapon.WeaponTypes.Mace && weapon.WeaponType != Weapon.WeaponTypes.Sword)
                {
                    throw new InvalidWeaponException("Barbarians can only use Hatchet, Mace, or Sword.");
                }
            }

            equipment[Slot.Weapon] = weapon;
        }


        public Weapon GetEquippedWeapon()
        {
            if (equipment.ContainsKey(Slot.Weapon) && equipment[Slot.Weapon] is Weapon equippedWeapon)
            {
                return equippedWeapon;
            }

            return null;
        }
        public Armor GetEquippedArmor(Slot slot)
        {
            if (equipment.ContainsKey(slot) && equipment[slot] is Armor equippedArmor)
            {
                return equippedArmor;
            }

            return null; 
        }

        public void canEquipArmor(Armor armor)
        {
            if (hero is Wizard && armor.ArmorType != Armor.ArmorTypes.Cloth)
            {
                throw new InvalidArmorException("Wizard can only use cloth as armor");
            }
            else if (hero is Archer && (armor.ArmorType != ArmorTypes.Leather && armor.ArmorType != ArmorTypes.Mail))
            {
                throw new InvalidArmorException("Archers can only use leather or mail armor.");
            }
            else if (hero is Swashbuckler && (armor.ArmorType != ArmorTypes.Leather && armor.ArmorType != ArmorTypes.Mail))
            {
                throw new InvalidArmorException("Swashbucklers can only use leather or mail armor.");
            }
            else if (hero is Barbarian && (armor.ArmorType != ArmorTypes.Mail && armor.ArmorType != ArmorTypes.Plate))
            {
                throw new InvalidArmorException("Barbarians can only use mail or plate armor.");
            }

            if (armor.RequiredLevel > hero.Level)
            {
                throw new InvalidArmorException("The armor's level requirement is too high for your hero's level.");
            }

            equipment[armor.Slot] = armor;
        }
    }

    [Serializable]
    public class InvalidArmorException : Exception
    {
        public InvalidArmorException()
        {
        }

        public InvalidArmorException(string? message) : base(message)
        {
        }

        public InvalidArmorException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidArmorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    public class InvalidWeaponException : Exception
    {
        public InvalidWeaponException() { }
        public InvalidWeaponException(string message) : base(message) { }
        public InvalidWeaponException(string message, Exception innerException) : base(message, innerException) { }
        protected InvalidWeaponException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

}
