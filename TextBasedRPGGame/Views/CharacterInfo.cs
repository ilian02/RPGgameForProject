using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGGame.Views
{
    public class CharacterInfo
    {

        public void showCharacterInfo(Hero hero)
        {
            Console.WriteLine($"{hero.name} current stats: ");
            Console.WriteLine($"Strenght: {hero.strength}");
            Console.WriteLine($"Vitality: {hero.vitality}");
            Console.WriteLine($"Dexterity: {hero.dexterity}");

            Console.WriteLine($"Current HealthPoints: {hero.currentHealthPoints} / {hero.healthPoints}");
            Console.WriteLine($"Current place is {hero.charPlace.name}");

            showInventory(hero);

            Console.WriteLine();
            Console.WriteLine();
        }

        public void showInventory(Hero hero)
        {

            Utils.displayListOfItems(hero.inventory.inventory);
        }


    }
}
