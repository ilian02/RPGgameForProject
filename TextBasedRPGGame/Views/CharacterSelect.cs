using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGGame.Views
{
    public class CharacterSelect
    {

        public int CharacterSelectMenu(List<Heros> heros)
        {
            int i = 1;
            foreach(Heros hero in heros)
            {
                Console.WriteLine($"{i}: {hero.name} / {hero.level} level");
                i++;
            }

            Console.WriteLine("Please enter hero number to continue or 0 to go back");

            int command = int.Parse(Console.ReadLine());
            Console.WriteLine("You have chosen - " + heros[command - 1].name);
            return command;
        }


    }
}
