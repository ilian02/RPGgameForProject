using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGGame.Places
{
    public class Bed
    {

        public Hero useBed(Hero hero)
        {
            Console.WriteLine("You are in an inn");
            Console.WriteLine($"You are currently at {hero.currentHealthPoints} out of {hero.healthPoints}");
            Console.WriteLine("Do you wish to sleep and regenerate your Health Points for 15 gold? (Y) or (N)");

            String command = Console.ReadLine().ToLower();

            if(command == "y" && hero.money >= 15)
            {
                hero.currentHealthPoints = hero.healthPoints;
                hero.money -= 15;
            }else if (command == "y" && hero.money <= 15)
            {
                Console.WriteLine("You don't have enough money for this action");
            }

            return hero;
        }

    }
}
