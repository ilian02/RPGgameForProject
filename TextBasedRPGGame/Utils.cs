using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextBasedRPGGame.Controllers;
using TextBasedRPGGame.Database;
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

        public static void displayListOfItems(List<MarketItem> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                Console.Write(i + 1 + ") ");
                Console.WriteLine($"{items[i].Name.Trim()} -> {items[i].Points}, {items[i].Type}");
            }
        }

        public static void displayListOfItems(List<Equipment> items)
        {
            if (items.Count == 0)
                Console.WriteLine(" Empty");
            for (int i = 0; i < items.Count; i++)
            {
                Console.Write(" " + (i + 1) + ") " + items[i].Name.Trim() + " " + items[i].Points);
            }
        }

        public static void displayListOfEnemies(List<EnemyModel> enemies)
        {
            for (int i = 0; i < enemies.Count;i++)
            {
                Console.Write(i + 1 + ") ");
                Console.WriteLine($"{enemies[i].Name.Trim()}, lvl {enemies[i].EnLevel}");
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

        public static void showItemInfo(MarketItem item)
        {
            Console.Write($"{item.Name} for {item.Price}. ");
            Console.Write($"{item.Points} ");

            switch(item.Type)
            {
                case "Weapon":
                    Console.Write("Attack Points");
                    break;
                case "Armor":
                    Console.Write("Defence Points");
                    break;
                case "Potion":
                    Console.Write("Regeneration Points");
                    break;
            }
        }

        public static bool inArrayRange(int end, int index)
        {
            if (index >= 0 && index < end)
            {
                return true;
            }
            return false;
        }

        public static void OpenInventory(Hero hero)
        {
            EquipmentBusiness eb = new EquipmentBusiness();
            Console.WriteLine("Inventory: ");
            List<Equipment> items = (eb.GetAllByOwnerId(hero.Id));

            if (items.Count == 0)
                Console.WriteLine(" Empty");

            for (int i = 0; i < items.Count; i++)
            {
                Console.Write(" " + (i + 1) + ") " + items[i].Name.Trim() + " " + items[i].Points);
                if (items[i].Is_equiped == true)
                    Console.WriteLine(" -> Equiped");
                else Console.WriteLine();
            }
        }
    }
}
