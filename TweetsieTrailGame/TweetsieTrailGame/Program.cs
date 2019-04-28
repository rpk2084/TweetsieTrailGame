using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class Program
    {
        static void Main(string[] args)
        {

            //ScoreTable.scoreGame();
            Console.WriteLine("Please enter your name");
            String playerName = Console.ReadLine();
            ScoreTable player = new ScoreTable(playerName, 8000);
            ScoreTable.scoreGame(player);
            /*ScoreTable.printScores();
            GolfCart cart = new GolfCart();
            Shopping.Money = 500;
            Console.WriteLine("You have ${0}", Shopping.Money);
            Shopping.goShopping(cart);
            Console.WriteLine(cart.ToString());
            Console.WriteLine("Weather: " + Weather.getWeather());*/
            Console.ReadLine();
        }
    }
}
