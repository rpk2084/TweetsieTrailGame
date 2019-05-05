using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class Hunter : Combatant
    {
        private int scoreMultiplier;
        public Hunter(int health, int strength, string name, int scoreMultiplier) : base(health, strength, name)
        {
            this.scoreMultiplier = scoreMultiplier;
        }

        public int ScoreMultiplier
        {
            get
            {
                return this.scoreMultiplier;
            }
        }
    }
}
