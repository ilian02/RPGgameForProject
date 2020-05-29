using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TextBasedRPGGame.Controllers;
using TextBasedRPGGame.Views;

namespace TextBasedRPGGame.Fights
{
    public static class Fight
    {
        public static Hero startFight(Hero hero, Enemy enemy)
        {
            HeroBusiness hb = new HeroBusiness();

            Console.WriteLine("you fight!");
            Random rand = new Random();

            while (hero.CurrentHealthPoints >= 0 && enemy.CurrentHealthPoints >= 0)
            {
             
                enemy = heroAttack(enemy, hero, rand);

                if (enemy.CurrentHealthPoints <= 0)
                {
                    hero = hero.enemyDied(enemy, hero);
                    break;
                }

                hero = enemyAttack(hero, enemy, rand);

                

                if (hero.CurrentHealthPoints <= 0)
                {
                    hero = hero.heroDied(hero);
                    break;
                }

                

                hb.Update(hero);
            }

            return hero;
        }

        public static Hero enemyAttack(Hero hero, Enemy enemy, Random rand)
        {
            int enemyAttackChance = rand.Next(0, enemy.Accuracy * 2);
            int heroDodgeChance = rand.Next(0, (int)Math.Round((double)hero.Dexterity / 2));

            if (enemyAttackChance > heroDodgeChance)
            {
                EquipmentBusiness eq = new EquipmentBusiness();
                HeroBusiness hb = new HeroBusiness();

                int heroDefencePoints = 0;
                if (eq.GetEquipedByIdAndType(hero.Id, "Armor") != null)
                {
                    heroDefencePoints = (int)eq.GetEquipedByIdAndType(hero.Id, "Armor").Points;
                }

                if (enemy.Strength * 2 - heroDefencePoints > 0)
                {
                    hero.CurrentHealthPoints -= enemy.Strength * 2 - heroDefencePoints;
                    Console.WriteLine(enemy.Name.Trim() + " deals " + (enemy.Strength * 2 - heroDefencePoints) + " damage to " + hero.Name.Trim() + "!");
                    hb.Update(hero);
                }else
                {
                    Console.WriteLine(enemy.Name.Trim() + " can't penetrade " + hero.Name.Trim() + "'s armor!");
                }
                
            }else
            {
                Console.WriteLine(enemy.Name.Trim() + " misses!");
            }

            return hero;
        }

        private static Enemy heroAttack(Enemy enemy, Hero hero, Random rand)
        {
            int heroAttackChance = rand.Next(0, hero.Accuracy * 2);
            int enemyDodgeChance = rand.Next(0, (int)Math.Ceiling((double)enemy.Dexterity / 2));

            if (heroAttackChance > enemyDodgeChance)
            {
                EquipmentBusiness eq = new EquipmentBusiness();

                int heroAttackPoints = hero.Strength;
                if (eq.GetEquipedByIdAndType(hero.Id, "Weapon") != null)
                {
                    heroAttackPoints += (int)eq.GetEquipedByIdAndType(hero.Id, "Weapon").Points;
                }

                enemy.CurrentHealthPoints -= heroAttackPoints;
                Console.WriteLine(hero.Name.Trim() + " deals " + heroAttackPoints + " damage to " + enemy.Name.Trim() + "!");

            }else
            {
                Console.WriteLine(hero.Name.Trim() + " misses!");
            }
            return enemy;
        }
    }
}
