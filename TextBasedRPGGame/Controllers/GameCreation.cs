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
        GameSetUp gameSetUp = new GameSetUp();

        public GameCreation()
        {
            heros = gameSetUp.getHeroes();


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
