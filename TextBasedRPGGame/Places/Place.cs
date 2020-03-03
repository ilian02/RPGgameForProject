using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGGame
{
    public class Place
    {
        public List<Enemy> enemyList = new List<Enemy>();
        public List<Item> shopList = new List<Item>();


        public String name { get; set; }
        public bool forge { get; set; }
        public bool bed { get; set; }
        public bool fightEnemy { get; set; }
        public bool shop { get; set; }

        
        public String showPlaceInformation()
        {
            String command = "";

            Console.WriteLine($"You are in {name}");
            Console.WriteLine("-----------------------");
            Console.WriteLine();
            if (forge)
            {
                showForge();
            }
            if (shop)
            {
                showShop();
            }
            if (bed)
            {
                showBed();               
            }
            if (fightEnemy)
            {
                showFightEnemy();
            }

            command = Console.ReadLine().ToLower();
            return command;
        }



        public Place (String name, bool forge, bool bed, bool shop,/*
            */bool enemies, List<Enemy> enemyList, List<Item> shopList)
        {
            this.name = name;
            this.forge = forge;
            this.bed = bed;
            this.shop = shop;
            this.fightEnemy = enemies;
            this.enemyList = enemyList;
            this.shopList = shopList;

        }



        public void showForge()
        {
            Console.WriteLine("Visit (F)orge");
        }
        public void showBed()
        {
            Console.WriteLine("Go to (B)ed");
        }
        public void showFightEnemy()
        {
            Console.WriteLine("Enemies to (F)ight");
        }
        public void showShop()
        {
            Console.WriteLine("Visit (S)hop");
        }




    }



}
