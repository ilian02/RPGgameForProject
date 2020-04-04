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


        private int money;
        private Weapon weapon;
        private Armor armor;
        private double experiencePoints;
        private Place charPlace;
        private String placeName;

        public Hero(String name, int strength, int vitality, int dexterity, int accuracy,/*
            */int level, int currentHealthPoints, int money) : base(name, strength, vitality, dexterity, accuracy, level)
        {
            this.weapon = new Weapon("Wooden small sword", 10, "weapon", 1);
            this.armor = new Armor("Starter leather armor", 10, "armor", 1);
            experiencePoints = 0;
            this.money = money;
            inventory = new Inventory();
            inventory.Add(this.weapon);
            inventory.Add(this.armor);
            this.CurrentHealthPoints = currentHealthPoints;
            charPlace = new Place("Starting Village", true, true, true, true, new List<Enemy>(), new List<Item>());
            this.placeName = this.charPlace.name;
        }

        
        public void enemyDied(Enemy enemy)
        {
            experiencePoints += enemy.XpGain;
            money += enemy.MoneyGain;
            Console.WriteLine($"{enemy.Name} has died");
            Console.WriteLine($"You get {enemy.XpGain} experience points and {enemy.MoneyGain} gold!");
            Console.WriteLine($"Current Health Points: {CurrentHealthPoints}");

            checkForLevelUp();
        }

        public void checkForLevelUp()
        {
            if(experiencePoints >= Level * 0.5 * 100)
            {
                levelUp();
            }
        }

        public void levelUp()
        {
            Console.WriteLine();
            Console.WriteLine("You leveled up!");
            Console.WriteLine("Strenght: " + Strength);
            Console.WriteLine("Vitality: " + Vitality);
            Console.WriteLine("Dexterity: " + Dexterity);
            Console.WriteLine("Accuracy: " + Accuracy);
            Console.WriteLine("(S), (V), (D) or (A)");

            string command = Console.ReadLine().ToLower();

            switch (command)
            {
                case "s": Strength++;
                    break;
                case "v": Vitality++;
                    break;
                case "d": Dexterity++;
                    break;
                case "a": Accuracy++;
                    break;
                default:
                    Console.WriteLine("Invalid input!");
                    levelUp();
                    break;
            }

            Console.WriteLine("Health fully restored!");
            HealthPoints = 10 + Vitality * 5;
            CurrentHealthPoints = HealthPoints;
        }



        public int Money
        {
            get { return money; }
            set { money = value; }
        }

        public Weapon Weapon
        {
            get { return weapon; }
            set { weapon = value; }
        }

        public Armor Armor
        {
            get { return armor; }
            set { armor = value; }
        }

        public double ExperiencePoints
        {
            get { return experiencePoints; }
            set { experiencePoints = value; }
        }


        public Place CharPlace
        {
            get { return charPlace; }
            set { charPlace = value; }
        }

        public String PlaceName
        {
            get { return placeName; }
            set { placeName = value; }
        }

    }
}
