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

        public Armor(String name, int sellPrice, String type, int defencePoints) : base(name, sellPrice, type)
        {
            this.defence = defencePoints;
            this.type = "armor";
            this.name = name;
        }

        public String toString()
        {
            StringBuilder sb = new StringBuilder("name");

            sb.Append($"Defence points: {defence}");

            return sb.ToString();
        }

    }
}
