using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedRPGGame.Controllers;
using TextBasedRPGGame.Database;
using TextBasedRPGGame.Fights;

namespace TextBasedRPGGame.Places
{
    public class EnemyArena
    {

        List<EnemyModel> enemyTypes;
        EnemyBusiness eb;


        public EnemyArena()
        {
            eb = new EnemyBusiness();
        }

        public Hero pickEnemyToFight(Hero hero)
        {


            enemyTypes = eb.GetAllByOwnerId(hero.PlaceId);
            Utils.displayListOfEnemies(enemyTypes);


            Console.WriteLine("Pick a number of enemy or (Q)uit");

            string command = Console.ReadLine().ToLower();
            
            if (command == "q")
            {
                return hero;
            }

            try
            {
                Enemy enemy = new Enemy(enemyTypes[int.Parse(command) - 1]);

                hero = Fight.startFight(hero, enemy);
            }
            catch(Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Error: " + ex.Message);
                pickEnemyToFight(hero);
            }

            return hero;
        }

        

    }
}
