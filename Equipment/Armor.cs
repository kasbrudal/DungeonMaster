using DungeonMaster.Heroes;

namespace DungeonMaster.Equipment
{
    public partial class Armor : Item
    {

        public ArmorTypes armorTypes { get; set; }
        public TotalAttributes armorAttribute { get; set; }

        public Armor(string name, int requiredLevel, ArmorTypes armorTypes, Slot slot, TotalAttributes ArmorAttribute)
            : base(name, requiredLevel, slot)
        {
            ArmorAttribute = armorAttribute;
        }
    }
    
}
