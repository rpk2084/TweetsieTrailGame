using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class Map
    {
        private int totalDistance = 400;
        private int distance;
        private List<Location> mapList;
        private int currentLocation;
        public Map(List<Location> sMapList)
        {
            mapList = sMapList;
            distance = 0;
            currentLocation = 0;
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
    }
}
