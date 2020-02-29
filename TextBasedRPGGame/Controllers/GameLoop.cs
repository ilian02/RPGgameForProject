using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedRPGGame.Views;

namespace TextBasedRPGGame.Controllers
{
    class GameLoop
    {

        Heros hero = new Heros("The One And Only");
        IngameMenu ingameMenu = new IngameMenu();
        CharacterInfo characterInfo = new CharacterInfo();

        public GameLoop()
        {
            GameIsPlaying();
        }

        public void GameIsPlaying()
        {
            String command = ingameMenu.Menu();

            switch(command)
            {
                case "c": characterInfo.showCharacterInfo(hero);
                    break;
            }
        }
    }
}
