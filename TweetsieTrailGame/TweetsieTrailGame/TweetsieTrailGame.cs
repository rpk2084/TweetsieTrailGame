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
        private RATIONS rations;
        private PACE pace;


        public TweetsieTrailGame(int numPlayers)
        {
            playerCount = numPlayers;
            hunters = new List<Hunter>();
            cart = new GolfCart();
            day = new Days();
            rations = RATIONS.FILLING;
            pace = PACE.SLOW;
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

        public EVENT_TYPE randomEvent()
        {
            EVENT_TYPE e = EVENT_TYPE.NO_EVENT;

            //These should come from elsewhere eventually
            int breakChance = 20;
            int fightChance = 20;

            Random rng = new Random();
            List<string> availableToBreak = new List<string>();
            if (cart.Wheels > 0) availableToBreak.Add("wheel");
            if (cart.Axles > 0) availableToBreak.Add("axle");
            if (cart.Batteries > 0) availableToBreak.Add("battery");

            if (availableToBreak.Count > 0 && rng.Next(0, 100) < breakChance)
            {
                switch (availableToBreak[rng.Next(0, availableToBreak.Count)])
                {
                    case "axle":
                        cart.breakAxle();
                        e = EVENT_TYPE.BREAK_AXLE;
                        break;
                    case "wheel":
                        cart.breakWheel();
                        e = EVENT_TYPE.BREAK_WHEEL;
                        break;
                    case "battery":
                        cart.breakBattery();
                        e = EVENT_TYPE.BREAK_BATTERY;
                        break;
                }
            }
            else if (rng.Next(0, 100) < fightChance)
            {
                e = EVENT_TYPE.FIGHT;
            }

            return e;
        }
        
        public void travel()
        {
            //Need location class to be implemented before this can do anyting @Jarod Blazo
        }

        public void updateStatus()
        {
            foreach(Hunter hunter in hunters)
            {
                if(hunter.isAlive())
                {
                    hunter.eat(rations);
                    cart.Food -= (int)rations;
                }
            }
        }
    }
}
