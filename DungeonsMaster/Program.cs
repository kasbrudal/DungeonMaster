using DungeonMaster.Heroes;
using System;
using DungeonMaster.Equipment;
class Program
{
    static void Main()
    {
        var wizard = new Wizard("Kasper");
        var archer = new Archer("Jacob");
        var swashbuckler = new Swashbuckler("Marcus");
        var barbarian = new Barbarian("Mads");
        Console.WriteLine(wizard.Display());
        Console.WriteLine(archer.Display());
        Console.WriteLine(swashbuckler.Display());
        Console.WriteLine(barbarian.Display());

      
    }
}