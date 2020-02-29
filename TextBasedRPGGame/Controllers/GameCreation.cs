using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedRPGGame.Views;

namespace TextBasedRPGGame.Controllers
{
    public class GameCreation
    {
        CharacterSelect charSelect = new CharacterSelect();
        CharacterCreation charCreation = new CharacterCreation();
        List<Heros> heros = new List<Heros>();
        WelcomeMenu welcomeMenu = new WelcomeMenu();

        public GameCreation()
        {

            heros.Add(new Heros("pesho"));
            heros.Add(new Heros("ivan"));

            String command = welcomeMenu.WelcomeMenuPrint();
            
            switch(command)
            {
                case "c": heros.Add(charCreation.CharacterCreationMenu());
                    break;
                case "l": charSelect.CharacterSelectMenu(heros);
                    break;
                case "a": Console.WriteLine("This is it for now");
                    break;
               
            }
           


        }


    }
}
