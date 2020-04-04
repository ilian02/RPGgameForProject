using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGGame
{
    public class Enemy : LivingThing
    {

        private int xpGain;
        private int moneyGain;


        public Enemy(String name, int strength, int vitality, int dexterity,int accuracy, int level, int xpGain, int moneyGain) :  base(name, strength, vitality, dexterity, accuracy, level)
        {
            this.xpGain = xpGain;
            this.CurrentHealthPoints = 5 + vitality * 5;
            this.moneyGain = moneyGain;
        }


        public int XpGain
        {
            get { return xpGain; }
            set { xpGain = value; }
        }
        public int MoneyGain
        {
            get { return moneyGain; }
            set { moneyGain = value; }
        }

    }
}
