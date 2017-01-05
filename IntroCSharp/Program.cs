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
        public string Name { get { return name; } }
        private int health;
        public int Health { get { return health; } }
        private int attackPower;
        public int AttackPower { get { return attackPower; } }

        public virtual bool Attack(Entity a)
        {
            if (a.Health > 0)
            {
                Random rnd = new Random();
                a.health -= 5 + rnd.Next(0, 5);
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
        }
    }

}
