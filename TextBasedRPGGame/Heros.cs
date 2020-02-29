using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGGame
{
    public class Heros : LivingThing
    {

        public List<Item> inventory;

        public Weapon weapon;
        public Armor armor;

        public int experiencePoints;
        public String name;

        public String place;

        public Heros(String name)
        {
            this.name = name;
            this.weapon = new Weapon("Wooden small sword", 10, "weapon", 5);
            this.armor = new Armor("Starter leather armor", 10, "armor", 5);
            strength = 1;
            vitality = 1;
            dexterity = 1;
            currentHealthPoints = 10 + 5 * vitality;
            healthPoints = currentHealthPoints;
            experiencePoints = 0;
            inventory = new List<Item>();
            inventory.Add(this.weapon);
            inventory.Add(this.armor);
        }

        
        /*public void appointLevels(int levelPoints)
        {
            for (int i = 0; i < levelPoints;i++)
            {

            }
        }*/

    }
}
