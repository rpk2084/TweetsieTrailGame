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
            Console.ReadKey();
        }
    }
}
