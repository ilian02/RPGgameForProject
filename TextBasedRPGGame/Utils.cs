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

        public static void displayListOfEnemies(List<Enemy> enemies)
        {
            for (int i = 0; i < enemies.Count;i++)
            {
                Console.Write(i + 1 + ") ");
                Console.WriteLine($"{enemies[i].Name}, lvl {enemies[i].Level}");
            }
        }

        public static void showItemInfo(Item item)
        {
            Console.Write($"{item.Name} for {item.SellPrice}. ");
            if (item.Type == "weapon")
            {
                Console.WriteLine($"{((Weapon)item).AttackPoints} attack points");
            }
            else if (item.Type == "armor")
            {
                Console.WriteLine($"{((Armor)item).DefencePoints} defence points");
            }
            else if (item.Type == "consumable")
            {
                Console.WriteLine($"{((Consumable)item).HealthPointsRegen} regen points");
            }
        }
    }
}
