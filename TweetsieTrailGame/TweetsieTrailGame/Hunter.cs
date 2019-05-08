using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class Hunter : Combatant
    {
        private double scoreMultiplier;
        public Hunter(int health, int strength, string name, double scoreMultiplier) : base(health, strength, name)
        {
            this.scoreMultiplier = scoreMultiplier;
        }

        public double ScoreMultiplier
        {
            get
            {
                return this.scoreMultiplier;
            }
        }

        public void eat(RATIONS food)
        {
            Health += (int)food;
        }
    }
}
