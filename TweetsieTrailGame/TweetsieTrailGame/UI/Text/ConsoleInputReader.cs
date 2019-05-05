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

        public int getInt()
        {
            int intInput;
            bool success = int.TryParse(Console.ReadLine(), out intInput);
            if(!success)
            {
                throw new TweetsieInputException("Unable to convert input to integer");
            }
            return intInput;
        }
    }
}
