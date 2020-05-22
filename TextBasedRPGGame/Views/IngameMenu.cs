using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGGame.Views
{
    public class IngameMenu
    {

        public String Menu()
        {
            Console.WriteLine("(C)haracter information");

            Console.WriteLine("(L)ocation information");

            Console.WriteLine("(I)nventory");

            return Console.ReadLine().ToLower();
        }


    }
}
