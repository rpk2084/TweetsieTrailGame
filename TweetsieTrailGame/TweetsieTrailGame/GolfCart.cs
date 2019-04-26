﻿using System;
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

        public GolfCart()
        {
            wheels = 4;
            batteries = 1;
            axles = 2;
        }

        public GolfCart(int sWheel, int sBattery, int sAxle)
        {
            wheels = sWheel;
            batteries = sBattery;
            axles = sAxle;
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
    }
}
