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

        public void getStartMenuInput()
        {
            reader.waitForKeyPress();
        }

        public String getResponse()
        {
            return reader.getLine();
        }
    }
}
