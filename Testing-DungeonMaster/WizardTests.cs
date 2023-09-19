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
        public void WizardEquipValidWeapon()
        {
            
            var wizard = new Wizard("Merlin");
            var equipment = new Equipment(wizard);
            var validWeapon = new Weapon("Wizard Staff", 1, Weapon.WeaponTypes.Staff, 10);

            
            equipment.canEquipWeapon(validWeapon);

            
            var equippedWeapon = equipment.GetEquippedWeapon();
            Assert.Equal(validWeapon, equippedWeapon);
        }
        [Fact]
        public void WizardEquipInvalidWeaponType()
        {
            
            var wizard = new Wizard("Gandalf"); 
            var equipment = new Equipment(wizard);
            var invalidWeapon = new Weapon("Sword of Fire", 1, Weapon.WeaponTypes.Sword, 30);
            string expectedWeapon = "Wizards can only use Staff or Wand.";
            
            var actualWeapon = Assert.Throws<InvalidWeaponException>(() => equipment.canEquipWeapon(invalidWeapon));
            string actualWeaponMessage = actualWeapon.Message;
            Assert.Equal(expectedWeapon, actualWeaponMessage);
        }

        [Fact]
        public void WizardEquipInvalidWeapon_Level()
        {
            
            var wizard = new Wizard("Gandalf"); 
            var equipment = new Equipment(wizard);
            var invalidWeapon = new Weapon("Iben Staff", 10, Weapon.WeaponTypes.Staff, 100); 
            string expectedWeaponMessage = "The weapon's level requirement is too high for your hero's level.";

          
            var actualWeapon = Assert.Throws<InvalidWeaponException>(() => equipment.canEquipWeapon(invalidWeapon));
            string actualWeaponMessage = actualWeapon.Message;
            Assert.Equal(expectedWeaponMessage, actualWeaponMessage);
        }


        [Fact]
        public void WizardEquipValidArmor()
        {
            
            var wizard = new Wizard("Merlin"); 
            var equipment = new Equipment(wizard);
            var validArmor = new Armor("Wizard's Robe", 1, Slot.Body, Armor.ArmorTypes.Cloth, new TotalAttributes(1, 2, 3));

           
            equipment.canEquipArmor(validArmor);

           
            Assert.Equal(validArmor, equipment.GetEquippedArmor(Slot.Body));
        }

        [Fact]
        public void WizardEquipInvalidArmor_Type()
        {
           
            var wizard = new Wizard("Gandalf"); 
            var equipment = new Equipment(wizard);
            var invalidArmor = new Armor("Plate Armor", 1, Slot.Body, Armor.ArmorTypes.Plate, new TotalAttributes(3, 2, 4)); 
            string expectedArmorMessage = "Wizard can only use cloth as armor";

          
            var actualArmor = Assert.Throws<InvalidArmorException>(() => equipment.canEquipArmor(invalidArmor));
            string actualArmorMessage = actualArmor.Message;
            Assert.Equal(expectedArmorMessage, actualArmorMessage);
        }

        [Fact]
        public void WizardEquipInvalidArmor_Level()
        {

            var wizard = new Wizard("Gandalf");
            var equipment = new Equipment(wizard);
            var invalidArmor = new Armor("High-Level Armor", 10, Slot.Body, Armor.ArmorTypes.Cloth, new TotalAttributes(1, 2, 3)); 
            string expectedArmorMessage = "The armor's level requirement is too high for your hero's level.";

            var actualArmor = Assert.Throws<InvalidArmorException>(() => equipment.canEquipArmor(invalidArmor));
            string actualArmorMessage = actualArmor.Message;
            Assert.Equal(expectedArmorMessage, actualArmorMessage);
        }

        [Fact]
        public void TotalAttributes_WizardWithNoEquipment()
        {
            var wizard = new Wizard("Harry Potter");

            var totalAttributes = wizard.CalculateTotalAttributes();

            Assert.Equal(1, totalAttributes.Strength); 
            Assert.Equal(1, totalAttributes.Dexterity);
            Assert.Equal(8, totalAttributes.Intelligence); 
        }

        [Fact]
        public void TotalAttributes_WizardWithArmor()
        {
            var wizard = new Wizard("Kasper");
            var wizardRobe = new Armor("Wizard's Robe", 1, Slot.Body, Armor.ArmorTypes.Cloth, new TotalAttributes(1, 2, 3));


            wizard.Equip(wizardRobe);
            var totalAttributes = wizard.CalculateTotalAttributes();

            Assert.Equal(wizard.LevelAttributes.Strength, totalAttributes.Strength); 
            Assert.Equal(wizard.LevelAttributes.Dexterity, totalAttributes.Dexterity); 
            Assert.Equal(wizard.LevelAttributes.Intelligence, totalAttributes.Intelligence); 
        }
        [Fact]
        public void CalculateTotalAttributes_WithTwoArmorPieces()
        {
            var wizard = new Wizard("Merlin");
            var armor1 = new Armor("Infinity Robe", 2, Slot.Head, Armor.ArmorTypes.Cloth, new TotalAttributes(2, 1, 0));
            var armor2 = new Armor("Infinity bottom", 5, Slot.Legs, Armor.ArmorTypes.Cloth, new TotalAttributes(0, 0, 3));
            var armor3 = new Armor("Infinity Head", 5, Slot.Body, Armor.ArmorTypes.Cloth, new TotalAttributes(0, 10, 3));

            wizard.LevelUp();
            wizard.LevelUp();
            wizard.LevelUp();
            wizard.LevelUp();
            wizard.LevelUp();

            wizard.Equip(armor1);
            wizard.Equip(armor2);
            wizard.Equip(armor3);

            var totalAttributes = wizard.CalculateTotalAttributes();

            Assert.Equal(wizard.LevelAttributes.Strength, totalAttributes.Strength); 
            Assert.Equal(wizard.LevelAttributes.Dexterity, totalAttributes.Dexterity);
            Assert.Equal(wizard.LevelAttributes.Intelligence, totalAttributes.Intelligence); 
        }
        [Fact]
        public void CalculateTotalAttributes_WithReplacedArmor()
        {
            
            var wizard = new Wizard("Merlin"); 
            var equipment = new Equipment(wizard);
            var armor1 = new Armor("Infinity Hat", 2, Slot.Head, Armor.ArmorTypes.Cloth, new TotalAttributes(2, 1, 0));
            var armor2 = new Armor("Rainbow Hat", 2, Slot.Head, Armor.ArmorTypes.Cloth, new TotalAttributes(0, 0, 3));
            wizard.LevelUp();
            
            equipment.canEquipArmor(armor1);

           
            equipment.canEquipArmor(armor2);

            var totalAttributes = wizard.CalculateTotalAttributes();

            Assert.Equal(2, totalAttributes.Strength);
            Assert.Equal(2, totalAttributes.Dexterity); 
            Assert.Equal(13, totalAttributes.Intelligence);
        }
        [Fact]
        public void Wizard_CalculateDamage_WithNoWeaponEquipped()
        {
            var wizard = new Wizard("Harry Potter");
   
            var damage = wizard.CalculateDamage();
            
            Assert.Equal(1.0, damage); 
        }

        [Fact]
        public void Wizard_CalculateDamage_WithWeaponEquipped()
        {
            var wizard = new Wizard("Harry Pottwe");
            var wand = new Weapon("Fire wand", 1, Weapon.WeaponTypes.Wand, 20.0);

            wizard.Equip(wand);
            var damage = wizard.CalculateDamage();

            var expectedDamage = wand.WeaponDamage * (1 + wizard.LevelAttributes.Intelligence / 100.0);
            Assert.Equal(expectedDamage, damage);
        }
        [Fact]
        public void Wizard_CalculateDamage_WithANewWeaponEquipped()
        {
            var wizard = new Wizard("Harry");
            var oldWand = new Weapon("Fire Wand", 1, Weapon.WeaponTypes.Wand, 20.0);
            var newWand = new Weapon("Electric Wand", 2, Weapon.WeaponTypes.Wand, 50);

            wizard.Equip(oldWand);
            var damageOldWand = wizard.CalculateDamage();
            var expectedOldDamage = oldWand.WeaponDamage * (1 + wizard.LevelAttributes.Intelligence / 100.0);

            wizard.LevelUp();
            wizard.Equip(newWand);
            var damageNewWand = wizard.CalculateDamage();

            var expectedNewDamage = newWand.WeaponDamage * (1 + wizard.LevelAttributes.Intelligence / 100.0);

            Assert.Equal(expectedOldDamage, damageOldWand);
            Assert.Equal(expectedNewDamage, damageNewWand);
        }
        [Fact]
        public void Wizard_CalculateDamage_WithWeaponAndArmorEquipped()
        {
            var wizard = new Wizard("Harry Potter");
            var staff = new Weapon("Iben staff", 1, Weapon.WeaponTypes.Staff, 30.0);
            var clothArmor = new Armor("Wizard Robe", 1, Slot.Body, Armor.ArmorTypes.Cloth, new TotalAttributes(10, 10, 10));

            wizard.Equip(staff);
            wizard.Equip(clothArmor);

            var damage = wizard.CalculateDamage();

            var expectedDamage = staff.WeaponDamage * (1 + wizard.LevelAttributes.Intelligence / 100.0);

            Assert.Equal(expectedDamage, damage);
        }

    }
}
