using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class Days
    {
        private int day;
        private int distance;
        private int pace;
        public const int totalDistance = 400;
        public Days()
        {
            day = 0;
            distance = 0;
            pace = 1;
        }

        public int Day
        {
            get
            {
                return this.day;
            }
            set
            {
                this.day = value;
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

        public void addDay()
        {
            Day++;
        }

        public static void changePace(Days dayCycle)
        {
            Console.WriteLine("Enter numbers 1-4 to set the pace accordingly. 1 being the slowest and 4 being the fastest");
            int setPace = Convert.ToInt32(Console.ReadLine());
            switch (setPace)
            {
                case 1:
                    dayCycle.Pace = setPace;
                    break;
                case 2:
                    dayCycle.Pace = setPace;
                    break;
                case 3:
                    dayCycle.Pace = setPace;
                    break;
                case 4:
                    dayCycle.Pace = setPace;
                    break;
                default:
                    Console.WriteLine("Please enter a valid number between 1 and 4");
                    changePace(dayCycle);
                    break;
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

        public void continueTravel()
        {
            Console.WriteLine("Press any key to stop traveling");
            while (Console.KeyAvailable == false)
            {
                addDay();
                calculateDailyDistance();
                Console.WriteLine(Day);
                System.Threading.Thread.Sleep(250);
            }
        }
    }
}
