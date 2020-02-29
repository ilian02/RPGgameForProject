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

        Heros hero;
        IngameMenu ingameMenu = new IngameMenu();
        CharacterInfo characterInfo = new CharacterInfo();

        public GameLoop(Heros hero)
        {
            this.hero = hero;
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
