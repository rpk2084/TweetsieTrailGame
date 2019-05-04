using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class TextInputController : IInputController
    {
        private ITextInputReader reader;

        public TextInputController(ITextInputReader inputReader)
        {
            reader = inputReader;
        }

        public String getResponse()
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

        public void getOpeningScreenInput()
        {
            reader.waitForKeyPress();
        }

        public int getMainMenuInput()
        {
            return getIntOption(1, 3);
        }
    }
}
