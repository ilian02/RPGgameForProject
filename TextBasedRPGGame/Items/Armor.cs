using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGGame
{
    public class Armor : Item
    {

        private int defencePoints;
        private bool isEquiped;

        public Armor(String name, int sellPrice, String type, int defencePoints) : base(name, sellPrice, type)
        {
            this.defencePoints = defencePoints;
            this.Type = "armor";
            this.Name = name;
        }

        public String toString()
        {
            StringBuilder sb = new StringBuilder("name");

            sb.Append($"Defence points: {defencePoints}");

            return sb.ToString();
        }

        public int DefencePoints
        {
            get { return defencePoints; }
            set { defencePoints = value; }
        }

        public bool IsEquiped
        {
            get { return isEquiped; }
            set { isEquiped = value; }
        }

    }
}
