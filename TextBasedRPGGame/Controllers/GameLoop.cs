using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedRPGGame.Places;
using TextBasedRPGGame.Views;

namespace TextBasedRPGGame.Controllers
{
    public class GameLoop
    {

        Hero hero;
        IngameMenu ingameMenu = new IngameMenu();
        CharacterInfo characterInfo = new CharacterInfo();
        Bed bed = new Bed();

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
                Console.Clear();
                switch (command)
                {
                    case "c":
                        characterInfo.showCharacterInfo(hero);
                        break;
                    case "l":
                        switch(hero.charPlace.showPlaceInformation())
                        {
                            case "s":
                                hero = bed.useBed(hero);
                                break;
                        }
                        break;

                }


                command = ingameMenu.Menu();

            }
        }
    }
}
