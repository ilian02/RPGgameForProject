using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGGame
{
    public class Item
    {

        public String name { get; set; }
        public int sellPrice { get; set; }
        public String type { get; set; }


        public Item(String name, int sellPrice, String type)
        {
            this.name = name;
            this.sellPrice = sellPrice;
            this.type = type;
        }

        public String toString()
        {
            return $"{type}, {name}";
        }

        public String toStringFull()
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("Type: " + type);
            sb.Append("Name: " + name);
            sb.Append("Sell price: " + sellPrice);

            return sb.ToString();
        }
    }
}
