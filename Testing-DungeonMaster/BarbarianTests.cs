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
    public class BarbarianTests
    {
        [Fact]
        public void CreateNewBarbarianTest()
        {
            string heroName = "Thor";

            Barbarian barbarian = new Barbarian(heroName);

            Assert.Equal(heroName, barbarian.Name);
            Assert.Equal(1, barbarian.Level);
            Assert.Equal(5, barbarian.LevelAttributes.Strength);
            Assert.Equal(2, barbarian.LevelAttributes.Dexterity);
            Assert.Equal(1, barbarian.LevelAttributes.Intelligence);
        }

        [Fact]
        public void BarbarianLevelUpTest()
        {
            Barbarian barbarian = new Barbarian("Thor");

            barbarian.LevelUp();

            Assert.Equal(2, barbarian.Level);
            Assert.Equal(8, barbarian.LevelAttributes.Strength);
            Assert.Equal(4, barbarian.LevelAttributes.Dexterity);
            Assert.Equal(2, barbarian.LevelAttributes.Intelligence);
        }

        [Fact]
        public void WeaponCreation_WithValidAttributes()
        {

            string weaponName = "Excalibur";
            int requiredLevel = 5;
            WeaponTypes expectedWeapon = Weapon.WeaponTypes.Sword;
            int weaponDamage = 50;



            Weapon weapon = new Weapon(weaponName, requiredLevel, expectedWeapon, weaponDamage);


            Assert.Equal(weaponName, weapon.Name);
            Assert.Equal(requiredLevel, weapon.RequiredLevel);
            Assert.Equal(Slot.Weapon, weapon.Slot);
            Assert.Equal(expectedWeapon, weapon.WeaponType);
            Assert.Equal(weaponDamage, weapon.WeaponDamage);
        }
        [Fact]
        public void BarbarianEquipValidWeapon()
        {

            var barbarian = new Barbarian("Thor");
            var equipment = new Equipment(barbarian);
            var validWeapon = new Weapon("Excalibur", 1, Weapon.WeaponTypes.Sword, 30);


            equipment.canEquipWeapon(validWeapon);


            var equippedWeapon = equipment.GetEquippedWeapon();
            Assert.Equal(validWeapon, equippedWeapon);
        }
        [Fact]
        public void BarbarianEquipInvalidWeaponType()
        {

            var barbarian = new Barbarian("Thorr");
            var equipment = new Equipment(barbarian);
            var invalidWeapon = new Weapon("Fire staff", 1, Weapon.WeaponTypes.Staff, 30);
            string expectedWeapon = "Barbarians can only use Hatchet, Mace, or Sword.";

            var actualWeapon = Assert.Throws<InvalidWeaponException>(() => equipment.canEquipWeapon(invalidWeapon));
            string actualWeaponMessage = actualWeapon.Message;
            Assert.Equal(expectedWeapon, actualWeaponMessage);
        }
        [Fact]
        public void BarbarianEquipInvalidWeapon_Level()
        {
            var barbarian = new Barbarian("Conan");
            var equipment = new Equipment(barbarian);
            var invalidWeapon = new Weapon("Enchanted Staff", 10, Weapon.WeaponTypes.Staff, 100);
            string expectedWeaponMessage = "The weapon's level requirement is too high for your hero's level.";

            var actualWeapon = Assert.Throws<InvalidWeaponException>(() => equipment.canEquipWeapon(invalidWeapon));
            string actualWeaponMessage = actualWeapon.Message;
            Assert.Equal(expectedWeaponMessage, actualWeaponMessage);
        }

        [Fact]
        public void BarbarianEquipValidArmor()
        {
            var barbarian = new Barbarian("Aragorn");
            var equipment = new Equipment(barbarian);
            var validArmor = new Armor("Plate Mail", 1, Slot.Body, Armor.ArmorTypes.Plate, new TotalAttributes(3, 2, 4));

            equipment.canEquipArmor(validArmor);

            Assert.Equal(validArmor, equipment.GetEquippedArmor(Slot.Body));
        }

        [Fact]
        public void BarbarianEquipInvalidArmor_Type()
        {
            var barbarian = new Barbarian("Conan");
            var equipment = new Equipment(barbarian);
            var invalidArmor = new Armor("Wizard's Robe", 1, Slot.Body, Armor.ArmorTypes.Cloth, new TotalAttributes(1, 2, 3));
            string expectedArmorMessage = "Barbarians can only use mail or plate armor.";

            var actualArmor = Assert.Throws<InvalidArmorException>(() => equipment.canEquipArmor(invalidArmor));
            string actualArmorMessage = actualArmor.Message;
            Assert.Equal(expectedArmorMessage, actualArmorMessage);
        }

    }
}
