using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    abstract class Combatant
    {
        private int health;
        private int strength;
        private string name;

        public Combatant(int health, int strength, string name)
        {
            this.health = health;
            this.strength = strength;
            this.name = name;
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            set
            {
                this.health = value;
            }
        }
        public int Strength
        {
            get
            {
                return this.strength;
            }
            set
            {
                this.health = value;
            }
        }

        public void attack(Combatant target)
        {
            target.Health -= this.Strength;
        }

        public bool isAlive()
        {
            return this.Health > 0;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
    }
}
