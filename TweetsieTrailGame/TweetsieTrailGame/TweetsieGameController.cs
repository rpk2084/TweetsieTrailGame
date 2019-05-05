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
        public TweetsieGameController(ITweetsieUI tweetsieUI, int playerCount)
        {
            ui = tweetsieUI;
            game = new TweetsieTrailGame(playerCount);

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
                        startInfo();
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

        private void startInfo()
        {
            //replace this section with a file later
            List<HunterJobInfo> hunterJobList = new List<HunterJobInfo>();
            hunterJobList.Add(new HunterJobInfo("Banker", 100, 15, 1.2, 100));
            hunterJobList.Add(new HunterJobInfo("Fighter", 100, 20, 1.2, 50));
            //end of section that should be replaced with a file

            for (int i = 0; i < game.PlayerCount; ++i)
            {
                string playerName;
                HunterJobInfo jobChoice;
                ui.playerCreationMenu(i, hunterJobList, out playerName, out jobChoice);
                game.addHunter(playerName, jobChoice);
            }
            gameState = GAME_STATE.GAME_STATE_SHOPPING;
        }

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
