using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedRPGGame.Models;

namespace TextBasedRPGGame.Views
{
    public class WelcomeMenu
    {

        public String nickname { get; set; }

        public CharacterCreation WelcomeMenuPrint()
        {
            Console.WriteLine("----------------------------------");
         
            Console.WriteLine("Please write your nickname");
            nickname = Console.ReadLine();
            Console.WriteLine($"Welcome, {nickname}, to my work in progress");

            return new CharacterCreation(nickname);
        }

    }
}
