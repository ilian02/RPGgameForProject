using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGGame
{
    public class LivingThing
    {

        public int hitPoints
        {
            set
            {
                if (value >= 0)
                    hitPoints = value;
            }
            get
            {
                return hitPoints;
            }
        }


        public int vitality { set; get; }
        public int dexterity { get; set; }
        public int strength { get; set; }

        public void Attack(LivingThing enemy)
        {
            enemy.IsHit(this.strength);
        }

        public void IsHit(int damagePoints)
        {
            hitPoints -= damagePoints;
            IsDead();
        }

        public bool IsDead()
        {
            if (hitPoints <= 0)
                return true;
            return false;
        }
    }
}
