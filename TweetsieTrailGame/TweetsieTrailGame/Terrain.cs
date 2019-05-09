using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class Terrain
    {

        //getWeather just uses the built in random class to return a number 1-4. This can later be used to affect health
        public static String getTraining()
        {
            Random rnd = new Random();
            int currentState = rnd.Next(1, 5);
            switch (currentState)
            {
                case 1:
                    return "Flat";
                case 2:
                    return "Bumpy";
                case 3:
                    return "Hilly";
                case 4:
                    return "Treacherous";
                default:
                    return "RandInt Error";

            }
        }
    }
}
