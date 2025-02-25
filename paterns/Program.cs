using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paterns
{
    public enum Difficulty
    {
        Easy,
        Normal,
        Hard
    }
    public abstract class Enemy
    {
        public int Health { get; protected set; }
        public int Damage { get; protected set; }

        public virtual void Attack()
        {
            Console.WriteLine($"{GetType().Name} attacks for {Damage} damage!");
        }
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"{GetType().Name} - Health: {Health}, Damage: {Damage}");
        }
    }
    public class Zombie : Enemy
    {
        public Zombie(Difficulty difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    Health = 100;
                    Damage = 10;
                    break;
                case Difficulty.Normal:
                    Health = 150;
                    Damage = 15;
                    break;
                case Difficulty.Hard:
                    Health = 250;
                    Damage = 25;
                    break;
            }
        }
        public override void Attack()
        {
            Console.WriteLine($"Zombie slowly approaches and bites for {Damage} damage!");
        }
    }
    public class Skeleton : Enemy
    {
        public Skeleton(Difficulty difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    Health = 80;
                    Damage = 15;
                    break;
                case Difficulty.Normal:
                    Health = 120;
                    Damage = 20;
                    break;
                case Difficulty.Hard:
                    Health = 180;
                    Damage = 30;
                    break;
            }
        }

        public override void Attack()
        {
            Console.WriteLine($"Skeleton shoots an arrow for {Damage} damage!");
        }
    }
    public abstract class EnemyFactory
    {
        public abstract Enemy CreateEnemy(Difficulty difficulty);
    }
    public class ZombieFactory : EnemyFactory
    {
        public override Enemy CreateEnemy(Difficulty difficulty)
        {
            return new Zombie(difficulty);
        }
    }

    public class SkeletonFactory : EnemyFactory
    {
        public override Enemy CreateEnemy(Difficulty difficulty)
        {
            return new Skeleton(difficulty);
        }
    }
    public class Game
    {
        public static void Main()
        {
            EnemyFactory zombieFactory = new ZombieFactory();
            EnemyFactory skeletonFactory = new SkeletonFactory();
            Console.WriteLine("Easy Difficulty Enemies:");
            Enemy easyZombie = zombieFactory.CreateEnemy(Difficulty.Easy);
            Enemy easySkeleton = skeletonFactory.CreateEnemy(Difficulty.Easy);
            easyZombie.DisplayInfo();
            easySkeleton.DisplayInfo();
            Console.WriteLine("\nNormal Difficulty Enemies:");
            Enemy normalZombie = zombieFactory.CreateEnemy(Difficulty.Normal);
            Enemy normalSkeleton = skeletonFactory.CreateEnemy(Difficulty.Normal);
            normalZombie.DisplayInfo();
            normalSkeleton.DisplayInfo();
            Console.WriteLine("\nHard Difficulty Enemies:");
            Enemy hardZombie = zombieFactory.CreateEnemy(Difficulty.Hard);
            Enemy hardSkeleton = skeletonFactory.CreateEnemy(Difficulty.Hard);
            hardZombie.DisplayInfo();
            hardSkeleton.DisplayInfo();
            Console.WriteLine("\nEnemy Attacks:");
            easyZombie.Attack();
            normalSkeleton.Attack();
            hardZombie.Attack();
            Console.WriteLine("\nAdding a new enemy type would be simple:");
            Console.WriteLine("1. Create a new Ghost class inheriting from Enemy");
            Console.WriteLine("2. Create a new GhostFactory inheriting from EnemyFactory");
            Console.WriteLine("3. Use the factory to create instances as needed");
        }
    }
}
