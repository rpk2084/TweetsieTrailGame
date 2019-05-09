using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    interface ITextInputController
    {
        void waitForKeyPress();
        String getStringInput();
        int getIntOption(int lower, int upper);
        bool loopUntilKeypress();
    }
}
