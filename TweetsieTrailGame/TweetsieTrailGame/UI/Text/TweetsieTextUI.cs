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

        public int getMoneyOption(TextUIModel uiModel, int money, int price)
        {
            int option;
            while (true)
            {
                presenter.showTextUIModel(uiModel);
                try
                {
                    int max = (money / price);
                    option = inputController.getIntOption(0, max);
                    break;
                }
                catch (TweetsieInputException e)
                {
                    continue;
                }
            }
            return option;
        }

        public int getSellOption(TextUIModel uiModel, int owned)
        {
            int option;
            while (true)
            {
                presenter.showTextUIModel(uiModel);
                try
                {
                    option = inputController.getIntOption(0, owned);
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
            int wheelPrice = 50;
            int axlePrice = 100;
            int batteryPrice = 20;
            int foodPrice = 1;
            bool exit = true;

            while (exit)
            {
                TextUIModel shoppingMainMenu = new TextUIModel();
                shoppingMainMenu.Header.Add("What would you like to do?");
                shoppingMainMenu.Options.Add("Buy Wheels");
                shoppingMainMenu.Options.Add("Buy Axles");
                shoppingMainMenu.Options.Add("Buy Batteries");
                shoppingMainMenu.Options.Add("Buy Food");
                shoppingMainMenu.Options.Add("Sell Wheels");
                shoppingMainMenu.Options.Add("Sell Axles");
                shoppingMainMenu.Options.Add("Sell Batteries");
                shoppingMainMenu.Options.Add("Sell Food");
                shoppingMainMenu.Options.Add("Exit");
                shoppingMainMenu.InputPrompt = "Enter your choice>>";
                presenter.showTextUIModel(shoppingMainMenu);
                int option = getPlayerOption(shoppingMainMenu);

                TextUIModel shoppingSubMenu = new TextUIModel();
                

                switch (option)
                {
                    case 1:
                        shoppingSubMenu.Header.Add("You have " + cart.Wheels + " wheels and $" + cart.Money);
                        shoppingSubMenu.Header.Add("Wheels cost $" + wheelPrice);
                        shoppingSubMenu.InputPrompt = "How many do you want to buy? >>";
                        int wheelsPurchased = getMoneyOption(shoppingSubMenu, cart.Money, wheelPrice);
                        cart.Money -= wheelPrice * wheelsPurchased;
                        cart.Wheels += wheelsPurchased;
                        break;
                    case 2:
                        shoppingSubMenu.Header.Add("You have " + cart.Axles + " axles and $" + cart.Money);
                        shoppingSubMenu.Header.Add("Axles cost $" + axlePrice);
                        shoppingSubMenu.InputPrompt = "How many do you want to buy? >>";
                        int axlesPurchased = getMoneyOption(shoppingSubMenu, cart.Money, axlePrice);
                        cart.Money -= axlePrice * axlesPurchased;
                        cart.Axles += axlesPurchased;
                        break;
                    case 3:
                        shoppingSubMenu.Header.Add("You have " + cart.Batteries + " batteries and $" + cart.Money);
                        shoppingSubMenu.Header.Add("Batteries cost $" + batteryPrice);
                        shoppingSubMenu.InputPrompt = "How many do you want to buy? >>";
                        int batteriesPurchased = getMoneyOption(shoppingSubMenu, cart.Money, batteryPrice);
                        cart.Money -= batteryPrice * batteriesPurchased;
                        cart.Batteries += batteriesPurchased;
                        break;
                    case 4:
                        shoppingSubMenu.Header.Add("You have " + cart.Food + " pounds of food in your cart and $" + cart.Money);
                        shoppingSubMenu.Header.Add("Food costs $" + foodPrice + " per pound");
                        shoppingSubMenu.InputPrompt = "How much do you want to buy? >>";
                        int foodPurchased = getMoneyOption(shoppingSubMenu, cart.Money, foodPrice);
                        cart.Money -= foodPrice * foodPurchased;
                        cart.Food += foodPurchased;
                        break;
                    case 5:
                        shoppingSubMenu.Header.Add("You have " + cart.Wheels + " wheels and $" + cart.Money);
                        shoppingSubMenu.Header.Add("Wheels are worth $" + wheelPrice);
                        shoppingSubMenu.InputPrompt = "How many do you want to sell? >>";
                        int wheelsSold = getSellOption(shoppingSubMenu, cart.Wheels);
                        cart.Money += wheelPrice * wheelsSold;
                        cart.Wheels -= wheelsSold;
                        break;
                    case 6:
                        shoppingSubMenu.Header.Add("You have " + cart.Axles + " axles and $" + cart.Money);
                        shoppingSubMenu.Header.Add("Axles are worth $" + axlePrice);
                        shoppingSubMenu.InputPrompt = "How many do you want to sell? >>";
                        int axlesSold = getSellOption(shoppingSubMenu, cart.Axles);
                        cart.Money += axlePrice * axlesSold;
                        cart.Axles -= axlesSold;
                        break;
                    case 7:
                        shoppingSubMenu.Header.Add("You have " + cart.Batteries + " batteries and $" + cart.Money);
                        shoppingSubMenu.Header.Add("Batteries are worth $" + batteryPrice);
                        shoppingSubMenu.InputPrompt = "How many do you want to sell? >>";
                        int batteriesSold = getSellOption(shoppingSubMenu, cart.Batteries);
                        cart.Money += batteryPrice * batteriesSold;
                        cart.Batteries -= batteriesSold;
                        break;
                    case 8:
                        shoppingSubMenu.Header.Add("You have " + cart.Food + " pounds of food in your cart and $" + cart.Money);
                        shoppingSubMenu.Header.Add("Food is worth $" + foodPrice + " per pound");
                        shoppingSubMenu.InputPrompt = "How much do you want to sell? >>";
                        foodPurchased = getSellOption(shoppingSubMenu, cart.Food);
                        cart.Money += foodPrice * foodPurchased;
                        cart.Food -= foodPurchased;
                        break;
                    case 9:
                        exit = false;
                        break;
                }
            }
        }

        public void changePace(Map map)
        {
            TextUIModel changePace = new TextUIModel();
            changePace.Header.Add("Which would you like to buy?");
            changePace.Options.Add("Freaky Fast");
            changePace.Options.Add("Dominoes Fast");
            changePace.Options.Add("Pizza Hut Fast");
            changePace.Options.Add("SnailMail Fast");
            changePace.InputPrompt = "Enter your choice>>";
            int option = getPlayerOption(changePace);
            map.Pace = option;
        }

        public void continueTravel(Days day)
        {
            while (inputController.loopUntilKeypress() == false)
            {
                //Can weather just return a string like this???
                TextUIModel continueTravel = new TextUIModel();
                continueTravel.Header.Add("Day: " + day.Day);
                continueTravel.Header.Add("Weather: " + Terrain.getTerrain());
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

        public bool ongoingFightMenu(Fight fight)
        {
            TextUIModel fightModel = new TextUIModel();
            fightModel.Header.Add("A " + fight.Enemy.Name + " approaches." + " It has " + fight.Enemy.Health + " health, " + fight.Enemy.Strength + " strength");
            foreach(Hunter hunter in fight.Hunters)
            {
                if (hunter.isAlive()) fightModel.Header.Add(hunter.Name + ": " + hunter.Health + " health, " + hunter.Strength + " strength");
                else fightModel.Header.Add(hunter.Name + " is dead");
            }
            fightModel.Options.Add("Fight");
            fightModel.Options.Add("Run away");
            fightModel.InputPrompt = "What do you want to do? >>";
            presenter.showTextUIModel(fightModel);
            int option = getPlayerOption(fightModel);
            bool continueFighting = true;
            if(option == 2)
            {
                continueFighting = false;
            }
            return continueFighting;
        }

        public void playerWonFightMenu(Enemy enemy)
        {
            TextUIModel fightWonModel = new TextUIModel();
            fightWonModel.Header.Add("You defeated the " + enemy.Name);
            fightWonModel.Header.Add("You got " + enemy.FoodAmount + " food for winning");
            fightWonModel.Header.Add(enemy.ScoreValue + " points have been added to your final score");
            fightWonModel.InputPrompt = "Press any key to continue>>";
            presenter.showTextUIModel(fightWonModel);
            inputController.waitForKeyPress();
        }

        public void showDead(List<Hunter> deadHunters)
        {
            TextUIModel model = new TextUIModel();
            foreach(Hunter deadHunter in deadHunters)
            {
                model.Header.Add(deadHunter.Name + " has died");
            }
            model.InputPrompt = "Press any key to continue>>";
            presenter.showTextUIModel(model);
            inputController.waitForKeyPress();
        }

        public void showGameOver()
        {
            TextUIModel model = new TextUIModel();
            model.Header.Add("Game Over");
            model.InputPrompt = "Press any key to return to the main menu>>";
            presenter.showTextUIModel(model);
            inputController.waitForKeyPress();
        }

        public void travelMenu(GolfCart cart, List<Hunter> hunters, Map map, Days day)
        {
            TextUIModel model = new TextUIModel();
            model.Header.Add("Day: " + day + "      " + "Terrain: " + Terrain.getTerrain());
            foreach(Hunter hunter in hunters)
            {
                model.Header.Add(hunter.Name + "'s health: " + hunter.Health);
            }
            
            //model.Header.Add(hunters[1].Name + "'s health: " + hunters[1].Health);
            //model.Header.Add(hunters[2].Name + "'s health: " + hunters[2].Health);
            presenter.showTextUIModel(model);
            System.Threading.Thread.Sleep(1000);
        }

        public int arrivalMenu(Map map)
        {
            TextUIModel model = new TextUIModel();
            model.Header.Add("You have arrived at " + map.MapList[map.CurrentLocation] + ". What would you like to do?");
            model.Options.Add("Continue Traveling");
            model.Options.Add("Stop and shop");
            model.InputPrompt = "Enter your choice>>";
            int option = getPlayerOption(model);
            return option;
        }

        public void winningMenu()
        {
            TextUIModel model = new TextUIModel();
            model.Header.Add("Congratulations, you won!");
            presenter.showTextUIModel(model);
        }

        public int displayFork(Map map)
        {
            TextUIModel model = new TextUIModel();
            model.Header.Add("You have reached a fork! Choose a direction");
            Location currentLocation = map.MapList[map.CurrentLocation];
            Location firstOption = map.MapList[currentLocation.Next];
            Location secondOption = map.MapList[currentLocation.SecondNext];
            model.Options.Add(firstOption.Name);
            model.Options.Add(secondOption.Name);
            int option = getPlayerOption(model);
            return option;
            
        }
    }

    
}
