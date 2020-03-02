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

        public Weapon(String name, int sellPrice, String type, int attackPoints) : base(name, sellPrice, type)
        {
            this.attackPoints = attackPoints;
            this.type = "weapon";
            this.name = name;
        }

        public String toString()
        {
            StringBuilder sb = new StringBuilder("name");

            sb.Append($"Attack damage: {attackPoints}");

            return sb.ToString();
        }

        public void attack()
        {
            Console.WriteLine("attack");
        }
    }
}
