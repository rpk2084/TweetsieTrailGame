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
        void changePace(Map map);
        void continueTravel(Days day);
        void breakAxleNotification(int remainingAxles);
        void breakWheelNotification(int remainingWheels);
        void breakBatteryNotification(int remainingBatteries);
        void showDead(List<Hunter> deadHunters);
        void showGameOver();
        //fight menus
        bool ongoingFightMenu(Fight fight);
        void playerWonFightMenu(Enemy enemy);
        void travelMenu(GolfCart cart, List<Hunter> hunterList, Map map, Days day);
        int arrivalMenu(Map map);
        void winningMenu();
        int displayFork(Map map);
        string askName();
        void waitForKey();
        void showScores(ScoreTable table);
    }
}
