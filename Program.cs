class Program
{
    static void Main()
    {   
        var wizard = new Wizard("Kasper");
        var archer = new Archer("Jacob");
        var swashbuckler = new Swashbuckler("Marcus");
        var barbarian = new Barbarian("Mads");

        wizard.Display();
        archer.Display();
        swashbuckler.Display();
        barbarian.Display();
    }
}