using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedRPGGame.Fights;

namespace TextBasedRPGGame.Places
{
    public class EnemyArena
    {

        List<Enemy> enemyTypes;

        public EnemyArena()
        {
            this.enemyTypes = new List<Enemy>();
        }

        public Hero pickEnemyToFight(Hero hero, List<Enemy> enemyEncounters)
        {
            enemyTypes = enemyEncounters;
            Utils.displayListOfEnemies(enemyTypes);


            Console.WriteLine("Pick a number of enemy or (Q)uit");

            string command = Console.ReadLine().ToLower();
            
            if (command == "q")
            {
                return hero;
            }


            try
            {
                hero = Fight.startFight(hero, enemyTypes[int.Parse(command) - 1]);
            }
            catch(Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Error: " + ex.Message);
                pickEnemyToFight(hero, enemyEncounters);
            }

            return hero;
        }

        

    }
}
