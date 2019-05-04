using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class TweetsieUI : ITweetsieUI
    {
        private IPresenter presenter;
        private IInputController inputController;

        public TweetsieUI(IPresenter uiPresenter, IInputController uiInputController)
        {
            presenter = uiPresenter;
            inputController = uiInputController;
        }

        public GAME_STATE mainMenu()
        {
            presenter.showOpeningScreen();
            inputController.getOpeningScreenInput();

            int option;
            while(true)
            {
                presenter.showMainMenuOptions();
                try
                {
                    option = inputController.getMainMenuInput();
                    break;
                }
                catch (TweetsieInputException)
                {
                    continue;
                }

            }
            return (GAME_STATE)option;
        }
    }
}
