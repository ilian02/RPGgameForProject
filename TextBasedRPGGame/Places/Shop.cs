using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedRPGGame.Items;
using TextBasedRPGGame.Views;
using TextBasedRPGGame;
using TextBasedRPGGame.Controllers;
using TextBasedRPGGame.Database;
using TextBasedRPGGame.Controllers.ModelBusinesses;

namespace TextBasedRPGGame.Places
{
    public class Shop
    {

        EquipmentBusiness equipmentBusiness = new EquipmentBusiness();
        MarketItemsBusiness marketBusiness = new MarketItemsBusiness();
        HeroBusiness heroBusiness = new HeroBusiness();

        public Hero showShopItems(Hero hero)                      //Shop opening
        {

             List<MarketItem> merchandise = marketBusiness.GetAllByPlaceId(hero.PlaceId);

            Console.WriteLine("Welcome to the shop.");              
            Utils.displayListOfItems(merchandise);

            Console.WriteLine("Enter number of item, (S)ell items or (Q)uit");              //input

            string command = Console.ReadLine().ToLower();
            Console.WriteLine();

            if (command == "s")
            {
                return hero = sellItems(hero);                                      //selling command
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
                    showShopItems(hero);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine();
                showShopItems(hero);
            }

            return hero;
        }




        public Hero sellItems(Hero hero)
        { 
            Console.WriteLine();
            Console.WriteLine("Items you can sell: ");
            Utils.displayListOfItems(equipmentBusiness.GetAllByOwnerId(hero.Id));

            List<Equipment> heroItems = equipmentBusiness.GetAllByOwnerId(hero.Id);

            Console.WriteLine("Enter number of item to sell, (Q)uit or (G)o back");
            string command = Console.ReadLine().ToLower();

            if(command == "q")                  //quit shop menu
            {
                return hero;
            }else if (command == "g")           //back to shop menu buy page
            {
                return showShopItems(hero);
            }

            if (int.TryParse(command, out int result))          //check if input is int and in heroItems size
            {
                if (Utils.inArrayRange(heroItems.Count, result - 1))
                {
                    string commandForSale = ItemBuyAndSellMenu.DoYouWishToSell(heroItems[result - 1]);      //Do you wish to sell menu

                    if (commandForSale == "y")                          //sell item and delete from DBcontext
                    {
                        Console.Clear();
                        Console.WriteLine("You sold an item!");
                        hero.Money += (int)heroItems[result - 1].Price;
                        Console.WriteLine("Current gold: " + hero.Money);
                        heroBusiness.Update(hero);
                        equipmentBusiness.Delete(heroItems[result - 1].Id);
                        Console.WriteLine();
                        sellItems(hero);                        //back to selling item menu
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
                hero = showShopItems(hero);
            }


            return hero;
        }

        public Shop()
        {
            
        }

        public Hero itemPicked(MarketItem itemPicked, Hero hero)
        {
            Console.Clear();

            Utils.showItemInfo(itemPicked);
            string command = ItemBuyAndSellMenu.DoYouWishToBuy(itemPicked);          
            
            if (command == "y")
            {
                if (hero.Money >= itemPicked.Price)
                {
                    hero.Money -= (int)itemPicked.Price;
                    equipmentBusiness.AddNewItem(itemPicked, hero.Id);
                    heroBusiness.Update(hero);
                    Console.WriteLine("Item has been added to your inventory");
                    Console.WriteLine("Current balance: " + hero.Money);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("You don't have enough money");
                    Console.WriteLine();
                }

                hero = showShopItems(hero);
            }

            if (command == "n")
            {
                hero = showShopItems(hero);
            }

            return hero;
        }
        
     

    }
}
