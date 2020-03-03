using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGGame.Items
{
    public class Consumable : Item
    {

        public int healthPointsRegen { get; set; }

        public Consumable(string name, int sellPrice, string type, int healthPointsRegen) : base(name, sellPrice, type)
        {
            this.healthPointsRegen = healthPointsRegen;

        }

        public String toString()
        {
            StringBuilder sb = new StringBuilder("name");

            sb.Append($"Health points regenerate: {healthPointsRegen}");

            return sb.ToString();
        }
    }
}
