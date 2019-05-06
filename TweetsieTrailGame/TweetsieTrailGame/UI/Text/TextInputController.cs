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

        public int getPriceOption(int lower, GolfCart cart, int price)
        {
            int option = reader.getInt();
            int max = (cart.Money / price);
            if (option < lower || option > max)
            {
                throw new TweetsieInputException("You do not have enough money to buy more than " + max);
            }
            else
            {
                return option;
            }
        }

        public void waitForKeyPress()
        {
            reader.waitForKeyPress();
        }
    }
}
