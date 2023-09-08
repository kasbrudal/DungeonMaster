using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMaster.Heroes
{
    public class hero
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int LevelAttributes { get; set; }
        public List<string> Equipment { get; set; }
        public List<string> ValidWeaponTypes { get; set; }
        public List<string> ValidArmorTypes { get; set; }

            public hero(string name, List<string> validWeaponTypes, List<string> validArmorTypes) 
            {
                Name = name;
                Level = 1;
                LevelAttributes = Level;
                Equipment = new List<string>();
                ValidArmorTypes = validArmorTypes;
                ValidWeaponTypes = validWeaponTypes;
            }
        public virtual void Display()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine("Attributes:");
        }

    }
}
