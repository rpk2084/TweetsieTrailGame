using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class ConsoleInputReader: ITextInputReader
    {
        public ConsoleInputReader() { }

        public void waitForKeyPress()
        {
            Console.ReadKey(true);
        }

        public bool loopUntilKeyPress()
        {
            return Console.KeyAvailable;
        }

        public String getLine()
        {
            return Console.ReadLine();
        }
    }
}
