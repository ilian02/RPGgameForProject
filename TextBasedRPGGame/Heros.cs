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


        public Heros(String name)
        {
            this.name = name;
            this.weapon = new Weapon(3, 20, "Wooden small sword");
            this.armor = new Armor(2, 20, "Starter leather armor");
            strength = 1;
            vitality = 1;
            dexterity = 1;

        }

        public void showStats()
        {

        }
        
        public void appointLevels(int levelPoints)
        {
            for (int i = 0; i < levelPoints;i++)
            {

            }
        }

    }
}
