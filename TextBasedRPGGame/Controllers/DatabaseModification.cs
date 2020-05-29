using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedRPGGame.Controllers.ModelBusinesses;
using TextBasedRPGGame.Database;

namespace TextBasedRPGGame.Controllers
{
    public class DatabaseModification
    {

        public HeroBusiness heroBusiness = new HeroBusiness();
        public EquipmentBusiness equipmentBusiness = new EquipmentBusiness();
        public EnemyBusiness enemyBusiness = new EnemyBusiness();
        public MarketItemsBusiness marketItemBusiness = new MarketItemsBusiness();
        public PlaceBusiness placeBusiness = new PlaceBusiness();

        public DatabaseModification()
        {
        }

        public void ChooseTable()
        {
            Console.WriteLine("Which table do you wish to change? ");
            Console.WriteLine("(M)arket Items, (H)ero list, (E)nemy list, (I)tem list, (P)lace list or (G)o back: ");
            string command = Console.ReadLine().ToLower();

            switch(command)
            {
                case "m":
                    ChangeMarketItemTable();
                    break;
                case "h":
                    ChangeHeroTable();
                    break;
                case "e":
                    ChangeEnemyTable();
                    break;
                case "i":
                    ChangeItemTable();
                    break;
                case "p":
                    ChangePlaceTable();
                    break;
                default:
                    GameCreation gameCreation = new GameCreation();
                    break;
            }
        }

        private void ChangePlaceTable()
        {
            List<MarketItem> marketItems = marketItemBusiness.GetAll();
            List<PlaceModel> places = placeBusiness.GetAll();
            switch (getActionCommand())
            {
                case "v":
                    Console.WriteLine();

                    int i = 1;
                    foreach (PlaceModel place in places)
                    {
                        Console.WriteLine($" {i}: {place.Name.Trim()} / {place.Id} Id");
                        i++;
                    }
                    ChangePlaceTable();
                    break;
                case "a":
                    PlaceModel newPlace = new PlaceModel();
                    Console.WriteLine("Input place name");
                    newPlace.Name = Console.ReadLine();
                    Console.WriteLine("Input place bed");
                    newPlace.Bed = bool.Parse(Console.ReadLine());
                    Console.WriteLine("Input place forge");
                    newPlace.Forge = bool.Parse(Console.ReadLine());
                    Console.WriteLine("Input place shop");
                    newPlace.Shop = bool.Parse(Console.ReadLine());
                    Console.WriteLine("Input place arena");
                    newPlace.Arena = bool.Parse(Console.ReadLine());
                    Console.WriteLine("Input place next place id");
                    newPlace.Next_Place = int.Parse(Console.ReadLine());
                    Console.WriteLine("Input place prev place id");
                    newPlace.Prev_Place = int.Parse(Console.ReadLine());



                    placeBusiness.Add(newPlace);
                    Console.Clear();
                    ChangePlaceTable();
                    break;
                case "d":
                    int j = 1;
                    foreach (PlaceModel palce in places)
                    {
                        Console.WriteLine($" {j}: {palce.Name.Trim()}");
                        j++;
                    }
                    Console.WriteLine("Which place do you wish to delete? Input number.");
                    int deleteNumber = int.Parse(Console.ReadLine());
                    placeBusiness.Delete(places[deleteNumber - 1].Id);
                    Console.Clear();
                    ChangePlaceTable();
                    break;
                default:
                    ChooseTable();
                    break;
            }
        }

        private void ChangeItemTable()
        {
            List<Equipment> playerItems = equipmentBusiness.GetAll();
            List<HeroModel> heroList = heroBusiness.GetAll();
            switch (getActionCommand())
            {
                case "v":
                    Console.WriteLine();
                    int i = 1;
                    foreach (Equipment item in playerItems)
                    {
                        Console.WriteLine($" {i}: {item.Name.Trim()} / {item.Points} points / {item.Price} price / {heroList[(int)item.Owner_id].Name.Trim()} player inventory");
                        i++;
                    }
                    ChangeItemTable();
                    break;
                case "a":
                    Equipment newItem = new Equipment();
                    Console.WriteLine("Input item name");
                    newItem.Name = Console.ReadLine();
                    Console.WriteLine("Input item points");
                    newItem.Points = int.Parse(Console.ReadLine());
                    Console.WriteLine("Input item price");
                    newItem.Price = int.Parse(Console.ReadLine());
                    Console.WriteLine("Input item place sold id");
                    newItem.Owner_id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Input item type");
                    newItem.Type = Console.ReadLine();
                    newItem.Is_equiped = false;

                    equipmentBusiness.Add(newItem);
                    Console.Clear();
                    ChangeItemTable();
                    break;
                case "d":
                    Console.WriteLine("Which item do you wish to delete? Input number.");
                    int deleteNumber = int.Parse(Console.ReadLine());
                    marketItemBusiness.Delete(playerItems[deleteNumber - 1].Id);
                    Console.Clear();
                    ChangeItemTable();
                    break;
                default:
                    ChooseTable();
                    break;
            }
        }

