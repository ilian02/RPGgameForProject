using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGGame
{
    public class LivingThing
    {

        public int healthPoints { get; set; }

        public int vitality { set; get; }
        public int dexterity { get; set; }
        public int strength { get; set; }
        public int currentHealthPoints { get; set; }
        public int level { get; set; }
        public String name { get; set; }

        public LivingThing(String name, int strength, int vitality, int dexterity, int level)
        {
            this.name = name;
            this.strength = strength;
            this.vitality = vitality;
            this.dexterity = dexterity;
            this.healthPoints = 10 + 5 * vitality;
            this.currentHealthPoints = 10 + 5 * vitality;
            this.level = level;
        }

    }
}
