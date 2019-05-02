using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    enum GAME_STATE
    {
        GAME_STATE_START_MENU,
        GAME_STATE_TRAVELLING,
        GAME_STATE_SHOPPING,
        GAME_STATE_SCORES,
        GAME_STATE_QUIT,
    };

    class TweetsieTrailGame
    {
        //Declare Presenter, File formatter, etc.
        private IPresenter uiPresenter;

        //Declare entities
        private GAME_STATE gameState;

        //The constructor is the only part of this class that should be public
        public TweetsieTrailGame(IPresenter presenter)
        {
            //Assign presenter, file formatter, etc.
            uiPresenter = presenter;

            //Initialize entities

            //start the main loop
            gameState = GAME_STATE.GAME_STATE_START_MENU;
            mainLoop();
        }

        public void mainLoop()
        {
            while(gameState != GAME_STATE.GAME_STATE_QUIT)
            {
                switch (gameState)
                {
                    case GAME_STATE.GAME_STATE_START_MENU:
                        startMenu();
                        break;

                    case GAME_STATE.GAME_STATE_SCORES:
                        scoreBoard();
                        break;

                    case GAME_STATE.GAME_STATE_SHOPPING:
                        shopMenu();
                        break;

                    case GAME_STATE.GAME_STATE_TRAVELLING:
                        travelLoop();
                        break;
                }
            }
            exitMessage();
        }

        private void startMenu()
        {
            uiPresenter.showOpeningScreen();
            gameState = GAME_STATE.GAME_STATE_QUIT;
        }

        private void scoreBoard()
        {

        }

        private void shopMenu()
        {

        }

        private void travelLoop()
        {

        }

        private void exitMessage()
        {
            uiPresenter.showExitMessage();
        }
    }
}
