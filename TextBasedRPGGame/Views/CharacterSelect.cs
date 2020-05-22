using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedRPGGame.Controllers;
using TextBasedRPGGame.Database;
using TextBasedRPGGame.projectDBDataSetTableAdapters;

namespace TextBasedRPGGame.Views
{
    public class CharacterSelect
    {

        public int CharacterSelectMenu()
        {
            HeroBusiness heroBusiness = new HeroBusiness();
            EquipmentBusiness equipmentBusiness = new EquipmentBusiness();
            List<HeroModel> heros = heroBusiness.GetAll();


            int i = 1;
            foreach(HeroModel hero in heros)
            {
                Console.WriteLine($"{i}: {hero.Name} / {hero.Char_level} level");
                i++;
            }

            Console.WriteLine("Please enter hero number to continue or (D)elete to delete hero");

            string command = Console.ReadLine();

            if(command == "d")
            while (command == "d")
            {
                Console.WriteLine("Which hero do you wish to delete? Input number.");
                int deleteNumber = int.Parse(Console.ReadLine());
                if (Utils.inArrayRange(heros.Count, (deleteNumber - 1)))
                {
                     List<Equipment> itemsToDelete = equipmentBusiness.GetAllByOwnerId(heros[deleteNumber - 1].Id);
                     heroBusiness.Delete(heros[deleteNumber - 1].Id);
                        for (int j = 0; j < itemsToDelete.Count; j++)
                        {
                            equipmentBusiness.Delete(itemsToDelete[j].Id);
                        }
                }
                Console.WriteLine("Please enter hero number to continue or (D)elete to delete hero");
                command = Console.ReadLine().ToLower();
            }


            return int.Parse(command);
        }


    }
}
