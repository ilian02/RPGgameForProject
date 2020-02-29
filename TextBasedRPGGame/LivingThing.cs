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

        public void Attack(LivingThing enemy)
        {
            enemy.IsHit(this.strength);
        }

        public void IsHit(int damagePoints)
        {
            healthPoints -= damagePoints;
            IsDead();
        }

        public bool IsDead()
        {
            if (healthPoints <= 0)
                return true;
            return false;
        }
    }
}
