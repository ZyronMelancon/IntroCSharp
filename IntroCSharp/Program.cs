using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IntroCSharp
{
    public class Entity
    {
        public Entity() { }
        public Entity(int h, int att)
        {
            health = h;
            attackPower = att;
        }

        private string name;
        public string Name { get { return name; } set { name = value; } }
        private int health;
        public int Health { get { return health; } set { health = value; } }
        private int attackPower;
        public int AttackPower { get { return attackPower; } set { attackPower = value; } }

        public virtual bool Attack(Entity a)
        {
            if (a.Health > 0)
            {
                a.Health -= AttackPower;
                return true;
            }
            else
            {
                return false;
            }
        }



    }

    public class Zombie : Entity
    {
        public Zombie() { }
        public Zombie(int h, int s) : base(h,s) { }

        public override bool Attack(Entity a)
        {
            return base.Attack(a);
        }

    }

    public class Player : Entity
    {
        public Player() { }
        public Player(int h, int s) : base(h,s) { }
        public override bool Attack(Entity a)
        {
            return base.Attack(a);           
        }
        public virtual bool Defend() { return false; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Player ninja = new Player();
            ninja.AttackPower = 10;
            ninja.Health = 100;
            ninja.Name = "Player";

            Zombie zambie = new Zombie();
            zambie.Health = 50;
            zambie.AttackPower = 10;
            zambie.Name = "Zambie";

            while (true)
            {
                Console.Clear();
                Console.WriteLine(ninja.Name + " VS " + zambie.Name + "\n");
                Console.WriteLine(ninja.Name + "'s health: " + ninja.Health);
                Console.WriteLine(zambie.Name + "'s health: " + zambie.Health);

                //Checks deaths before next turn

                if (ninja.Health <= 0)
                {
                    Console.WriteLine("You died!");
                    break;
                }
                else if (zambie.Health <= 0)
                {
                    Console.WriteLine(ninja.Name + " defeated " + zambie.Name);
                    break;
                }


                //Battle Phase
                Console.WriteLine("Choose an action!");
                Console.WriteLine("1. Attack  2. Defend");

                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    ninja.Attack(zambie);
                    Console.WriteLine(ninja.Name + " attacked " + zambie.Name + " with " + ninja.AttackPower + " damage!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    zambie.Attack(ninja);
                    Console.WriteLine(zambie.Name + " attacked " + ninja.Name + " with " + zambie.AttackPower + " damage!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else if (choice == 2)
                {
                    Console.WriteLine(ninja.Name + " defends himself! Damage is halved!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    zambie.Attack(ninja);
                    ninja.Health = ninja.Health + zambie.AttackPower / 2;
                    Console.WriteLine(zambie.Name + " attacked " + ninja.Name + " with " + zambie.AttackPower/2 + " damage!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Invalid choice!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }

            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
    }

}
