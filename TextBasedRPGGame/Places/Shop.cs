using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedRPGGame.Items;

namespace TextBasedRPGGame.Places
{
    public class Shop
    {

        List<Item> merchandise = new List<Item>();

        public Hero showShopItems(Hero hero, List<Item> items)
        {

            merchandise = items;

            Console.WriteLine("Welcome to the shop.");
            Utils.displayListOfItems(merchandise);

            Console.WriteLine("Enter number of item, (S)ell items or (Q)uit");

            string command = Console.ReadLine().ToLower();
            Console.WriteLine();

            if (command == "s")
            {
                return hero = sellItems(hero);
            }else if (command == "q")
            {
                return hero;
            }

            try
            {
                hero = itemPicked(merchandise[int.Parse(command) - 1], hero);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine();
                showShopItems(hero, items);
            }

            return hero;
        }

       


        public Hero sellItems(Hero hero)
        {
            Console.WriteLine();
            Console.WriteLine("Items you can sell: ");
            Utils.displayListOfItems(hero.inventory.inventory);

            Console.WriteLine("Enter number of item to sell, (Q)uit or (G)o back");
            string command = Console.ReadLine().ToLower();

            if(command == "q")
            {
                return hero;
            }else if (command == "g")
            {
                return showShopItems(hero, merchandise);
            }

            try
            {
                Console.WriteLine($"Do you wish to sell {hero.inventory.inventory[int.Parse(command) - 1].name} this item for {hero.inventory.inventory[int.Parse(command) - 1].sellPrice}?");
                Console.WriteLine("(Y) or (N)");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                sellItems(hero);
            }

            string commandForSale = Console.ReadLine().ToLower();

            if (commandForSale == "y")
            {
                try
                {
                    hero.money += hero.inventory.inventory[int.Parse(command) - 1].sellPrice;
                    hero.inventory.removeAt(int.Parse(command) - 1);
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine("Error: " + ex.Message);
                    sellItems(hero);
                }
                Console.WriteLine("You sold an item!");
                Console.WriteLine("Current gold: " + hero.money);
                sellItems(hero);
            }

            return hero;
        }

        public Shop()
        {
            
        }

        public Hero itemPicked(Item itemPicked, Hero hero)
        {
            Console.Clear();

            Utils.showItemInfo(itemPicked);
            Console.WriteLine($"Do you wish to buy this item for {itemPicked.sellPrice}?");
            Console.WriteLine("(Y) or (N)");

            string command = Console.ReadLine().ToLower();
            
            
            if (command == "y")
            {
                if (hero.money >= itemPicked.sellPrice)
                {
                    hero.money -= itemPicked.sellPrice;
                    hero.inventory.Add(itemPicked);
                    Console.WriteLine("Item has been added to your inventory");
                    Console.WriteLine("Current balance: " + hero.money);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("You don't have enough money");
                    Console.WriteLine();
                }

                hero = showShopItems(hero, merchandise);

            }

            if (command == "n")
            {
                hero = showShopItems(hero, merchandise);
            }

            return hero;
        }

     

    }
}
