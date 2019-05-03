using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    interface IPresenter
    {
        void showOpeningScreen();
        void showExitMessage();
        void showNameRequest();
        void showDecideJob();
        void showErrorMessage();
        void showStartMenuOptions();
    }
}
