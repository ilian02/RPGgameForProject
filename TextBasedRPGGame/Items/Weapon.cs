using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGGame
{
    public class Weapon : Item
    {

        public int attackPoints { get; set; }

        public Weapon(int attackPoints,int durability, string name)
        {
            this.attackPoints = attackPoints;
            this.durability = durability;
            this.type = "weapon";
            this.name = name;
        }


        public void BeingUsed()
        {
            durability--;
            IsBroken();
        }

        public void IsBroken()
        {
            if (durability <= 0)
            {
                attackPoints = attackPoints / 2;
            }
        }
    }
}
