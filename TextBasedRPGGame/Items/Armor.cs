using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGGame
{
    public class Armor : Item
    {

        public int defence { get; set; }
        public bool isEquiped { get; set; }

        public Armor(int defencePoints, int durability, String name)
        {
            this.defence = defencePoints;
            this.durability = durability;
            this.type = "armor";
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
                defence = defence / 2;
            }
        }

    }
}
