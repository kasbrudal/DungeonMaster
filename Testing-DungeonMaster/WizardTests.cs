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
    public class WizardTests
    {
        [Fact]
        public void CreateNewWizardTest()
        {
            string heroName = "Merlin";

            Wizard wizard = new Wizard(heroName);

            Assert.Equal(heroName, wizard.Name);
            Assert.Equal(1, wizard.Level);
            Assert.Equal(1, wizard.LevelAttributes.Strength);
            Assert.Equal(1, wizard.LevelAttributes.Dexterity);
            Assert.Equal(8, wizard.LevelAttributes.Intelligence);
        }

        [Fact]
        public void WizardLevelUpTest()
        {
            Wizard wizard = new Wizard("Merlin");

            wizard.LevelUp();

            Assert.Equal(2, wizard.Level);
            Assert.Equal(2, wizard.LevelAttributes.Strength);
            Assert.Equal(2, wizard.LevelAttributes.Dexterity);
            Assert.Equal(13, wizard.LevelAttributes.Intelligence);
        }

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
      
        [Fact]
        public void WizardEquipValidWeapon()
        {
            // Arrange
            var wizard = new Wizard("Merlin"); // Assuming you have a Wizard class
            var equipment = new Equipment(wizard);
            var validWeapon = new Weapon("Wizard Staff", 1, Weapon.WeaponTypes.Staff, 10); // Valid weapon for a Wizard

            // Act
            equipment.canEquipWeapon(validWeapon);

            // Assert
            var equippedWeapon = equipment.GetEquippedWeapon();
            Assert.Equal(validWeapon, equippedWeapon);
        }
        [Fact]
        public void WizardEquipInvalidWeapon_Type()
        {
            // Arrange
            var wizard = new Wizard("Gandalf"); 
            var equipment = new Equipment(wizard);
            var invalidWeapon = new Weapon("Sword of Fire", 1, Weapon.WeaponTypes.Sword, 30);
            string expectedWeapon = "Wizards can only use Staff or Wand.";
            // Act and Assert
            var actualWeapon = Assert.Throws<InvalidWeaponException>(() => equipment.canEquipWeapon(invalidWeapon));
            string actualWeaponMessage = actualWeapon.Message;
            Assert.Equal(expectedWeapon, actualWeaponMessage);
        }

        [Fact]
        public void WizardEquipInvalidWeapon_Level()
        {
            // Arrange
            var wizard = new Wizard("Gandalf"); // Assuming you have a Wizard class
            var equipment = new Equipment(wizard);
            var invalidWeapon = new Weapon("Iben Staff", 10, Weapon.WeaponTypes.Staff, 100); // Invalid armor level for a Wizard
            string expectedWeaponMessage = "The weapon's level requirement is too high for your hero's level.";

            // Act and Assert
            var actualWeapon = Assert.Throws<InvalidWeaponException>(() => equipment.canEquipWeapon(invalidWeapon));
            string actualWeaponMessage = actualWeapon.Message;
            Assert.Equal(expectedWeaponMessage, actualWeaponMessage);
        }


        [Fact]
        public void WizardEquipValidArmor()
        {
            // Arrange
            var wizard = new Wizard("Merlin"); 
            var equipment = new Equipment(wizard);
            var validArmor = new Armor("Wizard's Robe", 1, Slot.Body, Armor.ArmorTypes.Cloth, new TotalAttributes(1, 2, 3)); // Valid armor for a Wizard

            // Act
            equipment.canEquipArmor(validArmor);

            // Assert
            Assert.Equal(validArmor, equipment.GetEquippedArmor(Slot.Body));
        }

        [Fact]
        public void WizardEquipInvalidArmor_Type()
        {
            // Arrange
            var wizard = new Wizard("Gandalf"); // Assuming you have a Wizard class
            var equipment = new Equipment(wizard);
            var invalidArmor = new Armor("Plate Armor", 1, Slot.Body, Armor.ArmorTypes.Plate, new TotalAttributes(3, 2, 4)); // Invalid armor type for a Wizard
            string expectedArmorMessage = "Wizard can only use cloth as armor";

            // Act and Assert
            var actualArmor = Assert.Throws<InvalidArmorException>(() => equipment.canEquipArmor(invalidArmor));
            string actualArmorMessage = actualArmor.Message;
            Assert.Equal(expectedArmorMessage, actualArmorMessage);
        }

        [Fact]
        public void WizardEquipInvalidArmor_Level()
        {
            // Arrange
            var wizard = new Wizard("Gandalf"); // Assuming you have a Wizard class
            var equipment = new Equipment(wizard);
            var invalidArmor = new Armor("High-Level Armor", 10, Slot.Body, Armor.ArmorTypes.Cloth, new TotalAttributes(1, 2, 3)); // Invalid armor level for a Wizard
            string expectedArmorMessage = "The armor's level requirement is too high for your hero's level.";

            // Act and Assert
            var actualArmor = Assert.Throws<InvalidArmorException>(() => equipment.canEquipArmor(invalidArmor));
            string actualArmorMessage = actualArmor.Message;
            Assert.Equal(expectedArmorMessage, actualArmorMessage);
        }

        [Fact]
        public void TotalAttributes_WizardWithNoEquipment()
        {
            // Arrange
            var wizard = new Wizard("TestWizard");

            // Act
            var totalAttributes = wizard.CalculateTotalAttributes();

            // Assert
            Assert.Equal(1, totalAttributes.Strength); // Adjust these values based on your default attributes for Wizards
            Assert.Equal(1, totalAttributes.Dexterity);
            Assert.Equal(8, totalAttributes.Intelligence); // Wizards have higher intelligence by default
        }

        [Fact]
        public void TotalAttributes_WizardWithWizardRobe()
        {
            // Arrange
            var wizard = new Wizard("TestWizard");
            var wizardRobe = new Armor("Wizard's Robe", 1, Slot.Body, Armor.ArmorTypes.Cloth, new TotalAttributes(1, 2, 3));

            // Act
            wizard.Equip(wizardRobe);
            var totalAttributes = wizard.CalculateTotalAttributes();

            // Assert
            Assert.Equal(2, totalAttributes.Strength); // Default + robe strength
            Assert.Equal(3, totalAttributes.Dexterity); // Default + robe dexterity
            Assert.Equal(11, totalAttributes.Intelligence); // Default + robe intelligence
        }
        [Fact]
        public void CalculateTotalAttributes_WithTwoArmorPieces()
        {
            var wizard = new Wizard("Merlin"); // Assuming you have a Wizard class
            var armor1 = new Armor("Infinity Robe", 2, Slot.Head, Armor.ArmorTypes.Cloth, new TotalAttributes(2, 1, 0));
            var armor2 = new Armor("Infinity bottom", 5, Slot.Legs, Armor.ArmorTypes.Cloth, new TotalAttributes(0, 0, 3));
            var armor3 = new Armor("Infinity Head", 5, Slot.Body, Armor.ArmorTypes.Cloth, new TotalAttributes(0, 10, 3));

            wizard.LevelUp();
            wizard.LevelUp();

            wizard.Equip(armor1);
            wizard.Equip(armor2);
            wizard.Equip(armor3);

            var totalAttributes = wizard.CalculateTotalAttributes();

            Assert.Equal(5, totalAttributes.Strength); // Sum of Headgear (2) and Leggings (1)
            Assert.Equal(14, totalAttributes.Dexterity); // Sum of Headgear (1)
            Assert.Equal(24, totalAttributes.Intelligence); // Sum of Leggings (3)
        }
        [Fact]
        public void CalculateTotalAttributes_WithReplacedArmor()
        {
            // Arrange
            var wizard = new Wizard("Merlin"); // Assuming you have a Wizard class
            var equipment = new Equipment(wizard);
            var armor1 = new Armor("Infinity Hat", 2, Slot.Head, Armor.ArmorTypes.Cloth, new TotalAttributes(2, 1, 0));
            var armor2 = new Armor("Rainbow Hat", 2, Slot.Head, Armor.ArmorTypes.Cloth, new TotalAttributes(0, 0, 3));
            wizard.LevelUp();
            
            equipment.canEquipArmor(armor1);

            // Act: Equip the second armor piece in the same Slot.Head, replacing the first one
            equipment.canEquipArmor(armor2);

            // Calculate total attributes
            var totalAttributes = wizard.CalculateTotalAttributes();

            // Assert
            Assert.Equal(2, totalAttributes.Strength); // No strength bonus from armor
            Assert.Equal(2, totalAttributes.Dexterity); // No dexterity bonus from armor
            Assert.Equal(13, totalAttributes.Intelligence); // Intelligence bonus from Crown (3)
        }


    }
}
