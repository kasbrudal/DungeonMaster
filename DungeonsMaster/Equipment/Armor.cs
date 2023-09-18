using DungeonMaster.Heroes;

namespace DungeonMaster.Equipment
{
    public partial class Armor : Item
    {
        public ArmorTypes ArmorType { get; }
        public TotalAttributes ArmorAttributes { get; }

        public Armor(string name, int requiredLevel, Slot slot, ArmorTypes armorType, TotalAttributes armorAttributes)
            : base(name, requiredLevel, slot)
        {
            ArmorType = armorType;
            ArmorAttributes = armorAttributes;
        }
    }
}
