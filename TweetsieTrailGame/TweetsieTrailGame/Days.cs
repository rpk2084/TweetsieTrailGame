using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class Days
    {
        public static int day;
        public static int distance;
        public static int pace;
        public const int totalDistance = 400;
        /*public Days()
        {
            day = 0;
            distance = 0;
            pace = 1;
        }*/

        public static int Day
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

        public static int Distance
        {
            get
            {
                return distance;
            }
            set
            {
                distance = value;
            }
        }

        public static int Pace
        {
            get
            {
                return pace;
            }
            set
            {
                pace = value;
            }
        }

        public static void addDay()
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
                    Pace = setPace;
                    break;
                case 2:
                    Pace = setPace;
                    break;
                case 3:
                    Pace = setPace;
                    break;
                case 4:
                    Pace = setPace;
                    break;
                default:
                    Console.WriteLine("Please enter a valid number between 1 and 4");
                    changePace(dayCycle);
                    break;
            }
        }

        public static void calculateDailyDistance()
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

        public static void continueTravel()
        {
            addDay();
            calculateDailyDistance();
            System.Threading.Thread.Sleep(250);
        }
    }
}
