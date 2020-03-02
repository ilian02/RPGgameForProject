using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGGame
{
    public class Hero : LivingThing
    {

        public List<Item> inventory;


        public int money { get; set; }
        public Weapon weapon;
        public Armor armor;
        public int experiencePoints;
        public Place charPlace;
        public String placeName;

        public Hero(String name, int strength, int vitality, int dexterity,/*
            */int level, int currentHealthPoints) : base(name, strength, vitality, dexterity, level, currentHealthPoints)
        {
            this.weapon = new Weapon("Wooden small sword", 10, "weapon", 5);
            this.armor = new Armor("Starter leather armor", 10, "armor", 5);
            experiencePoints = 0;
            money = 100;
            inventory = new List<Item>();
            inventory.Add(this.weapon);
            inventory.Add(this.armor);
           
            charPlace = new Place("Starting Village", true, true, true, true, new List<Enemy>(), new List<Item>());
            this.placeName = this.charPlace.name;
        }

       

    }
}
