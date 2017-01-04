using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IntroCSharp
{
    class Entity
    {
        public Entity() { }
        public Entity(int h, int att)
        {

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
                return true;
            }
            else
            {
                return false;
            }
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
