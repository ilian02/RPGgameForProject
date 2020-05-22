using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedRPGGame.Controllers;
using TextBasedRPGGame.Database;

namespace TextBasedRPGGame.Places
{
    public class Forge
    {
        public EquipmentBusiness eb;
        public HeroBusiness hb;

        public Forge()
        {
            eb = new EquipmentBusiness();
            hb = new HeroBusiness();
        }


        public Hero showForgeOptions(Hero hero)
        {
            Console.WriteLine("You entered the forge");
            Console.WriteLine("Pick a weapon to upgrade: ");

            List<Equipment> weaponsInInventory = eb.GetAllTypeByOwnerId(hero.Id, "Weapon");


            Utils.displayListOfItems(weaponsInInventory);

            Console.WriteLine("Enter ID of item or (Q)uit");
            string command = Console.ReadLine();

      
            if (command == "q")
            {
                return hero;
            }

            try
            {
                hero = payingForUpgrade(int.Parse(command) - 1, hero, weaponsInInventory);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine();
                showForgeOptions(hero);
            }

            return hero;
        }


        public Hero payingForUpgrade(int weaponNumber, Hero hero, List<Equipment> weaponsInInventory)
        {

            Console.WriteLine("Do you wish to upgrade this weapon for " + weaponsInInventory[weaponNumber].Price + " gold?");
            Console.WriteLine("(Y)es or (N)o");
            Console.WriteLine("(Q)uit to show");

            string command = Console.ReadLine().ToLower();

            if (command == "n")
            {
                Console.Clear();
                hero = showForgeOptions(hero);
            }
            else if (command == "y" && (int)hero.Money >= (int)weaponsInInventory[weaponNumber].Price / 2)
            {

                    Console.Clear();
                    hero.Money -= (int)weaponsInInventory[weaponNumber].Price / 2;
                    weaponsInInventory[weaponNumber].Points += 1 + (int)Math.Ceiling((double)weaponsInInventory[weaponNumber].Points / 3);
                    weaponsInInventory[weaponNumber].Name = weaponsInInventory[weaponNumber].Name.Trim() + "*";
                    weaponsInInventory[weaponNumber].Price *= 2;
                    Console.WriteLine("You upgraded your weapon!");
                    Console.WriteLine("Current money balance: " + hero.Money);
                    Console.WriteLine();


                    eb.Update(weaponsInInventory[weaponNumber]);
                    hb.Update(hero);    

                    hero = showForgeOptions(hero);
            }
            else if (command == "y" && hero.Money < weaponsInInventory[weaponNumber].Price / 2)
            {
                Console.Clear();
                Console.WriteLine("You don't have enough money for this action!");
                Console.WriteLine();
                hero = showForgeOptions(hero);
            }else if (command == "q")
            {
                return hero;
            }

            return hero;
        }
        
    }
}
