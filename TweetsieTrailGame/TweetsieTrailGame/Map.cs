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

        public List<Location> MapList
        {
            get
            {
                return this.mapList;
            }
            set
            {
                this.mapList = value;
            }
        }

        public int CurrentLocation
        {
            get
            {
                return this.currentLocation;
            }
            set
            {
                this.currentLocation = value;
            }
        }
        public bool inWildernessFork(int option)
        {
            Location currentPlace = mapList[currentLocation];
            switch (option)
            {
                case 1:
                    if (currentPlace.Next != 15)
                    {
                        Location nextPlace = mapList[currentPlace.Next];
                        if (Distance >= nextPlace.Distance)
                        {
                            Distance = nextPlace.Distance;
                            currentLocation = currentPlace.Next;
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        Distance = currentPlace.Distance;
                        return false;
                    }
                case 2:
                    if (currentPlace.SecondNext != 15)
                    {
                        Location nextPlace = mapList[currentPlace.SecondNext];
                        if (Distance >= nextPlace.Distance)
                        {
                            Distance = nextPlace.Distance;
                            currentLocation = currentPlace.SecondNext;
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return true;
            }
        }
        public bool inWilderness()
        {
            Location currentPlace = mapList[currentLocation];
            if (currentPlace.Next != 15)
            {
                Location nextPlace = mapList[currentPlace.Next];
                if (Distance >= nextPlace.Distance)
                {
                    Distance = nextPlace.Distance;
                    currentLocation = currentPlace.Next;
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
            
        }

        public bool isFork()
        {
            if (MapList[CurrentLocation].SecondNext == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void calculateDailyDistance()
        {
            switch (Pace)
            {
                case 1:
                    Distance = Distance + 10;
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
