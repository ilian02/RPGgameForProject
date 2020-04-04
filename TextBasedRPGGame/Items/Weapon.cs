using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGGame
{
    public class Weapon : Item
    {

        private int attackPoints;

        public Weapon(String name, int sellPrice, String type, int attackPoints) : base(name, sellPrice, type)
        {
            this.attackPoints = attackPoints;
            this.Type = "weapon";
            this.Name = name;
        }

        public String toString()
        {
            StringBuilder sb = new StringBuilder(Name);

            sb.Append($" - Attack damage: {attackPoints}");
            return sb.ToString();
        }


        public int AttackPoints
        {
            get { return attackPoints; }
            set { attackPoints = value; }
        }
    }
}
