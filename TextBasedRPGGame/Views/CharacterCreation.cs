using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGGame.Views
{
    class CharacterCreation
    {

        public Hero CharacterCreationMenu()
        {
            Console.WriteLine("Pick a name for your new Hero: ");
            return new Hero(Console.ReadLine(), 1, 1, 1, 1, 15);
        }

    }
}
