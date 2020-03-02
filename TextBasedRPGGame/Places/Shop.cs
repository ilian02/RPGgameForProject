using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGGame.Places
{
    public class Shop
    {

        //List<Item> merchandise = new List<Item>();

        public Hero showShop(Hero hero, List<Item> items)
        {

            foreach(Item item in items)
            {
                showItemInfoInShop(item);
            }

            return hero;
        }


        public Shop()
        {
            
        }

        public void showItemInfoInShop(Item item)
        {
            Console.Write($"{item.name} for {item.sellPrice}. ");
            if (item.type == "weapon")
            {
                Console.WriteLine($"{((Weapon)item).attackPoints} attack points");
            }else if (item.type == "armor")
            {
                Console.WriteLine($"{((Armor)item).defencePoints} defence points");
            }
        }

    }
}
