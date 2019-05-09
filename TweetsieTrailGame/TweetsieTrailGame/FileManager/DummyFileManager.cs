 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class DummyFileManager: IFileManager
    {
        public ScoreTable loadScoreTable()
        {
            throw new NotImplementedException();
        }

        public List<EnemyCreateInfo> loadEnemyTypes()
        {
            List<EnemyCreateInfo> enemyInfo = new List<EnemyCreateInfo>();
            enemyInfo.Add(new EnemyCreateInfo("Stray Dog", 100, 5, 10, 20));
            enemyInfo.Add(new EnemyCreateInfo("Sasquatch", 200, 20, 5, 100));
            enemyInfo.Add(new EnemyCreateInfo("Angry Beaver", 50, 15, 10, 25));
            return enemyInfo;
        }

        public List<HunterJobInfo> loadHunterJobsInfos()
        {
            List<HunterJobInfo> jobInfos = new List<HunterJobInfo>();
            jobInfos.Add(new HunterJobInfo("Banker", 100, 15, 1.2, 100));
            jobInfos.Add(new HunterJobInfo("Fighter", 100, 20, 1.2, 50));
            return jobInfos;
        }

        public void saveScoreTable(ScoreTable scores)
        {
            throw new NotImplementedException();
        }

        public List<Location> loadLocations()
        {
            List<Location> locations = new List<Location>();
            locations.Add(new Location("JohnsonCity", 0, false, 0, 1, 0));
            locations.Add(new Location("TrailHead", 20, true, 20, 2, 3));
            locations.Add(new Location("FencedBridge", 40, true, 20, 4, 0));
            locations.Add(new Location("HomelessBridgeCamp", 40, false, 0, 5, 0));
            locations.Add(new Location("CountyLine", 100, true, 25, 8, 0));
            locations.Add(new Location("DairyFarm", 120, true, 25, 6, 7));
            locations.Add(new Location("TheGeneralStore", 150, false, 0, 9, 0));
            locations.Add(new Location("MilliganDepot", 150, true, 25, 10, 0));
            locations.Add(new Location("OldUnderpass", 180, true, 25, 9, 0));
            locations.Add(new Location("Elizabethton", 220, false, 0, 11, 0));
            locations.Add(new Location("SycamoreShoals", 295, true, 30, 12, 0));
            locations.Add(new Location("BetsyHS", 350, true, 35, 13, 0));
            locations.Add(new Location("DownTown", 380, false, 0, 14, 0));
            locations.Add(new Location("BadLands", 400, true, 40, 14, 0));
            locations.Add(new Location("AbadandonedFactory", 460, true, 40, 15, 0));

            return locations;
        }
    }
}
