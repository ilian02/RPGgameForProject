using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedRPGGame.Items;
using TextBasedRPGGame.Views;
using TextBasedRPGGame;

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

            if (int.TryParse(command, out int result))
            {
                if (Utils.inArrayRange(merchandise.Count, result - 1))
                {
                    hero = itemPicked(merchandise[int.Parse(command) - 1], hero);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine();
                    showShopItems(hero, items);
                }
            }
            else
            {
                Console.Clear();
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

            if (int.TryParse(command, out int result))
            {
                if (Utils.inArrayRange(hero.inventory.count, result - 1))
                {
                    string commandForSale = ItemBuyAndSellMenu.DoYouWishToSell(hero, result);

                    if (commandForSale == "y")
                    {
                        Console.Clear();
                        Console.WriteLine("You sold an item!");
                        Console.WriteLine("Current gold: " + hero.Money);
                        hero.inventory.removeAt(result - 1);
                        Console.WriteLine();
                        sellItems(hero);
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid command!");
                    hero = sellItems(hero);
                }

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid command!");
                hero = showShopItems(hero, merchandise);
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
            string command = ItemBuyAndSellMenu.DoYouWishToBuy(itemPicked);          
            
            if (command == "y")
            {
                if (hero.Money >= itemPicked.SellPrice)
                {
                    hero.Money -= itemPicked.SellPrice;
                    hero.inventory.Add(itemPicked);
                    Console.WriteLine("Item has been added to your inventory");
                    Console.WriteLine("Current balance: " + hero.Money);
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
