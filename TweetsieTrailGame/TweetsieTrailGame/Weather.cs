using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class Weather
    {

        //getWeather just uses the built in random class to return a number 1-4. This can later be used to affect health
        public static String getWeather()
        {
            Random rnd = new Random();
            int currentState = rnd.Next(1, 5);
            switch (currentState)
            {
                case 1:
                    return "Great";
                case 2:
                    return "Fair";
                case 3:
                    return "Poor";
                case 4:
                    return "Very Poor";
                default:
                    return "RandInt Error";

            }
        }
    }
}
