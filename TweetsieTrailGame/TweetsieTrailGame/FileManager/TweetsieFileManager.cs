using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class TweetsieFileManager : IFileManager
    {
        private IFileFormatter formatter;
        private IFileParser parser;

        public TweetsieFileManager(IFileParser parser, IFileFormatter formatter)
        {
            this.parser = parser;
            this.formatter = formatter;
        }

        public List<EnemyCreateInfo> loadEnemyTypes()
        {
            List<EnemyCreateInfo> enemyCreateInfos = new List<EnemyCreateInfo>();
            ObjectList objList = parser.parseFile("Enemies");

            int healthColumn = objList.HeaderRow.IndexOf("Health");
            int strengthColumn = objList.HeaderRow.IndexOf("Strength");
            int nameColumn = objList.HeaderRow.IndexOf("Name");
            int foodColumn = objList.HeaderRow.IndexOf("Food");
            int scoreColumn = objList.HeaderRow.IndexOf("ScoreValue");

            foreach(List<string> enemy in objList.ObjectRows)
            {
                enemyCreateInfos.Add(new EnemyCreateInfo(enemy[nameColumn], int.Parse(enemy[healthColumn]), int.Parse(enemy[strengthColumn]),
                    int.Parse(enemy[foodColumn]), int.Parse(enemy[scoreColumn])));
            }
            return enemyCreateInfos;
        }

        public List<HunterJobInfo> loadHunterJobsInfos()
        {
            throw new NotImplementedException();
        }

        public List<Location> loadLocations()
        {
            List<Location> locations = new List<Location>();
            ObjectList objList = parser.parseFile("Locations");
            //Location Distance    Stop? Breakchance     Next Second Next
            int nameColumn = objList.HeaderRow.IndexOf("Location");
            int distanceColumn = objList.HeaderRow.IndexOf("Distance");
            int stopColumn = objList.HeaderRow.IndexOf("Stop?");
            int breakColumn = objList.HeaderRow.IndexOf("BreakChance");
            int nextColumn = objList.HeaderRow.IndexOf("Next");
            int secondColumn = objList.HeaderRow.IndexOf("Distance");
        }

        public ScoreTable loadScoreTable()
        {
            throw new NotImplementedException();
        }

        public void saveScoreTable(ScoreTable scores)
        {
            throw new NotImplementedException();
        }
    }
}
