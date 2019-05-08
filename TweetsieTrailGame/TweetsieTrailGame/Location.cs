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

        public String Name
        {
            get
            {
                return this.name;
            }
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
        public bool Stop
        {
            get
            {
                return this.stop;
            }
            set
            {
                this.stop = value;
            }
        }
        public int BreakChance
        {
            get
            {
                return this.breakChance;
            }
            set
            {
                this.breakChance = value;
            }
        }
        public int Next
        {
            get
            {
                return this.next;
            }
            set
            {
                this.next = value;
            }
        }
    }
}
