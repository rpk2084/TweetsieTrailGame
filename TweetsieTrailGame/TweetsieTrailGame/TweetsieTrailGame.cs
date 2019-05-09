using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{

    class TweetsieTrailGame
    {
        public static List<EnemyCreateInfo> enemyTypes;
        public static Random rng = new Random();

        private GolfCart cart;
        private Days day;
        private int playerCount;
        private List<Hunter> hunters;
        private Map gameMap;
        private RATIONS rations;
        private PACE pace;
        private int score;
        


        public TweetsieTrailGame(int numPlayers, List<Location> map)
        {
            playerCount = numPlayers;
            hunters = new List<Hunter>();
            cart = new GolfCart();
            day = new Days();
            rations = RATIONS.FILLING;
            pace = PACE.SLOW;
            gameMap = new Map(map);
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

        public Map GameMap
        {
            get
            {
                return this.gameMap;
            }
            set
            {
                this.gameMap = value;
            }
        }
        public int Score
        {
            get
            {
                return this.score + ((100 - Day.Day)+10*hunters.Count());
            }
            set
            {
                this.score = value;
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
            int breakChance = 10 + gameMap.MapList[gameMap.CurrentLocation].BreakChance;
            int fightChance = 10;

            List<string> availableToBreak = new List<string>();
            if (cart.Wheels > 0) availableToBreak.Add("wheel");
            if (cart.Axles > 0) availableToBreak.Add("axle");
            if (cart.Batteries > 0) availableToBreak.Add("battery");

            int randomChoice = rng.Next(0, 100);

            if (availableToBreak.Count > 0 && randomChoice < breakChance)
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
            else if (randomChoice < fightChance + breakChance)
            {
                e = EVENT_TYPE.FIGHT;
            }

            return e;
        }
        
        public bool travel(Func<Map, int> displayForkFunction)
        {
            day.continueTravel();
            int distancePenalty = 0;
            if (cart.Wheels < 4) distancePenalty += 1;
            if (cart.Axles < 2) distancePenalty += 1;
            if (cart.Batteries < 1) distancePenalty += 1;
            GameMap.addDay(distancePenalty);
            bool fork = GameMap.isFork();
            if (fork == true)
            {
                int option = displayForkFunction(GameMap);
                return GameMap.inWildernessFork(option);

            }
            else
            {
                return GameMap.inWilderness();
            }
        }

        public List<Hunter> updateStatus()
        {
            List<Hunter> deadHunters = new List<Hunter>();
            foreach (Hunter hunter in hunters)
            {
                if(hunter.isAlive())
                {
                    if (cart.Food > 0)
                    {
                        hunter.eat(rations);
                        cart.Food -= (int)rations;
                    }
                    else
                    {
                        hunter.starve();
                    }
                }
                else
                {
                    deadHunters.Add(hunter);
                }
            }
            foreach (Hunter deadHunter in deadHunters)
            {
                hunters.Remove(deadHunter);
            }
            return deadHunters;
        }

        private List<Hunter> getLiveHunters()
        {
            List<Hunter> liveHunters = new List<Hunter>();
            foreach(Hunter hunter in hunters)
            {
                if (hunter.isAlive()) liveHunters.Add(hunter);
            }
            return liveHunters;
        }

        public Fight createFight()
        {
            EnemyCreateInfo info = new EnemyCreateInfo("fail", 0, 0, 0, 0);
            bool found = false;
            while(!found)
            {
                EnemyCreateInfo testInfo = TweetsieTrailGame.enemyTypes[rng.Next(0, TweetsieTrailGame.enemyTypes.Count)];
                if(testInfo.Name != "Tweetsieman")
                {
                    info = testInfo;
                    found = true;
                }
            }
            return new Fight(getLiveHunters(), info);
        }

        public void playerWinsFight(Enemy enemy)
        {
            cart.Food += enemy.FoodAmount;
            score += enemy.ScoreValue;
        }

        public Fight createFinalFight()
        {
            EnemyCreateInfo tManInfo = new EnemyCreateInfo("fail", 0, 0, 0, 0);

            foreach(EnemyCreateInfo info in TweetsieTrailGame.enemyTypes)
            {
                if (info.Name == "Tweetsieman")
                {
                    tManInfo = info;
                }
            }

            return new Fight(hunters, tManInfo);
        }
    }
}
