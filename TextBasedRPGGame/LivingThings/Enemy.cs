using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGGame
{
    public class Enemy : LivingThing
    {
           
        public int xpGain { set; get; }


        public Enemy(String name, int strength, int vitality, int dexterity, int level, int xpGain) :  base(name, strength, vitality, dexterity, level)
        {
            this.xpGain = xpGain;
            this.currentHealthPoints = 5 + vitality * 5;

        }

    }
}
