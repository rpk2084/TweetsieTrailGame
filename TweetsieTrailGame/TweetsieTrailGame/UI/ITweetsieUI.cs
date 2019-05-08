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
        void changePace(Days day);
        void continueTravel(Days day);
        void breakAxleNotification(int remainingAxles);
        void breakWheelNotification(int remainingWheels);
        void breakBatteryNotification(int remainingBatteries);
        //fight menus
        bool ongoingFightMenu(Fight fight);
        void playerWonFightMenu(Enemy enemy);
    }
}
