using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedRPGGame.Items;

namespace TextBasedRPGGame
{
    public class Hero : LivingThing
    {

        public Inventory inventory;


        public int money { get; set; }
        public Weapon weapon;
        public Armor armor;
        public int experiencePoints;
        public Place charPlace;
        public String placeName;

        public Hero(String name, int strength, int vitality, int dexterity,/*
            */int level, int currentHealthPoints) : base(name, strength, vitality, dexterity, level)
        {
            this.weapon = new Weapon("Wooden small sword", 10, "weapon", 1);
            this.armor = new Armor("Starter leather armor", 10, "armor", 1);
            experiencePoints = 0;
            money = 100;
            inventory = new Inventory();
            inventory.Add(this.weapon);
            inventory.Add(this.armor);
            this.currentHealthPoints = currentHealthPoints;
            charPlace = new Place("Starting Village", true, true, true, true, new List<Enemy>(), new List<Item>());
            this.placeName = this.charPlace.name;
        }

       public void heroDied()
        {
            Console.WriteLine("You died");
            Console.WriteLine("You lost " + (int)0.1 * money + " gold");
            currentHealthPoints = (10 + 5 * vitality) / 2;
            Console.WriteLine("Current health points: " + currentHealthPoints);
            money = money - (int)0.1 * money;
            
            
        }

    }
}
