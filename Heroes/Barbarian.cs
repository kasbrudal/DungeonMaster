using DungeonMaster.Heroes;

public class Barbarian : Hero
{
    public Barbarian(string name) : base(name)
    {
        ValidWeaponTypes = new List<string> { "Hatchet", "Mace", "Sword" };
        ValidArmorTypes = new List<string> { "Plate", "Mail" };
        LevelAttributes = new TotalAttributes(5, 2, 1);
    }

    public override void LevelUp()
    {
        base.LevelUp();
        LevelAttributes.Increase(3, 2, 1);
    }
    
}


