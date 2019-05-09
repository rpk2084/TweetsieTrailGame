using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class Map
    {
        private int distance;
        private List<Location> mapList;
        private int currentLocation;
        private int pace;
        public Map(List<Location> sMapList)
        {
            mapList = sMapList;
            distance = 0;
            currentLocation = 0;
            pace = 1;
        }

        public int Distance
        {
            get
            {
                return this.distance;
            }
            set
            {
                this.distance = value;
            }
        }

        public int Pace
        {
            get
            {
                return this.pace;
            }
            set
            {
                this.pace = value;
            }
        }

        public bool atLocation()
        {
            Location currentPlace = mapList[currentLocation];
            Location nextPlace = mapList[currentPlace.Next];
            if (Distance >= nextPlace.Distance)
            {
                Distance = nextPlace.Distance;
                currentLocation = currentPlace.Next;
                return true;
            }
            else
            {
                return false;
            }
           
        }
        public void calculateDailyDistance()
        {
            switch (Pace)
            {
                case 1:
                    Distance = Distance + 20;
                    break;
                case 2:
                    Distance = Distance + 25;
                    break;
                case 3:
                    Distance = Distance + 30;
                    break;
                case 4:
                    Distance = Distance + 35;
                    break;
            }
        }

        public void addDay()
        {
            calculateDailyDistance();
        }
    }
}
