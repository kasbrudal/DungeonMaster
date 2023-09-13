using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMaster.Heroes
{
    public class TotalAttributes
    {
        public int Strength { get; private set; }
        public int Dexterity { get; private set; }
        public int Intelligence { get; private set; }

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
