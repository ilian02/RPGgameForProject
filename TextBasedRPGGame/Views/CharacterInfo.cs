using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGGame.Views
{
    public static class CharacterInfo
    {

        public static void showCharacterInfo(Hero hero)
        {
            Console.WriteLine($"{hero.Name} current stats: ");
            Console.WriteLine($"Strenght: {hero.Strength}");
            Console.WriteLine($"Vitality: {hero.Vitality}");
            Console.WriteLine($"Dexterity: {hero.Dexterity}");
            Console.WriteLine($"Accuracy: {hero.Accuracy}");

            Console.WriteLine($"Current HealthPoints: {hero.CurrentHealthPoints} / {hero.HealthPoints}.");
            Console.WriteLine($"Current place is {hero.CharPlace.name}.");
            Console.WriteLine($"Money balance: {hero.Money}.");

            showInventory(hero);

            Console.WriteLine();
            Console.WriteLine();
        }

        public static void showInventory(Hero hero)
        {
            Utils.displayListOfItems(hero.inventory.inventory);
        }


        public static Hero heroDied(Hero hero)
        {
            Console.WriteLine("You died");
            Console.WriteLine("You lost " + (int)0.1 * hero.Money + " gold");
            hero.CurrentHealthPoints = (10 + 5 * hero.Vitality) / 2;
            Console.WriteLine("Current health points: " + hero.CurrentHealthPoints);
            hero.Money = hero.Money - (int)0.1 * hero.Money;

            return hero;
        }

    }
}
