using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class Location
    {
        private string name;
        private int distance;
        private bool stop;
        private int breakChance;
        private int next;

        public Location(string sName, int sDistance, bool sStop, int sBreakChance, int sNext)
        {
            this.name = sName;
            this.distance = sDistance;
            this.stop = sStop;
            this.breakChance = sBreakChance;
            this.next = sNext;
        }
    }
}
