﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGGame.Places
{
    public class Forge
    {

        public Forge()
        {

        }


        public Hero showForgeOptions(Hero hero)
        {
            Console.WriteLine("You entered the forge");
            Console.WriteLine("Pick a weapon to upgrade: ");

            for (int i = 0; i < hero.inventory.count; i++)
            {
                if (hero.inventory.inventory[i].Type == "weapon")
                {
                    Console.WriteLine($"{i + 1}) {((Weapon)hero.inventory.inventory[i]).toString()}");                 
                }
            }

            Console.WriteLine("Enter ID of item or (Q)uit");
            string command = Console.ReadLine();

      
            if (command == "q")
            {
                return hero;
            }

            try
            {
                hero = payingForUpgrade(int.Parse(command) - 1, hero);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine();
                showForgeOptions(hero);
            }

            return hero;
        }


        public Hero payingForUpgrade(int weaponNumber, Hero hero)
        {

            Console.WriteLine("Do you will to upgrade this weapon for " + ((Weapon)hero.inventory.inventory[weaponNumber]).SellPrice + " gold?");
            Console.WriteLine("(Y)es or (N)o");
            Console.WriteLine("(Q)uit to show");

            string command = Console.ReadLine().ToLower();

            if (command == "n")
            {
                Console.Clear();
                hero = showForgeOptions(hero);
            }
            else if (command == "y" && hero.Money >= ((Weapon)hero.inventory.inventory[weaponNumber]).SellPrice / 2)
            {
                    Console.Clear();
                    hero.Money -= hero.inventory.inventory[weaponNumber].SellPrice / 2;
                    ((Weapon)hero.inventory.inventory[weaponNumber]).AttackPoints += 1 + (int)Math.Floor((double)((Weapon)hero.inventory.inventory[weaponNumber]).AttackPoints / 2);
                    ((Weapon)hero.inventory.inventory[weaponNumber]).Name = ((Weapon)hero.inventory.inventory[weaponNumber]).Name + "*";
                    ((Weapon)hero.inventory.inventory[weaponNumber]).SellPrice *= 2;
                    Console.WriteLine("You upgraded your weapon!");
                    Console.WriteLine("Current money balance: " + hero.Money);
                    Console.WriteLine();
                    hero = showForgeOptions(hero);
            }
            else if (command == "y" && hero.Money < ((Weapon)hero.inventory.inventory[weaponNumber]).SellPrice / 2)
            {
                Console.Clear();
                Console.WriteLine("You don't have enough money for this action!");
                hero = showForgeOptions(hero);
            }else if (command == "q")
            {
                return hero;
            }

            return hero;
        }

    }
}
