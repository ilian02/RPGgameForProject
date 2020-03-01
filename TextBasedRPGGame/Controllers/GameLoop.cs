using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedRPGGame.Views;

namespace TextBasedRPGGame.Controllers
{
    public class GameLoop
    {

        Hero hero;
        IngameMenu ingameMenu = new IngameMenu();
        CharacterInfo characterInfo = new CharacterInfo();

        public GameLoop(Hero hero)
        {
            this.hero = hero;
            GameIsPlaying();
        }

        public void GameIsPlaying()
        {
            String command = ingameMenu.Menu();

            while (command != "e")
            {

                switch (command)
                {
                    case "c":
                        characterInfo.showCharacterInfo(hero);
                        break;
                    case "l":
                        hero.charPlace.showPlaceInformation();
                        break;

                }

                command = ingameMenu.Menu();
            }
        }
    }
}
