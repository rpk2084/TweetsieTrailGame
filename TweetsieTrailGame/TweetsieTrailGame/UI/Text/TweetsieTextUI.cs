using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class TweetsieUI : ITweetsieUI
    {
        private ITextPresenter presenter;
        private ITextInputController inputController;

        public TweetsieUI(ITextPresenter uiPresenter, ITextInputController uiInputController)
        {
            presenter = uiPresenter;
            inputController = uiInputController;
        }

        public void playerCreationMenu(int playerNum, List<HunterJobInfo> jobInfos, out string name, out HunterJobInfo jobChoice)
        {
            TextUIModel playerCreationUIModel = new TextUIModel();
            playerCreationUIModel.Header.Add("Creating player " + (playerNum + 1));
            playerCreationUIModel.InputPrompt = ("What is player " + (playerNum + 1) + "'s name? >>");
            presenter.showTextUIModel(playerCreationUIModel);
            name = inputController.getStringInput();

            foreach(HunterJobInfo jobInfo in jobInfos)
            {
                playerCreationUIModel.Options.Add(jobInfo.Name + ": " + jobInfo.Health + " health, " + jobInfo.Strength + " strength, " +
                                                  jobInfo.ScoreMultiplier + "X score multiplier, " + jobInfo.StartingMoney + " starting money");
            }
            playerCreationUIModel.InputPrompt = "What job does " + name + " have? >> ";
            presenter.showTextUIModel(playerCreationUIModel);

            jobChoice = jobInfos[getPlayerOption(playerCreationUIModel) - 1];
        }

        public GAME_STATE mainMenu()
        {
            TextUIModel openingScreenModel = new TextUIModel();
            openingScreenModel.Header.Add("Tweetsie Trail Game");
            openingScreenModel.InputPrompt = "Press any key to continue";
            presenter.showTextUIModel(openingScreenModel);
            inputController.waitForKeyPress();

            TextUIModel mainMenuModel = new TextUIModel();
            mainMenuModel.Header.Add("What do you want to do?");
            mainMenuModel.Options.Add("Start the game");
            mainMenuModel.Options.Add("Look at the Scoreboard");
            mainMenuModel.Options.Add("Exit");
            mainMenuModel.InputPrompt = "Enter your choice>>";

            int option = getPlayerOption(mainMenuModel);
            
            GAME_STATE state = GAME_STATE.GAME_STATE_MAIN_MENU;
            switch(option)
            {
                case 1:
                    state = GAME_STATE.GAME_STATE_STARTING_INFO;
                    break;
                case 2:
                    state = GAME_STATE.GAME_STATE_SCORES;
                    break;
                case 3:
                    state = GAME_STATE.GAME_STATE_QUIT;
                    break;
            }
            return state;
        }

        public int getPlayerOption(TextUIModel uiModel)
        {
            int option;
            while (true)
            {
                presenter.showTextUIModel(uiModel);
                try
                {
                    option = inputController.getIntOption(1, uiModel.Options.Count);
                    break;
                }
                catch (TweetsieInputException e)
                {
                    continue;
                }
            }
            return option;
        }
    }
}
