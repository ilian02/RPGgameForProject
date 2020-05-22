using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedRPGGame.Database;
using TextBasedRPGGame.Views;

namespace TextBasedRPGGame.Controllers
{
    public class GameCreation
    {
        CharacterSelect charSelect = new CharacterSelect();
        WelcomeMenu welcomeMenu = new WelcomeMenu();
        HeroBusiness heroBusiness = new HeroBusiness();
        EquipmentBusiness equipmentBusiness = new EquipmentBusiness();
        public DatabaseModification databaseModification = new DatabaseModification();

        public GameCreation()
        {

            String command = welcomeMenu.WelcomeMenuPrint();

            switch(command)
            {
                case "c": CreateNewHero();
                    Hero hero = new Hero(heroBusiness.GetLast());
                    GameLoop gameLoopNew = new GameLoop(hero);
                    break;

                case "l":
                    int heroId = charSelect.CharacterSelectMenu();
                    var loadedHeroes = heroBusiness.GetAll();
                    Hero heroPicked = new Hero(loadedHeroes[heroId - 1]);
                    GameLoop gameLoopLoaded = new GameLoop(heroPicked);
                    break;

                case "d":
                    databaseModification.ChooseTable();
                    break;
               
            }
        }

        public void CreateNewHero()
        {
            Console.WriteLine("Input name for your hero: ");
            string name = Console.ReadLine();

            HeroModel newHero = new HeroModel() { Name = name, HealthPoints = 15, Current_healthpoints = 15, Vit = 1, Dex = 1, Str = 1, Acc = 1, Exp = 0, Char_level = 1, Money = 20, Current_place = 1 };

            heroBusiness.Add(newHero);

            HeroModel heroModification = heroBusiness.Get(newHero.Id);
            equipmentBusiness.Add(new Equipment() { Name = "Wooden sword", Is_equiped = true, Owner_id = heroModification.Id, Points = 1, Price = 10, Type = "Weapon"});
            equipmentBusiness.Add(new Equipment() { Name = "Leather armor", Is_equiped = true, Owner_id = heroModification.Id, Points = 1, Price = 10, Type = "Armor" });

            List<Equipment> heroBeginingItems = equipmentBusiness.GetAllByOwnerId(heroModification.Id).ToList();
            heroModification.Equiped_weapon_id = heroBeginingItems[0].Id;
            heroModification.Equiped_Armor_id = heroBeginingItems[1].Id;

            heroBusiness.Update(heroModification);
        }
    }
}
