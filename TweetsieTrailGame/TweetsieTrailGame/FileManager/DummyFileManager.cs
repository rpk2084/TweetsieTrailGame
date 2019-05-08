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
    }
}
