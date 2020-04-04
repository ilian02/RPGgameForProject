using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TextBasedRPGGame.Views;

namespace TextBasedRPGGame.Fights
{
    public static class Fight
    {
        public static Hero startFight(Hero hero, Enemy enemy)
        {
            while(hero.CurrentHealthPoints > 0 && enemy.CurrentHealthPoints > 0)
            {

                Console.WriteLine("Hero attacks: ");
                enemy = enemyGetAttacked(hero, enemy);
                Console.WriteLine("Enemy attacks: ");
                hero = heroGetAttacked(hero, enemy);
                Console.WriteLine();

                Thread.Sleep(3000);

                if (hero.CurrentHealthPoints <= 0)
                {
                    Console.WriteLine("You lost");
                    hero = CharacterInfo.heroDied(hero);
                    break;
                }

                if (enemy.CurrentHealthPoints <= 0)
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

            if (enemy.Dexterity < hero.Dexterity)
            {
                if (rand.Next(11) > enemy.Dexterity - hero.Dexterity)
                {
                    enemy.CurrentHealthPoints -= hero.Strength * 2 + hero.Weapon.AttackPoints;
                    Console.WriteLine($"{enemy.Name} lost {hero.Strength * 2 + hero.Weapon.AttackPoints}");
                }
                else Console.WriteLine($"{hero.Name} missed!");
            }
            else if (enemy.Dexterity > hero.Dexterity)
            {
                if (rand.Next(6) > hero.Dexterity - enemy.Dexterity)
                {
                    enemy.CurrentHealthPoints -= hero.Strength * 2 + hero.Weapon.AttackPoints;
                    Console.WriteLine($"{hero.Name} lost {hero.Strength * 2 + hero.Weapon.AttackPoints}");
                }
                else Console.WriteLine($"{enemy.Name} missed!");
            }
            else
            {
                if (rand.Next(2) == 1)
                {
                    enemy.CurrentHealthPoints -= enemy.Strength * 2;
                    Console.WriteLine($"{enemy.Name} lost {hero.Strength * 2 + hero.Weapon.AttackPoints}");
                }
                else Console.WriteLine($"{hero.Name} missed!");
            }


            return enemy;
        }

        public static Hero heroGetAttacked(Hero hero, Enemy enemy)
        {

            Random rand = new Random();

            if (enemy.Strength * 2 < hero.Armor.DefencePoints)
            {
                Console.WriteLine($"{enemy.Name} coundn't penetrate {hero.Name}'s armor");
                return hero;
            }

            if (enemy.Dexterity > hero.Dexterity)
            {
                if (rand.Next(11) > enemy.Dexterity - hero.Dexterity)
                {
                    hero.CurrentHealthPoints -= enemy.Strength * 2 - hero.Armor.DefencePoints;
                    Console.WriteLine($"{hero.Name} lost {enemy.Strength * 2 - hero.Armor.DefencePoints}");
                }
                else Console.WriteLine($"{enemy.Name} missed!");
            }
            else if (enemy.Dexterity < hero.Dexterity)
            {
                if (rand.Next(6) > hero.Dexterity - enemy.Dexterity)
                {
                    hero.CurrentHealthPoints -= enemy.Strength * 2 - hero.Armor.DefencePoints;
                    Console.WriteLine($"{hero.Name} lost {enemy.Strength * 2 - hero.Armor.DefencePoints}");
                }
                else Console.WriteLine($"{enemy.Name} missed!");
            }
            else
            {
                if (rand.Next(2) == 1)
                {
                    hero.CurrentHealthPoints -= enemy.Strength * 2 - hero.Armor.DefencePoints;
                    Console.WriteLine($"{hero.Name} lost {enemy.Strength * 2 - hero.Armor.DefencePoints}");
                }
                else Console.WriteLine($"{enemy.Name} missed!");
            }
    
            return hero;
        }

    }
}
