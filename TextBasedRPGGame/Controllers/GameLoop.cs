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
            shopItemsList.Add(hero.Weapon);
            shopItemsList.Add(hero.Armor);


            Enemy goblin = new Enemy("Novice Goblin", 1, 1, 1, 1, 1, 10, 15);
            enemyEncountersList.Add(goblin);



            String command = ingameMenu.Menu();

            while (command != "e")
            {
          
                Console.Clear();
                switch (command)
                {
                    case "c":
                        CharacterInfo.showCharacterInfo(hero);
                        break;
                    case "l":
                        switch(hero.CharPlace.showPlaceInformation().ToLower())
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
