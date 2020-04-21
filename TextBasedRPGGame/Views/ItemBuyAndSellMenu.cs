using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGGame.Views
{
    public static class ItemBuyAndSellMenu
    {

        public static String DoYouWishToSell(Hero hero, int id)
        {

            Console.WriteLine($"Do you wish to sell {hero.inventory.inventory[id-1].Name} this item for {hero.inventory.inventory[id-1].SellPrice}?");
            Console.WriteLine("(Y) or (N)");

            return Console.ReadLine().ToLower();
        }

        public static String DoYouWishToBuy(Item itemPicked)
        {

            Console.WriteLine($"Do you wish to buy this item for {itemPicked.SellPrice}?");
            Console.WriteLine("(Y) or (N)");

            return Console.ReadLine().ToLower();

            
        }
    }
}
