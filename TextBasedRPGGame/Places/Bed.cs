using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedRPGGame.Controllers;

namespace TextBasedRPGGame.Places
{
    public class Bed
    {

        public Hero useBed(Hero hero)
        {
            HeroBusiness hb = new HeroBusiness();

            Console.WriteLine("You are in an inn");
            Console.WriteLine($"You are currently at {hero.CurrentHealthPoints} out of {hero.HealthPoints}");
            Console.WriteLine("Do you wish to sleep and regenerate your Health Points for 5 gold? (Y) or (N)");

            String command = Console.ReadLine().ToLower();

            if (command == "y" && hero.Money >= 5 && hero.CurrentHealthPoints == hero.HealthPoints)
            {
                Console.WriteLine("You don't need to sleep yet!");
            }
            else if (command == "y" && hero.Money >= 5 && hero.CurrentHealthPoints != hero.HealthPoints)
            {
                hero.CurrentHealthPoints = hero.HealthPoints;
                hero.Money -= 5;
                Console.WriteLine("You now have " + hero.HealthPoints + " health points");
                hb.Update(hero);
            }else if (command == "y" && hero.Money < 5)
            {
                Console.WriteLine("You don't have enough money for this action");
            }

            return hero;
        }

    }
}
