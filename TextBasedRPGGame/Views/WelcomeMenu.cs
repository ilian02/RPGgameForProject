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


        public String WelcomeMenuPrint()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Welcome to my work in progress");

            Console.WriteLine("(C)reate new character");
            Console.WriteLine("(L)oad saved character");
            Console.WriteLine("(A)bout the game");

            return Console.ReadLine().ToLower();
        }


        
    }
}