        private void ChangeEnemyTable()
        {
            List<EnemyModel> enemies = enemyBusiness.GetAll();
            List<PlaceModel> places = placeBusiness.GetAll();

            switch (getActionCommand())
            {
                case "v":
                    Console.WriteLine();
                    Console.Clear();

                    int i = 1;
                    foreach (EnemyModel enemy in enemies)
                    {
                        Console.WriteLine($" {i}: {enemy.Name.Trim()} / {enemy.EnLevel} level / {places[(int)enemy.Place_Id - 1].Name.Trim()}");
                        i++;
                    }

                    ChangeEnemyTable();
                    break;
                case "a":
                    EnemyModel newEnemy = new EnemyModel();
                    Console.Write("Input enemy name: ");
                    newEnemy.Name = Console.ReadLine();
                    Console.Write("Input enemy Healthpoints: ");
                    newEnemy.Healthpoints = int.Parse(Console.ReadLine());
                    newEnemy.Current_healthpoints = newEnemy.Healthpoints;
                    Console.Write("Input enemy vitality: ");
                    newEnemy.Vit = int.Parse(Console.ReadLine());
                    Console.Write("Input enemy dexterity: ");
                    newEnemy.Dex = int.Parse(Console.ReadLine());
                    Console.Write("Input enemy strenght: ");
                    newEnemy.STR = int.Parse(Console.ReadLine());
                    Console.Write("Input enemy accuracy: ");
                    newEnemy.ACC = int.Parse(Console.ReadLine());
                    Console.Write("Input enemy exp gain: ");
                    newEnemy.Exp_Gain = int.Parse(Console.ReadLine());
                    Console.Write("Input enemy money gain: ");
                    newEnemy.Money_Gain = int.Parse(Console.ReadLine());
                    Console.Write("Input enemy level: ");
                    newEnemy.EnLevel = int.Parse(Console.ReadLine());
                    Console.Write("Input enemy place id: ");
                    newEnemy.Place_Id = int.Parse(Console.ReadLine());


                    enemyBusiness.Add(newEnemy);
                    Console.Clear();
                    Console.WriteLine("Hero " + newEnemy.Name.Trim() + " added!");
                    ChangeEnemyTable();
                    break;
                case "d":
                    int j = 1;
                    foreach (EnemyModel enemy in enemies)
                    {
                        Console.WriteLine($" {j}: {enemy.Name.Trim()} / {enemy.EnLevel} level / {places[(int)enemy.Place_Id].Name.Trim()}");
                        j++;
                    }
                    Console.WriteLine("Which enemy do you wish to delete? Input number.");
                    int deleteNumber = int.Parse(Console.ReadLine());
                    if (Utils.inArrayRange(enemies.Count, (deleteNumber - 1)))
                    {
                        enemyBusiness.Delete(enemies[deleteNumber - 1].Id);
                        Console.WriteLine("Enemy " + enemies[deleteNumber - 1].Name.Trim() + " was deleted!");
                    }

                    ChangeEnemyTable();
                    break;
                default:
                    ChooseTable();
                    break;
            }

        }

