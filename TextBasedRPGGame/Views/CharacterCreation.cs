using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGGame.Views
{
    class CharacterCreation
    {

        public Heros CharacterCreationMenu()
        {
            Console.WriteLine("Pick a name for your new Hero: ");
            return new Heros(Console.ReadLine());
        }

    }
}
