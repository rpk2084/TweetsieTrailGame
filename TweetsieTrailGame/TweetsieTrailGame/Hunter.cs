using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class Hunter : Combatant
    {
        private double scoreMultiplier;
        private int maxHealth;

        public Hunter(int health, int strength, string name, double scoreMultiplier) : base(health, strength, name)
        {
            this.scoreMultiplier = scoreMultiplier;
            this.maxHealth = health;
        }

        public double ScoreMultiplier
        {
            get
            {
                return scoreMultiplier;
            }
        }

        public int MaxHealth
        {
            get
            {
                return maxHealth;
            }
        }

        public void eat(RATIONS food)
        {
            Health += (int)food;
            if (Health > maxHealth)
            {
                Health = maxHealth;
            }
        }
    }
}
