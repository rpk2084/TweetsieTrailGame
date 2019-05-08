using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    interface IFileManager
    {
        ScoreTable loadScoreTable();
        List<EnemyCreateInfo> loadEnemyTypes();
        //List<Location> loadLocations(string path);
        List<HunterJobInfo> loadHunterJobsInfos();
        void saveScoreTable(ScoreTable scores);
    }
}
