using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class TextInputController : ITextInputController
    {
        private ITextInputReader reader;

        public TextInputController(ITextInputReader inputReader)
        {
            reader = inputReader;
        }

        public String getStringInput()
        {
            return reader.getLine();
        }

        public int getIntOption(int lower, int upper)
        {
            int option = reader.getInt();
            if(option < lower || option > upper)
            {
                throw new TweetsieInputException("Input is not between " + lower + " and " + upper);
            }
            else
            {
                return option;
            }
        }

        public bool loopUntilKeypress()
        {
            return reader.loopUntilKeyPress();
        }

        public void waitForKeyPress()
        {
            reader.waitForKeyPress();
        }
    }
}
