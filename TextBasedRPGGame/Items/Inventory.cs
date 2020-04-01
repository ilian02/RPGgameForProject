using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGGame.Items
{
    public class Inventory 
    {

        public List<Item> inventory;
        public int count { get; set; }

        public Inventory()
        {
            inventory = new List<Item>();
        }


        public void Add(Item item)
        {
            inventory.Add(item);
            count++;
        }

        public void removeAt(int itemId)
        {
            inventory.RemoveAt(itemId);
            count--;
        }

    }
}
