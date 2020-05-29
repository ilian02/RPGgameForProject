using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TextBasedRPGGame.Controllers;
using TextBasedRPGGame.Database;
using TextBasedRPGGame.Items;

namespace TextBasedRPGGame
{
    public class Hero : LivingThing
    {


        private int id;
        private int money;
        private int? weapon;
        private int? armor;
        private int experiencePoints;
        private int placeId;

        public EquipmentBusiness eb = new EquipmentBusiness();
        public HeroBusiness hb = new HeroBusiness();

        public Hero(HeroModel hero)
        {
            this.Id = hero.Id;
            this.Name = hero.Name;
            this.HealthPoints =(int) hero.HealthPoints;
            this.CurrentHealthPoints = (int)hero.Current_healthpoints;
            this.Vitality = (int)hero.Vit;
            this.Dexterity = (int)hero.Dex;
            this.Strength = (int)hero.Str;
            this.Accuracy = (int)hero.Acc;
            this.ExperiencePoints = (int)hero.Exp;
            this.Level = (int)hero.Char_level;
            this.Armor = hero.Equiped_Armor_id;
            this.Weapon = hero.Equiped_weapon_id;
            this.placeId = (int)hero.Current_place;
            this.money = (int)hero.Money;
        }

        public Hero enemyDied(Enemy enemy, Hero hero)
        {
            hero.ExperiencePoints += enemy.XpGain;
            hero.Money += enemy.MoneyGain;
            Console.WriteLine($"{enemy.Name.Trim()} has died");
            Console.WriteLine($"You get {enemy.XpGain} experience points and {enemy.MoneyGain} gold!");
            Console.WriteLine($"Current Health Points: {CurrentHealthPoints}");

            checkForLevelUp();
            hb.Update(hero);

            return hero;
        }

        public Hero heroDied(Hero hero)
        {

            Console.WriteLine("You died!\n You lost " + hero.money / 2 + " gold. Current balance: " + hero.Money + "\n Current healthpoints: " + (int)Math.Floor(0.3 * (double)hero.HealthPoints) + "/" + hero.HealthPoints);


            hero.CurrentHealthPoints = (int)Math.Floor(0.3 * (double)hero.HealthPoints);
            hero.money -= hero.money / 2;

            hb.Update(hero);

            return hero;
        }

        public Hero OpenInventory(Hero hero)
        {
            Utils.OpenInventory(hero);
            List<Equipment> items = (eb.GetAllByOwnerId(hero.Id));

            Console.WriteLine("Input number of item you wish to equip or (g)o back");

            string command = Console.ReadLine();

            if (int.TryParse(command, out int result))
            {
                if (Utils.inArrayRange(items.Count, result - 1));
                equipItem(items[result - 1]);
                hero = hero.OpenInventory(hero);
            }

            return hero;
        }

        private void equipItem(Equipment item)
        {
            Console.WriteLine();
            Equipment oldItem = eb.GetEquipedByIdAndType(Id, item.Type);

            if (oldItem != null)
            {
                oldItem.Is_equiped = false;
                eb.Update(oldItem);
            }

            item.Is_equiped = true;
            eb.Update(item);

            if (item.Type == "Weapon")
            {
                this.Weapon = item.Id;
            }else if (item.Type == "Armor")
            {
                this.Armor = item.Id;
            }

            hb.Update(this);

        }

        public void checkForLevelUp()
        {
            if(experiencePoints >= Level * 50)
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
            Level++;
        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int Money
        {
            get { return money; }
            set { money = value; }
        }

        public int? Weapon
        {
            get { return weapon; }
            set { weapon = value; }
        }

        public int? Armor
        {
            get { return armor; }
            set { armor = value; }
        }

        public int ExperiencePoints
        {
            get { return experiencePoints; }
            set { experiencePoints = value; }
        }

        public int PlaceId
        {
            get { return placeId; }
            set { placeId = value; }
        }

    }
}
