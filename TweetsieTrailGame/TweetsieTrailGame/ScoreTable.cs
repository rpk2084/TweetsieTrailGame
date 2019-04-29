using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class ScoreTable
    {
        private String name;
        private int score;
        public static String path = Directory.GetCurrentDirectory();
        public static String filePath = Path.GetFullPath(Path.Combine(path, @"..\..\Highscores.txt"));

        public ScoreTable(String sName, int sScore)
        {
            name = sName;
            score = sScore;
        }

        public String Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int Score
        {
            get
            {
                return this.score;
            }
            set
            {
                this.score = value;
            }
        }

        //The printScore method is handy to display scores when testing 
        public static void printScores()
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
                Console.WriteLine(line);
        }

        //addScore just adds the current player object to the highscore file
        public static void addScore(ScoreTable player)
        {
            String scoreLine = (player.Name + "   " + player.Score) + Environment.NewLine;
            File.AppendAllText(filePath, scoreLine);
        }

        //sortScores is the method that actually tells if the current player is top 10 or not and stores the results in the file
        public static void sortScores(ScoreTable[] topTen)
        {
            ScoreTable[] sorted = topTen.OrderByDescending(c => c.Score).ToArray();
            using (StreamWriter writetext = new StreamWriter(filePath))
            {
                for (int i = 0; i < topTen.Length; i++)
                {
                    if (i < 10)
                    {
                        writetext.WriteLine(sorted[i]);
                    }
                }

            }
        }

        //getScores parses the names and scores from each line in the text file, turns them into objects, and returns them via an array
        public static ScoreTable[] getScores()
        {
            String currentLine;
            String score = String.Empty;
            String name = String.Empty;
            int lineCount = File.ReadLines(filePath).Count();
            ScoreTable[] topTen = new ScoreTable[lineCount];
            int counter = 0;
            using (StreamReader file = new StreamReader(filePath))
            {
                while ((currentLine = file.ReadLine()) != null)
                {
                    for (int i = 0; i < currentLine.Length; i++)
                    {
                        if (Char.IsDigit(currentLine[i]))
                            score += currentLine[i];
                    }

                    for (int i = 0; i < currentLine.Length; i++)
                    {
                        if (Char.IsLetter(currentLine[i]))
                            name += currentLine[i];
                    }

                    ScoreTable scorer = new ScoreTable(name, Convert.ToInt32(score));
                    topTen[counter] = scorer;
                    counter++;
                    score = String.Empty;
                    name = String.Empty;
                }
            }
            return topTen;
        }

        //scoreGame is where all of the methods converge to actually decide if the current score fits into the scoreboard
        public static void scoreGame(ScoreTable person)
        {
            addScore(person);
            ScoreTable[] scores = getScores();
            sortScores(scores);
        }

        public override string ToString()
        {
            return Name + "    " + Score;
        }
    }
}
