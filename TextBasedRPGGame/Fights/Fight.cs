using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TextBasedRPGGame.Fights
{
    public static class Fight
    {
        public static Hero startFight(Hero hero, Enemy enemy)
        {
            while(hero.currentHealthPoints > 0 && enemy.currentHealthPoints > 0)
            {

                Console.WriteLine("Hero attacks: ");
                enemy = enemyGetAttacked(hero, enemy);
                Console.WriteLine("Enemy attacks: ");
                hero = heroGetAttacked(hero, enemy);
                Console.WriteLine();

                Thread.Sleep(3000);

                if (hero.currentHealthPoints <= 0)
                {
                    Console.WriteLine("You lost");
                    hero.heroDied();
                    break;
                }

                if (enemy.currentHealthPoints <= 0)
                {
                    hero.enemyDied(enemy);
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            return hero;
        }


        public static Enemy enemyGetAttacked(Hero hero,Enemy enemy)
        {
            Random rand = new Random();

            if (enemy.dexterity < hero.dexterity)
            {
                if (rand.Next(11) > enemy.dexterity - hero.dexterity)
                {
                    enemy.currentHealthPoints -= hero.strength * 2 + hero.weapon.attackPoints;
                    Console.WriteLine($"{enemy.name} lost {hero.strength * 2 + hero.weapon.attackPoints}");
                }
                else Console.WriteLine($"{hero.name} missed!");
            }
            else if (enemy.dexterity > hero.dexterity)
            {
                if (rand.Next(6) > hero.dexterity - enemy.dexterity)
                {
                    enemy.currentHealthPoints -= hero.strength * 2 + hero.weapon.attackPoints;
                    Console.WriteLine($"{hero.name} lost {hero.strength * 2 + hero.weapon.attackPoints}");
                }
                else Console.WriteLine($"{enemy.name} missed!");
            }
            else
            {
                if (rand.Next(2) == 1)
                {
                    enemy.currentHealthPoints -= enemy.strength * 2;
                    Console.WriteLine($"{enemy.name} lost {hero.strength * 2 + hero.weapon.attackPoints}");
                }
                else Console.WriteLine($"{hero.name} missed!");
            }


            return enemy;
        }

        public static Hero heroGetAttacked(Hero hero, Enemy enemy)
        {

            Random rand = new Random();

            if (enemy.strength * 2 < hero.armor.defencePoints)
            {
                Console.WriteLine($"{enemy.name} coundn't penetrate {hero.name}'s armor");
                return hero;
            }

            if (enemy.dexterity > hero.dexterity)
            {
                if (rand.Next(11) > enemy.dexterity - hero.dexterity)
                {
                    hero.currentHealthPoints -= enemy.strength * 2 - hero.armor.defencePoints;
                    Console.WriteLine($"{hero.name} lost {enemy.strength * 2 - hero.armor.defencePoints}");
                }
                else Console.WriteLine($"{enemy.name} missed!");
            }
            else if (enemy.dexterity < hero.dexterity)
            {
                if (rand.Next(6) > hero.dexterity - enemy.dexterity)
                {
                    hero.currentHealthPoints -= enemy.strength * 2 - hero.armor.defencePoints;
                    Console.WriteLine($"{hero.name} lost {enemy.strength * 2 - hero.armor.defencePoints}");
                }
                else Console.WriteLine($"{enemy.name} missed!");
            }
            else
            {
                if (rand.Next(2) == 1)
                {
                    hero.currentHealthPoints -= enemy.strength * 2 - hero.armor.defencePoints;
                    Console.WriteLine($"{hero.name} lost {enemy.strength * 2 - hero.armor.defencePoints}");
                }
                else Console.WriteLine($"{enemy.name} missed!");
            }
    
            return hero;
        }

    }
}