        private void ChangeHeroTable()
        {
            List<HeroModel> heros = heroBusiness.GetAll();

            switch (getActionCommand())
            {
                case "v":
                    Console.WriteLine();
                    Console.Clear();

                    int i = 1;
                    foreach (HeroModel hero in heros)
                    {
                        Console.WriteLine($" {i}: {hero.Name.Trim()} / {hero.Char_level} level");
                        i++;
                    }

                    ChangeHeroTable();
                    break;
                case "a":
                    HeroModel newHero = new HeroModel();
                    Console.Write("Input hero name: ");
                    newHero.Name = Console.ReadLine();
                    Console.Write("Input hero Healthpoints: ");
                    newHero.HealthPoints = int.Parse(Console.ReadLine());
                    Console.Write("Input hero Current Healthpoints: ");
                    newHero.Current_healthpoints = int.Parse(Console.ReadLine());
                    Console.Write("Input hero vitality: ");
                    newHero.Vit = int.Parse(Console.ReadLine());
                    Console.Write("Input hero dexterity: ");
                    newHero.Dex = int.Parse(Console.ReadLine());
                    Console.Write("Input hero strenght: ");
                    newHero.Str = int.Parse(Console.ReadLine());
                    Console.Write("Input hero accuracy: ");
                    newHero.Acc = int.Parse(Console.ReadLine());
                    Console.Write("Input hero exp: ");
                    newHero.Exp = int.Parse(Console.ReadLine());
                    Console.Write("Input hero level: ");
                    newHero.Char_level = int.Parse(Console.ReadLine());
                    Console.Write("Input hero money: ");
                    newHero.Money = int.Parse(Console.ReadLine());
                    Console.Write("Input hero current place id: ");
                    newHero.Current_place = int.Parse(Console.ReadLine());

                    heroBusiness.Add(newHero);
                    Console.Clear();
                    Console.WriteLine("Hero " + newHero.Name.Trim() + " added!");
                    ChangeHeroTable();
                    break;
                case "d":
                    int j = 1;
                    foreach (HeroModel hero in heros)
                    {
                        Console.WriteLine($" {j}: {hero.Name.Trim()} / {hero.Char_level} level");
                        j++;
                    }
                    Console.WriteLine("Which hero do you wish to delete? Input number.");
                    int deleteNumber = int.Parse(Console.ReadLine());
                    if (Utils.inArrayRange(heros.Count, (deleteNumber - 1)))
                    {
                        List<Equipment> itemsToDelete = equipmentBusiness.GetAllByOwnerId(heros[deleteNumber - 1].Id);
                        heroBusiness.Delete(heros[deleteNumber - 1].Id);
                        for (int p = 0; p < itemsToDelete.Count; p++)
                        {
                            equipmentBusiness.Delete(itemsToDelete[p].Id);
                        }
                    }
                    Console.WriteLine("Hero " + heros[deleteNumber - 1].Name.Trim() + " was deleted!");
                    Console.Clear();
                    ChangeHeroTable();
                    break;
                default:
                    ChooseTable();
                    break;
            }

        }

        private void ChangeMarketItemTable()
        {
            List<MarketItem> marketItems = marketItemBusiness.GetAll();
            List<PlaceModel> places = placeBusiness.GetAll();
            switch (getActionCommand())
            {
                case "v":
                    Console.WriteLine();

                    int i = 1;
                    foreach (MarketItem item in marketItems)
                    {
                        Console.WriteLine($" {i}: {item.Name.Trim()} / {item.Points} points / {item.Price} price / {places[(int)item.PlaceSold_id - 1].Name.Trim()} place sold");
                        i++;
                    }
                    ChangeMarketItemTable();
                    break;
                case "a":
                    MarketItem newItem = new MarketItem();
                    Console.WriteLine("Input item name");
                    newItem.Name = Console.ReadLine();
                    Console.WriteLine("Input item points");
                    newItem.Points = int.Parse(Console.ReadLine());
                    Console.WriteLine("Input item price");
                    newItem.Price = int.Parse(Console.ReadLine());
                    Console.WriteLine("Input item place sold id");
                    newItem.PlaceSold_id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Input item type");
                    newItem.Type = Console.ReadLine();

                    marketItemBusiness.Add(newItem);
                    Console.Clear();
                    ChangeMarketItemTable();
                    break;
                case "d":
                    Console.WriteLine("Which item do you wish to delete? Input number.");
                    int deleteNumber = int.Parse(Console.ReadLine());
                    marketItemBusiness.Delete(marketItems[deleteNumber - 1].Id);
                    Console.Clear();
                    ChangeMarketItemTable();
                    break;
                default:
                    ChooseTable();
                    break;
            }


        }

        public String getActionCommand()
        {
            Console.WriteLine("(V)iew all\n(A)dd new\n(D)elete or (E)nd action");
            

            return Console.ReadLine().ToLower();
        }

    }
}
