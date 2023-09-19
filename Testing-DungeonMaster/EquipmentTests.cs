using Xunit;
using DungeonMaster.Heroes;
using DungeonMaster.Equipment;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;
using static DungeonMaster.Equipment.Weapon;
using static DungeonMaster.Equipment.Armor;
using System.Runtime.InteropServices;

namespace Testing_DungeonMaster
{
    public class EquipmentTests
    {
        [Fact]
        public void WeaponCreation_WithValidAttributes()
        {

            string weaponName = "Water Staff";
            int requiredLevel = 5;
            WeaponTypes expectedWeapon = Weapon.WeaponTypes.Staff;
            int weaponDamage = 20;



            Weapon weapon = new Weapon(weaponName, requiredLevel, expectedWeapon, weaponDamage);


            Assert.Equal(weaponName, weapon.Name);
            Assert.Equal(requiredLevel, weapon.RequiredLevel);
            Assert.Equal(Slot.Weapon, weapon.Slot);
            Assert.Equal(expectedWeapon, weapon.WeaponType);
            Assert.Equal(weaponDamage, weapon.WeaponDamage);
        }
        [Fact]
        public void ArmorCreation_WithValidAttributes()
        {
            string armorName = "Common Plate Chest";
            int requiredLevel = 3;
            Slot expectedSlot = Slot.Body;
            ArmorTypes expectedArmorType = Armor.ArmorTypes.Plate;
            TotalAttributes expectedArmorAttributes = new TotalAttributes(1, 2, 3);

            Armor armor = new Armor(armorName, requiredLevel, expectedSlot, expectedArmorType, expectedArmorAttributes);

            Assert.Equal(armorName, armor.Name);
            Assert.Equal(requiredLevel, armor.RequiredLevel);
            Assert.Equal(expectedSlot, armor.Slot);
            Assert.Equal(expectedArmorType, armor.ArmorType);
            Assert.Equal(expectedArmorAttributes, armor.ArmorAttributes);
        }
    }
}
