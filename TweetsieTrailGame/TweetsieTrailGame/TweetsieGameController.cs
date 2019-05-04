using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    enum GAME_STATE
    {
        GAME_STATE_MAIN_MENU,
        GAME_STATE_TRAVELLING,
        GAME_STATE_SHOPPING,
        GAME_STATE_SCORES,
        GAME_STATE_QUIT,
        GAME_STATE_STARTING_INFO
    };

    class TweetsieGameController
    {
        //Declare Presenter, File formatter, etc.
        //private IPresenter uiPresenter;
        //private IInputController uiInputController;
        private ITweetsieUI ui;

        //Declare entities
        private GAME_STATE gameState;
        private TweetsieTrailGame game;

        //The constructor is the only part of this class that should be public
        public TweetsieGameController(ITweetsieUI tweetsieUI)
        {
            //Assign presenter, file formatter, etc.
            //uiPresenter = presenter;
            //uiInputController = controller;
            ui = tweetsieUI;

            //start the main loop
            gameState = GAME_STATE.GAME_STATE_MAIN_MENU;
            mainLoop();
        }

        private void mainLoop()
        {
            while (gameState != GAME_STATE.GAME_STATE_QUIT)
            {
                switch (gameState)
                {
                    case GAME_STATE.GAME_STATE_STARTING_INFO:
                        //startInfo();
                        break;

                    case GAME_STATE.GAME_STATE_MAIN_MENU:
                        openingMenu();
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

        private void openingMenu()
        {
            this.gameState = ui.mainMenu();
        }

        //private void startInfo()
        //{
        //    HunterJobInfo player = createPlayer();
        //    gameState = GAME_STATE.GAME_STATE_SHOPPING;
        //}

        //private HunterJobInfo createPlayer()
        //{
        //    String name = getPlayerName();
        //    int jobChoice = getPlayerJob();
        //    //Because any errors should be handled in the methods already called, let else have the last case to satisfy the return value
        //    if (jobChoice == 1)
        //    {
        //        HunterJobInfo player = new HunterJobInfo(name, 100, 15, 1.2, 700);
        //        return player;
        //    }
        //    else
        //    {
        //        HunterJobInfo player = new HunterJobInfo(name, 100, 25, 1.2, 500);
        //        return player;
        //    }

        //}

        //private String getPlayerName()
        //{
        //    //uiPresenter.showNameRequest();
        //    //String name = uiInputController.getResponse();
        //    return name;
        //}

        //private int getPlayerJob()
        //{
        //    //uiPresenter.showDecideJob();
        //    //int job = uiInputController.getIntOption(1, 2);
        //    return job;
        //}

        private void scoreBoard()
        {
            //uiPresenter.showScores();
            //uiPresenter.showContinue();
            //uiInputController.getStartMenuInput();
            gameState = GAME_STATE.GAME_STATE_MAIN_MENU;
        }

        private void shopMenu()
        {

        }

        private void travelLoop()
        {

        }

        private void exitMessage()
        {
            //uiPresenter.showExitMessage();
        }
    }
}
