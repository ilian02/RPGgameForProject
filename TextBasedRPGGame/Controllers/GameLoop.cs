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
        public Forge forge = new Forge();
        public EnemyArena enemyArena = new EnemyArena();

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


            Enemy goblin = new Enemy("Novice Goblin", 1, 1, 1, 1, 10);
            enemyEncountersList.Add(goblin);



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
                            case "a":
                                hero = enemyArena.pickEnemyToFight(hero, enemyEncountersList);
                                break;
                            case "f":
                                hero = forge.showForgeOptions(hero);
                                break;
                        }
                        break;

                }


                command = ingameMenu.Menu();

            }
        }
    }
}
