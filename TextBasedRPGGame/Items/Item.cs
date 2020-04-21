using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGGame
{
    public class Item
    {

        private String name;
        private int sellPrice;
        private String type;

        

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


        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public int SellPrice
        {
            get { return sellPrice; }
            set { sellPrice = value; }
        }

        public String Type
        {
            get { return type; }
            set { type = value; }
        }
    }


}
