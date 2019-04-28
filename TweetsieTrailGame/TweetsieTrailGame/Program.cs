﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create golf cart object so starting materials can be applied
            GolfCart cart = new GolfCart();

            //Get the player's info so the game can continually update score
            Console.WriteLine("Please enter your name");
            String playerName = Console.ReadLine();
            ScoreTable player = new ScoreTable(playerName, 0);
            
            //Set the player's money (may later be dependent on a "class") and start shopping
            Shopping.Money = 500;
            Console.WriteLine("You have ${0}", Shopping.Money);
            Shopping.goShopping(cart);

            //Display the current weather. getWeather can be used to get a new random condition every day
            Console.WriteLine("Weather: " + Weather.getWeather());

            //When the game is over, collect the score. If top ten, it will be added to the highscores
            ScoreTable.scoreGame(player);
            Console.ReadLine();
        }
    }
}
