namespace DungeonMaster.Equipment
{
    public partial class Weapon : Item
    {
        public WeaponTypes WeaponType { get; }
        public double WeaponDamage { get; }

        public Weapon(string name, int requiredLevel, WeaponTypes weaponType, double weaponDamage) :
                        base(name, weaponType, requiredLevel, Slot.Weapon)
        {
            WeaponType = weaponType;
            WeaponDamage = weaponDamage;
        }

    }
}
