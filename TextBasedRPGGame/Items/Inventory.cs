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

            switch (item.Type)
            {
                case "weapon":
                    inventory.Add(new Weapon(item.Name, item.SellPrice, item.Type, ((Weapon)item).AttackPoints));
                    break;
                case "armor":
                    inventory.Add(new Weapon(item.Name, item.SellPrice, item.Type, ((Armor)item).DefencePoints));
                    break;

            }

            
            count++;
        }

        public void removeAt(int itemId)
        {
            inventory.RemoveAt(itemId);
            count--;
        }

    }
}
