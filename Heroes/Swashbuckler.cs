using DungeonMaster.Heroes;

public class Swashbuckler : Hero
{
    public Swashbuckler(string name) : base(name)
    {
        ValidWeaponTypes = new List<string> { "Sword", "Dagger" };
        ValidArmorTypes = new List<string> { "Leather", "Mail" };
        LevelAttributes = new TotalAttributes(2, 6, 1);
    }
    public override void LevelUp()
    {
        base.LevelUp();
        LevelAttributes.Increase(1, 4, 1);
    }
}


