using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedRPGGame.Items;

namespace TextBasedRPGGame
{
    public static class Utils
    {

        public static void displayListOfItems(List<Item> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                Console.Write(i + 1 + ") ");
                showItemInfo(items[i]);
            }
        }


        public static void showItemInfo(Item item)
        {
            Console.Write($"{item.name} for {item.sellPrice}. ");
            if (item.type == "weapon")
            {
                Console.WriteLine($"{((Weapon)item).attackPoints} attack points");
            }
            else if (item.type == "armor")
            {
                Console.WriteLine($"{((Armor)item).defencePoints} defence points");
            }
            else if (item.type == "consumable")
            {
                Console.WriteLine($"{((Consumable)item).healthPointsRegen} regen points");
            }
        }
    }
}
