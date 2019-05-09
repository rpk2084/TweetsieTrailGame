using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class Score
    {
        string name;
        int value;

        public Score(string name, int score)
        {
            this.name = name;
            this.value = score;
        }

        public int Value
        {
            get
            {
                return value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }
    }

    class ScoreTable
    {
        public List<Score> Scores { get; set; }

        public ScoreTable()
        {
            Scores = new List<Score>();
        }

        public ScoreTable(List<Score> scores)
        {
            this.Scores = scores;
        }

        public void addScore(string newName, int newScore)
        {
            Scores.Add(new Score(newName, newScore));
            Scores.Sort((x, y) => x.Value.CompareTo(y.Value));
        }
    }
}
