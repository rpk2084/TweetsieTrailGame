using System;
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

        public Enemy Enemy
        {
            get
            {
                return enemy;
            }
        }

        public List<Hunter> Hunters
        {
            get
            {
                return hunters;
            }
        }

        public FIGHT_STATUS fightRound()
        {
            FIGHT_STATUS status = FIGHT_STATUS.ONGOING;
            List<Hunter> liveHunters = getLiveHunters();
            enemy.attack(liveHunters[rng.Next(0, liveHunters.Count)]);
            liveHunters = getLiveHunters();
            if (liveHunters.Count > 0)
            {
                foreach (Hunter hunter in liveHunters)
                {
                    hunter.attack(enemy);
                }
                if(!enemy.isAlive())
                {
                    status = FIGHT_STATUS.PLAYER_WINS;
                }
            }
            else
            {
                status = FIGHT_STATUS.ENEMY_WINS;
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

        private List<Hunter> getLiveHunters()
        {
            List<Hunter> liveHunters = new List<Hunter>();
            foreach(Hunter hunter in hunters)
            {
                if(hunter.isAlive())
                {
                    liveHunters.Add(hunter);
                }
            }
            return liveHunters;
        }

    }
}
