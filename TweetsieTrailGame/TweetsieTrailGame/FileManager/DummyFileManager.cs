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
            locations.Add(new Location("JohnsonCity", 0, false, 0, 0));
            locations.Add(new Location("TrailHead", 3, true, 20, 1));
            locations.Add(new Location("FencedBridge", 6, true, 20, 2));
            locations.Add(new Location("HomelessBridgeCamp", 9, false, 0, 3));
            locations.Add(new Location("CountyLine", 12, true, 25, 4));
            locations.Add(new Location("DairyFarm", 15, true, 25, 5));
            locations.Add(new Location("TheGeneralStore", 18, false, 0, 5));
            locations.Add(new Location("MilliganDepot", 21, true, 25, 6));
            locations.Add(new Location("OldUnderpass", 24, true, 25, 7));
            locations.Add(new Location("Elizabethton", 27, false, 0, 8));
            locations.Add(new Location("SycamoreShoals", 30, true, 30, 9));
            locations.Add(new Location("BetsyHS", 33, true, 35, 10));
            locations.Add(new Location("DownTown", 36, false, 0, 11));
            locations.Add(new Location("BadLands", 39, true, 40, 12));
            locations.Add(new Location("AbadandonedFactory", 42, true, 40, -1));

            return locations;
        }
    }
}
