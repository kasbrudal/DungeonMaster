using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using DungeonMaster.Heroes;
using DungeonMaster.Equipment;

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
            if(hero is Wizard && weapon.WeaponTypes!= WeaponTypes.Staff && weapon.WeaponTypes != WeaponTypes.Wand)
            {
                throw new InvalidWeaponException("Wizard can only use Staff or Wand");
            }
            else if (hero is Archer && weapon.WeaponTypes != WeaponTypes.Bow)
            {
                throw new InvalidWeaponException("Archers can only use Bow.");
            }
            else if (hero is Swashbuckler && (weapon.WeaponTypes != WeaponTypes.Dagger && weapon.WeaponTypes != WeaponTypes.Sword))
            {
                throw new InvalidWeaponException("Swashbucklers can only use Dagger or Sword.");
            }
            else if (hero is Barbarian && (weapon.WeaponTypes != WeaponTypes.Hatchet && weapon.WeaponTypes != WeaponTypes.Mace && weapon.WeaponTypes != WeaponTypes.Sword))
            {
                throw new InvalidWeaponException("Barbarians can only use Hatchet, Mace, or Sword.");
            }

            if (!weapon.equipItem(hero))
            {
                throw new InvalidWeaponException("The item cannot be equiped because of your level");
            }

            equipment[Slot.Weapon] = weapon;
        }
        public void canEquipArmor(Armor armor)
        {
            if (hero is Wizard && armor.Armor != Armor.Cloth)
            {
                throw new InvalidArmorException("Wizard can only use cloth as armor");
            }
        }
    }

    [Serializable]
    internal class InvalidArmorException : Exception
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
    internal class InvalidWeaponException : Exception
    {
        public InvalidWeaponException()
        {
        }

        public InvalidWeaponException(string? message) : base(message)
        {
        }

        public InvalidWeaponException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidWeaponException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
