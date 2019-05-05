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
        private double scoreMultiplier;
        private int startingMoney;

        public HunterJobInfo(string name, int health, int strength, double scoreMultiplier, int startingMoney)
        {
            this.name = name;
            this.health = health;
            this.strength = strength;
            this.scoreMultiplier = scoreMultiplier;
            this.startingMoney = startingMoney;
        }
        public HunterJobInfo()
        {
            this.name = null;
            this.health = 0;
            this.strength = 0;
            this.scoreMultiplier = 0;
            this.startingMoney = 0;
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
            get
            {
                return this.Health;
            }
        }

        public int Money
        {
            get
            {
                return this.startingMoney;
            }
            set
            {
                this.startingMoney = value;
            }
        }
    }
}
