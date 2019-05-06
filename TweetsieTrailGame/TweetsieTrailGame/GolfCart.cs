using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class GolfCart
    {
        private int wheels;
        private int batteries;
        private int axles;
        private int money;
        private int food;

        public GolfCart()
        {
            wheels = 4;
            batteries = 1;
            axles = 2;
            money = 0;
            food = 0;
        }

        //Future note: this format is what is needed to override a method in c#
        public override String ToString()
        {
            return "\nWheels left: " + Wheels + "\nAxles left: " + Axles + "\nBatteries left: " + Batteries;
        }

        public int Wheels
        {
            get
            {
                return this.wheels;
            }

            set
            {
                this.wheels = value;
            }
        }

        public int Axles
        {
            get
            {
                return this.axles;
            }

            set
            {
                this.axles = value;
            }
        }

        public int Batteries
        {
            get
            {
                return this.batteries;
            }

            set
            {
                this.batteries = value;
            }
        }

        public int Money
        {
            get
            {
                return this.money;
            }
            set
            {
                this.money = value;
            }
        }
        public int Food
        {
            get
            {
                return this.food;
            }
            set
            {
                this.food = value;
            }
        }
    }
}
