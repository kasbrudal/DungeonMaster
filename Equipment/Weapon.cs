namespace DungeonMaster.Equipment
{
    public partial class Weapon : Item
    {
        public WeaponTypes WeaponType { get; set; }
        public int WeaponDamage { get; }

        public Weapon(string name, int requiredLevel, WeaponTypes weaponType, int weaponDamage) :
                        base(name, weaponType, requiredLevel, Slot.Weapon)
        {
            WeaponDamage = weaponDamage;
        }

    }
}
