using DungeonMaster.Heroes;

public class Wizard : Hero
{
    public Wizard(string name) : base(name)
    {
        ValidWeaponTypes = new List<string> { "Staff", "Wand" };
        ValidArmorTypes = new List<string> { "Cloth" };
        LevelAttributes = new TotalAttributes(1, 1, 8);
    }
    public override void LevelUp()
    {
        base.LevelUp();
        LevelAttributes.Increase(1, 1, 5);
    }
}


