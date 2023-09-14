using DungeonMaster.Heroes;

public class Archer : Hero
{
    public Archer(string name) : base(name)
    {
        ValidWeaponTypes = new List<string> { "Bow" };
        ValidArmorTypes = new List<string> { "Leather", "Mail" };
        LevelAttributes = new TotalAttributes(1, 7, 1);
    }
    public override void LevelUp()
    {
        base.LevelUp();
        LevelAttributes.Increase(1, 5, 1);
    }
  
}


