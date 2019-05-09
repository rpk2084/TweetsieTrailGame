using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class Days
    {
        private int day;
        
        public Days()
        {
            day = 0;
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

        

        

        public void addDay()
        {
            Day++;
        }

        /*public void changePace(Days dayCycle)
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
        }*/

        

        public void continueTravel()
        {
            addDay();
            System.Threading.Thread.Sleep(250);
        }
    }
}
