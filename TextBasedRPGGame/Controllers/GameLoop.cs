using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedRPGGame.Places;
using TextBasedRPGGame.Views;
using TextBasedRPGGame.Database;
using TextBasedRPGGame.Controllers.ModelBusinesses;

namespace TextBasedRPGGame.Controllers
{
    public class GameLoop
    {

        public Hero hero;
        public Place place;

        public IngameMenu ingameMenu = new IngameMenu();

        public PlaceBusiness placeBusiness = new PlaceBusiness();
        public HeroBusiness heroBusiness = new HeroBusiness();
      

        
        public GameLoop(Hero hero)
        {
            this.hero = hero;
            place = new Place(placeBusiness.Get(this.hero.PlaceId));
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
                        CharacterInfo.showCharacterInfo(hero);
                        break;
                    case "i":
                        hero = hero.OpenInventory(hero);
                        break;
                    case "l":
                        showPlaceInfo();
                        break;
                }
                command = ingameMenu.Menu();

            }
        }

        public void showPlaceInfo()
        {
            string placeCommand = place.showPlaceInformation();

            if (placeCommand == "s" && place.Shop == true)
            {
                Shop shop = new Shop();
                hero = shop.showShopItems(hero);
            }
            else if (placeCommand == "b" && place.Bed == true)
            {
                Bed bed = new Bed();
                hero = bed.useBed(hero);
            }
            else if (placeCommand == "a" && place.Arena == true)
            {
                EnemyArena enemyArena = new EnemyArena();
                hero = enemyArena.pickEnemyToFight(hero);
            }
            else if (placeCommand == "f" && place.Forge == true)
            {
                Forge forge = new Forge();
                hero = forge.showForgeOptions(hero);
            }
            else if (placeCommand == "n" && place.NextPlace != null)
            {
                place = place.goToNextPlace();
                hero.PlaceId = place.Id;
                heroBusiness.Update(hero);
            }
            else if (placeCommand == "p" && place.PrevPlace != null)
            {
                place = place.goToPrevPlace();
                hero.PlaceId = place.Id;
                heroBusiness.Update(hero);
            }
        }

    }
}
