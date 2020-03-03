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

        public Hero hero;

        public IngameMenu ingameMenu = new IngameMenu();
        public CharacterInfo characterInfo = new CharacterInfo();

        public Bed bed = new Bed();
        public Shop shop = new Shop();

        public Place place;

        public List<Item> shopItemsList = new List<Item>();
        public List<Enemy> enemyEncountersList = new List<Enemy>();

        public GameLoop(Hero hero)
        {
            this.hero = hero;
            GameIsPlaying();
        }

        public void GameIsPlaying()
        {
            shopItemsList.Add(hero.weapon);
            shopItemsList.Add(hero.armor);


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
                        switch(hero.charPlace.showPlaceInformation().ToLower())
                        {
                            case "s":
                                hero = shop.showShopItems(hero, shopItemsList);
                                break;
                            case "b":
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
