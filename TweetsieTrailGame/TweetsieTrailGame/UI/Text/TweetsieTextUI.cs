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

        public int getMoneyOption(TextUIModel uiModel, GolfCart cart, int price)
        {
            int option;
            while (true)
            {
                presenter.showTextUIModel(uiModel);
                try
                {
                    int max = (cart.Money / price);
                    option = inputController.getPriceOption(0, cart, price);
                    break;
                }
                catch (TweetsieInputException e)
                {
                    continue;
                }
            }
            return option;
        }

        public void shoppingMenu(GolfCart cart)
        {
            int wheelsPurchased = 0;
            int axlesPurchased = 0;
            int batteriesPurchased = 0;
            int wheelPrice = 50;
            int axlePrice = 100;
            int batteryPrice = 20;
            bool exit = true;

            while (exit)
            {
                TextUIModel shoppingMainMenu = new TextUIModel();
                shoppingMainMenu.Header.Add("Which would you like to buy?");
                shoppingMainMenu.Options.Add("Wheels");
                shoppingMainMenu.Options.Add("Axles");
                shoppingMainMenu.Options.Add("Batteries");
                shoppingMainMenu.Options.Add("Exit");
                shoppingMainMenu.InputPrompt = "Enter your choice>>";
                presenter.showTextUIModel(shoppingMainMenu);
                int option = getPlayerOption(shoppingMainMenu);

                TextUIModel shoppingSubMenu = new TextUIModel();
                shoppingSubMenu.InputPrompt = "How many do you want to buy? >>";

                switch (option)
                {
                    case 1:
                        shoppingSubMenu.Header.Add("You have " + cart.Wheels + " wheels and $" + cart.Money);
                        shoppingSubMenu.Header.Add("Wheels cost $" + wheelPrice);
                        wheelsPurchased = getMoneyOption(shoppingSubMenu, cart, wheelPrice);
                        cart.Money -= wheelPrice * wheelsPurchased;
                        cart.Wheels += wheelsPurchased;
                        break;
                    case 2:
                        shoppingSubMenu.Header.Add("You have " + cart.Axles + " axles and $" + cart.Money);
                        shoppingSubMenu.Header.Add("Axles cost $" + axlePrice);
                        axlesPurchased = getMoneyOption(shoppingSubMenu, cart, axlePrice);
                        cart.Money -= axlePrice * axlesPurchased;
                        cart.Axles += axlesPurchased;
                        break;
                    case 3:
                        shoppingSubMenu.Header.Add("You have " + cart.Batteries + " batteries and $" + cart.Money);
                        shoppingSubMenu.Header.Add("Batteries cost $" + batteryPrice);
                        batteriesPurchased = getMoneyOption(shoppingSubMenu, cart, batteryPrice);
                        cart.Money -= batteryPrice * batteriesPurchased;
                        cart.Batteries += batteriesPurchased;
                        break;
                    case 4:
                        exit = false;
                        break;
                }
            }
        }

        public void changePace(Days day)
        {
            TextUIModel changePace = new TextUIModel();
            changePace.Header.Add("Which would you like to buy?");
            changePace.Options.Add("Freaky Fast");
            changePace.Options.Add("Dominoes Fast");
            changePace.Options.Add("Pizza Hut Fast");
            changePace.Options.Add("SnailMail Fast");
            changePace.InputPrompt = "Enter your choice>>";
            int option = getPlayerOption(changePace);
            day.Pace = option;
        }

        public void continueTravel(Days day)
        {
            while (inputController.loopUntilKeypress() == false)
            {
                //Can weather just return a string like this???
                TextUIModel continueTravel = new TextUIModel();
                continueTravel.Header.Add("Day: " + day.Day);
                continueTravel.Header.Add("Weather: " + Terrain.getWeather());
                presenter.showTextUIModel(continueTravel);
                day.continueTravel();
            }
        }

        public void breakAxleNotification(int remainingAxles)
        {
            TextUIModel breakAxleModel = new TextUIModel();
            breakAxleModel.Header.Add("An axle broke. You have " + remainingAxles + " axles left");
            breakAxleModel.InputPrompt = "Press any key to continue>>";
            presenter.showTextUIModel(breakAxleModel);
            inputController.waitForKeyPress();
        }

        public void breakWheelNotification(int remainingWheels)
        {
            TextUIModel breakAxleModel = new TextUIModel();
            breakAxleModel.Header.Add("A wheel broke. You have " + remainingWheels + " wheels left");
            breakAxleModel.InputPrompt = "Press any key to continue>>";
            presenter.showTextUIModel(breakAxleModel);
            inputController.waitForKeyPress();
        }

        public void breakBatteryNotification(int remainingBatteries)
        {
            TextUIModel breakAxleModel = new TextUIModel();
            breakAxleModel.Header.Add("A battery broke. You have " + remainingBatteries + " batteries left");
            breakAxleModel.InputPrompt = "Press any key to continue>>";
            presenter.showTextUIModel(breakAxleModel);
            inputController.waitForKeyPress();
        }
    }

    
}
