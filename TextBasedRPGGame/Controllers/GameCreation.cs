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
        List<Hero> heros = new List<Hero>();
        WelcomeMenu welcomeMenu = new WelcomeMenu();
        GameLoop gameLoop;

        public GameCreation()
        {

            heros.Add(new Hero("pesho", 5,  3, 4, 6, 25));
            heros.Add(new Hero("ivan", 55, 78, 25, 150, 100));
            Place place = new Place("Starting Village", true, true, true, true, new List<Enemy>());


            heros[0].charPlace = place;
            heros[1].charPlace = place;


            String command = welcomeMenu.WelcomeMenuPrint();
            

            switch(command)
            {
                case "c": heros.Add(charCreation.CharacterCreationMenu());
                    gameLoop = new GameLoop(heros.Last());
                    break;
                case "l":  gameLoop = new GameLoop(heros[charSelect.CharacterSelectMenu(heros)]);
                    break;
                case "a": Console.WriteLine("This is it for now");
                    break;
               
            }



        }


    }
}
