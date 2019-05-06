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
        int getPriceOption(int lower, GolfCart cart, int price);
    }
}
