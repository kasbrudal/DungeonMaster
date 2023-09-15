using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonMaster.Heroes;

namespace DungeonMaster.Heroes
{
    public class TotalAttributes
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }

        public TotalAttributes(int strength, int dexterity, int intelligence)
        {
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
        }

        public void Increase(int strengthAmount, int dexterityAmount, int intelligenceAmount)
        {
            Strength += strengthAmount;
            Dexterity += dexterityAmount;
            Intelligence += intelligenceAmount;
        }
    }

}
