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
        GAME_STATE_STARTING_INFO
    };

    class TweetsieTrailGame
    {
        //Declare Presenter, File formatter, etc.
        private IPresenter uiPresenter;
        private IInputController uiInputController;

        //Declare entities
        private GAME_STATE gameState;

        //The constructor is the only part of this class that should be public
        public TweetsieTrailGame(IPresenter presenter, IInputController controller)
        {
            //Assign presenter, file formatter, etc.
            uiPresenter = presenter;
            uiInputController = controller;

            //Get basic info for player creation
            
            //Hunter player = new Hunter(100, 20, name);

            //Initialize entities
            GolfCart cart = new GolfCart();
            Days day = new Days();
            
            

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
                    case GAME_STATE.GAME_STATE_STARTING_INFO:
                        startInfo();
                        break;

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
            uiInputController.getStartMenuInput();
            uiPresenter.showStartMenuOptions();
            int option = getOption(1, 2);
            if (option == 1)
            {
                gameState = GAME_STATE.GAME_STATE_STARTING_INFO;
            }
            else if (option == 2)
            {
                gameState = GAME_STATE.GAME_STATE_SCORES;
            }
            //gameState = GAME_STATE.GAME_STATE_QUIT;
        }

        private void startInfo()
        {
            HunterJobInfo player = createPlayer();
            gameState = GAME_STATE.GAME_STATE_SHOPPING;
        }

        private int getOption(int lower, int upper)
        {
            try
            {
                int option = Convert.ToInt32(uiInputController.getResponse());
                if (option >= lower && option <= upper)
                {
                    return option;
                }
                else
                {
                    uiPresenter.showErrorMessage();
                    return getOption(lower, upper);
                }
            }
            catch (Exception ex)
            {
                uiPresenter.showErrorMessage();
                return getOption(lower, upper);
            }
        }

        private HunterJobInfo createPlayer()
        {
            String name = getPlayerName();
            int jobChoice = getPlayerJob();
            //Because any errors should be handled in the methods already called, let else have the last case to satisfy the return value
            if (jobChoice == 1)
            {
                HunterJobInfo player = new HunterJobInfo(name, 100, 15, 1.2, 700);
                return player;
            }
            else
            {
                HunterJobInfo player = new HunterJobInfo(name, 100, 25, 1.2, 500);
                return player;
            }
            
        }

        private String getPlayerName()
        {
            uiPresenter.showNameRequest();
            String name = uiInputController.getResponse();
            return name;
        }

        private int getPlayerJob()
        {
            uiPresenter.showDecideJob();
            int job = getOption(1, 2);
            return job;
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
