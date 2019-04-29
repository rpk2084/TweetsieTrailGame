using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class HunterJobInfo
    {
        private string name;
        private int health;
        private int strength;
        private int scoreMultiplier;
        private int startingMoney;

        public HunterJobInfo(string name, int health, int strength, int scoreMultiplier, int startingMoney)
        {
            this.name = name;
            this.health = health;
            this.strength = strength;
            this.scoreMultiplier = scoreMultiplier;
            this.startingMoney = startingMoney;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Health
        {

        }
    }
}
