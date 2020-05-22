using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedRPGGame.Database;

namespace TextBasedRPGGame.Views
{
    public static class ItemBuyAndSellMenu
    {

        public static String DoYouWishToSell(Equipment item)
        {

            Console.WriteLine($"Do you wish to sell {item.Name.Trim()}  for {(int)item.Price/2}?");
            Console.WriteLine("(Y) or (N)");

            return Console.ReadLine().ToLower();
        }

        public static String DoYouWishToBuy(MarketItem itemPicked)
        {

            Console.WriteLine($"Do you wish to buy this item for {itemPicked.Price}?");
            Console.WriteLine("(Y) or (N)");

            return Console.ReadLine().ToLower();

            
        }
    }
}
