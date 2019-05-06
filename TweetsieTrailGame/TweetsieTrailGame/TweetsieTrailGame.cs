using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{

    class TweetsieTrailGame
    {
        private GolfCart cart;
        private Days day;
        private int playerCount;
        private List<Hunter> hunters;


        public TweetsieTrailGame(int numPlayers)
        {
            playerCount = numPlayers;
            hunters = new List<Hunter>();
            cart = new GolfCart();
        }

        public GolfCart Cart
        {
            get
            {
                return cart;
            }
            set
            {
                cart = value;
            }
        }

        public Days Day
        {
            get
            {
                return day;
            }
            set
            {
                day = value;
            }
        }

        public int PlayerCount
        {
            get
            {
                return playerCount;
            }
        }

        public List<Hunter> Hunters
        {
            get
            {
                return hunters;
            }
            set
            {
                hunters = value;
            }
        }

        public void addHunter(string name, HunterJobInfo jobInfo)
        {
            hunters.Add(new Hunter(jobInfo.Health, jobInfo.Strength, name, jobInfo.ScoreMultiplier));
            cart.Money += jobInfo.StartingMoney;
        }
    }
}
