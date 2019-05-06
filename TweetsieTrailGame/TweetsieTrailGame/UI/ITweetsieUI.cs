using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    interface ITweetsieUI
    {
        GAME_STATE mainMenu();
        void playerCreationMenu(int playerNum, List<HunterJobInfo> jobInfoList, out string name, out HunterJobInfo jobChoice);
        void shoppingMenu(GolfCart cart);
    }
}
