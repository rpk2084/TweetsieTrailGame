using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    interface IInputController
    {
        void getStartMenuInput();
        String getResponse();
        bool loopKey();
    }
}
