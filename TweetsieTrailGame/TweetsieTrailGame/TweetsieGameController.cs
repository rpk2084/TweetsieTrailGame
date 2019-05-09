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
        GAME_STATE_GAME_OVER,
        GAME_STATE_QUIT,
        GAME_STATE_STARTING_INFO
    };

    class TweetsieGameController
    {
        //Declare Presenter, File formatter, etc.
        //private IPresenter uiPresenter;
        //private IInputController uiInputController;
        private ITweetsieUI ui;
        private IFileManager fileManager;

        //Declare entities
        private GAME_STATE gameState;
        private int playerCount;
        private TweetsieTrailGame game;

        //The constructor is the only part of this class that should be public
        public TweetsieGameController(ITweetsieUI tweetsieUI, IFileManager fileManager, int playerCount)
        {
            ui = tweetsieUI;
            this.fileManager = fileManager;
            TweetsieTrailGame.enemyTypes = fileManager.loadEnemyTypes();
            this.playerCount = playerCount;
            

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

                    case GAME_STATE.GAME_STATE_GAME_OVER:
                        ui.showGameOver();
                        gameState = GAME_STATE.GAME_STATE_MAIN_MENU;
                        break;
                }
            }
            exitMessage();
        }

        private void createGame()
        {
            List<Location> theMap = loadLocation();
            game = new TweetsieTrailGame(playerCount, theMap);
        }

        private List<Location> loadLocation()
        {
            List<Location> locationList = fileManager.loadLocations();
            return locationList;

        }

        private void openingMenu()
        {
            this.gameState = ui.mainMenu();
        }

        private void startInfo()
        {
            createGame();
            List<HunterJobInfo> hunterJobList = fileManager.loadHunterJobsInfos();
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
            ScoreTable scores = fileManager.loadScoreTable();
            ui.showScores(scores);
            gameState = GAME_STATE.GAME_STATE_MAIN_MENU;
        }

        private void shopMenu()
        {
            ui.shoppingMenu(game.Cart);
            gameState = GAME_STATE.GAME_STATE_TRAVELLING;
        }

        private void travelLoop()
        {
            bool continueTravel = true;
            while(continueTravel)
            { 
                ui.travelMenu(game.Cart, game.Hunters, game.GameMap, game.Day);
                EVENT_TYPE e = game.randomEvent();
                if(e != EVENT_TYPE.NO_EVENT)
                {
                    switch(e)
                    {
                        case EVENT_TYPE.BREAK_AXLE:
                            ui.breakAxleNotification(game.Cart.Axles);
                            break;
                        case EVENT_TYPE.BREAK_WHEEL:
                            ui.breakWheelNotification(game.Cart.Wheels);
                            break;
                        case EVENT_TYPE.BREAK_BATTERY:
                            ui.breakBatteryNotification(game.Cart.Batteries);
                            break;
                        case EVENT_TYPE.FIGHT:
                            fightLoop();
                            break;
                    }
                }

                bool inWilderness = game.travel(ui.displayFork);
                List<Hunter> deadHunters = game.updateStatus();
                if(deadHunters.Count > 0)
                {
                    ui.showDead(deadHunters);
                    if(game.Hunters.Count == 0)
                    {
                        gameState = GAME_STATE.GAME_STATE_GAME_OVER;
                        break;
                    }
                }
                if (inWilderness == false)
                {
                    if (game.GameMap.CurrentLocation == 14)
                    {
                        finalFight();
                        ui.winningMenu();
                        string name = ui.askName();
                        ScoreTable table = fileManager.loadScoreTable();
                        table.addScore(name, game.Score);
                        gameState = GAME_STATE.GAME_STATE_SCORES;
                        break;
                    }
                    else
                    {
                        int option = ui.arrivalMenu(game.GameMap);
                        switch (option)
                        {
                            case 1:
                                break;
                            case 2:
                                shopMenu();
                                break;
                        }
                    }
                }
                else
                {
                    continue;
                }
            }
            //ui.continueTravel(game.Day);
            //gameState = GAME_STATE.GAME_STATE_QUIT;
        }

        private void fightLoop()
        {
            Fight fight = game.createFight();
            bool continueFight = true;
            while(continueFight)
            {
                continueFight = ui.ongoingFightMenu(fight);
                if(continueFight)
                {
                    FIGHT_STATUS fightStatus = fight.fightRound();
                    switch(fightStatus)
                    {
                        case FIGHT_STATUS.ONGOING:
                            continueFight = true;
                            break;
                        case FIGHT_STATUS.ENEMY_WINS:
                            continueFight = false;
                            gameState = GAME_STATE.GAME_STATE_GAME_OVER;
                            break;
                        case FIGHT_STATUS.PLAYER_WINS:
                            continueFight = false;
                            ui.playerWonFightMenu(fight.Enemy);
                            game.playerWinsFight(fight.Enemy);
                            break;
                    }
                }
            }
        }

        private void exitMessage()
        {
            //uiPresenter.showExitMessage();
        }

        private void finalFight()
        {
            Fight fight = game.createFinalFight();
            bool continueFight = true;
            while (continueFight)
            {
                continueFight = ui.ongoingFightMenu(fight);
                if (continueFight)
                {
                    FIGHT_STATUS fightStatus = fight.fightRound();
                    switch (fightStatus)
                    {
                        case FIGHT_STATUS.ONGOING:
                            continueFight = true;
                            break;
                        case FIGHT_STATUS.ENEMY_WINS:
                            continueFight = false;
                            gameState = GAME_STATE.GAME_STATE_GAME_OVER;
                            break;
                        case FIGHT_STATUS.PLAYER_WINS:
                            continueFight = false;
                            ui.playerWonFightMenu(fight.Enemy);
                            game.playerWinsFight(fight.Enemy);
                            break;
                    }
                }
            }
        }
    }
}
