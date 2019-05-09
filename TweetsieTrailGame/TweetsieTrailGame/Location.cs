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
        private int secondNext;

        public Location(string sName, int sDistance, bool sStop, int sBreakChance)
        {
            this.name = sName;
            this.distance = sDistance;
            this.stop = sStop;
            this.breakChance = sBreakChance;
            this.next = null;
            this.secondNext = null;
        }

        public string Name
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
                return this.Next;
            }
            set
            {
                this.Next = value;
            }
        }

        public int SecondNext
        {
            get
            {
                return this.secondNext;
            }
            set
            {
                this.secondNext = value;
            }
        }

    }
}
