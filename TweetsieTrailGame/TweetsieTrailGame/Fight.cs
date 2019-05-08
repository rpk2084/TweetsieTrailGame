﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    enum FIGHT_STATUS
    {
        ONGOING,
        PLAYER_WINS,
        ENEMY_WINS,
    }

    class Fight
    {
        private List<Hunter> hunters;
        private Enemy enemy;
        private Random rng;

        public Fight(List<Hunter> hunters, EnemyCreateInfo enemyInfo)
        {
            this.hunters = hunters;
            enemy = new Enemy(enemyInfo);
            rng = new Random();
        }

        public FIGHT_STATUS fightRound()
        {
            FIGHT_STATUS status = FIGHT_STATUS.ONGOING;
            enemy.attack(hunters[rng.Next(0, hunters.Count)]);
            foreach(Hunter hunter in hunters)
            {
                if(hunter.isAlive()) hunter.attack(enemy);
            }

            return status;
        }

        private bool playersAlive()
        {
            bool alive = false;
            foreach(Hunter hunter in hunters)
            {
                if(hunter.isAlive())
                {
                    alive = true;
                    break;
                }
            }
            return alive;
        }
    }
}
