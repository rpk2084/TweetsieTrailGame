using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class EnemyCreateInfo
    {
        public EnemyCreateInfo(string name, int health, int strength, int foodAmount, int scoreValue)
        {
            Name = name;
            Health = health;
            Strength = strength;
            FoodAmount = foodAmount;
            ScoreValue = scoreValue;
        }

        public string Name { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int FoodAmount { get; set; }
        public int ScoreValue { get; set; }
        
    }
}
