using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    interface IInputController
    {
        void getOpeningScreenInput();
        String getResponse();
        int getIntOption(int lower, int upper);
        int getMainMenuInput();
    }
}
