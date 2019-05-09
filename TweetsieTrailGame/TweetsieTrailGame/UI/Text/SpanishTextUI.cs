using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class SpanishTextUI : ITweetsieUI
    {

        private ITextPresenter presenter;
        private ITextInputController inputController;

        public SpanishTextUI(ITextPresenter uiPresenter, ITextInputController uiInputController)
        {
            presenter = uiPresenter;
            inputController = uiInputController;
        }

        public void playerCreationMenu(int playerNum, List<HunterJobInfo> jobInfos, out string name, out HunterJobInfo jobChoice)
        {
            TextUIModel playerCreationUIModel = new TextUIModel();
            playerCreationUIModel.Header.Add("Creando jugador " + (playerNum + 1));
            playerCreationUIModel.InputPrompt = ("Que es jugador " + (playerNum + 1) + "'s nombre? >>");
            presenter.showTextUIModel(playerCreationUIModel);
            name = inputController.getStringInput();

            foreach (HunterJobInfo jobInfo in jobInfos)
            {
                playerCreationUIModel.Options.Add(jobInfo.Name + ": " + jobInfo.Health + " salud, " + jobInfo.Strength + " fuerza, " +
                                                  jobInfo.ScoreMultiplier + "X multiplicador de puntos, " + jobInfo.StartingMoney + " dinero inicial");
            }
            playerCreationUIModel.InputPrompt = "Que trabajo hace " + name + " tener? >> ";
            presenter.showTextUIModel(playerCreationUIModel);

            jobChoice = jobInfos[getPlayerOption(playerCreationUIModel) - 1];
        }

        public GAME_STATE mainMenu()
        {
            TextUIModel openingScreenModel = new TextUIModel();
            openingScreenModel.Header.Add("Tweetsie Trail Game");
            openingScreenModel.InputPrompt = "Pulse cualquier tecla para continuar";
            presenter.showTextUIModel(openingScreenModel);
            inputController.waitForKeyPress();

            TextUIModel mainMenuModel = new TextUIModel();
            mainMenuModel.Header.Add("¿Qué quieres hacer?");
            mainMenuModel.Options.Add("comenzar el juego");
            mainMenuModel.Options.Add("Mira el marcador");
            mainMenuModel.Options.Add("Salida");
            mainMenuModel.InputPrompt = "Ingrese su elección>>";

            int option = getPlayerOption(mainMenuModel);

            GAME_STATE state = GAME_STATE.GAME_STATE_MAIN_MENU;
            switch (option)
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

        public int getVenderOption(TextUIModel uiModel, int owned)
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
                shoppingMainMenu.Header.Add("Que te gustaría hacer?");
                shoppingMainMenu.Options.Add("Comprar Ruedas");
                shoppingMainMenu.Options.Add("Comprar Ejes");
                shoppingMainMenu.Options.Add("Comprar Baterías");
                shoppingMainMenu.Options.Add("Comprar Comida");
                shoppingMainMenu.Options.Add("Vender Ruedas");
                shoppingMainMenu.Options.Add("Vender Ejes");
                shoppingMainMenu.Options.Add("Vender Baterías");
                shoppingMainMenu.Options.Add("Vender Comida");
                shoppingMainMenu.Options.Add("Salida");
                shoppingMainMenu.InputPrompt = "Ingrese su elección>>";
                presenter.showTextUIModel(shoppingMainMenu);
                int option = getPlayerOption(shoppingMainMenu);

                TextUIModel shoppingSubMenu = new TextUIModel();


                switch (option)
                {
                    case 1:
                        shoppingSubMenu.Header.Add("Tienes " + cart.Wheels + " ruedas y $" + cart.Money);
                        shoppingSubMenu.Header.Add("Ruedas costar $" + wheelPrice);
                        shoppingSubMenu.InputPrompt = "¿Cómo puedes querer comprar?? >>";
                        int wheelsPurchased = getMoneyOption(shoppingSubMenu, cart.Money, wheelPrice);
                        cart.Money -= wheelPrice * wheelsPurchased;
                        cart.Wheels += wheelsPurchased;
                        break;
                    case 2:
                        shoppingSubMenu.Header.Add("Tienes " + cart.Axles + " Ejes and $" + cart.Money);
                        shoppingSubMenu.Header.Add("Ejes cost $" + axlePrice);
                        shoppingSubMenu.InputPrompt = "¿Cómo puedes querer comprar?? >>";
                        int EjesPurchased = getMoneyOption(shoppingSubMenu, cart.Money, axlePrice);
                        cart.Money -= axlePrice * EjesPurchased;
                        cart.Axles += EjesPurchased;
                        break;
                    case 3:
                        shoppingSubMenu.Header.Add("Tienes " + cart.Batteries + " baterías y $" + cart.Money);
                        shoppingSubMenu.Header.Add("Baterías $" + batteryPrice);
                        shoppingSubMenu.InputPrompt = "¿Cómo puedes querer comprar?? >>";
                        int batteriesPurchased = getMoneyOption(shoppingSubMenu, cart.Money, batteryPrice);
                        cart.Money -= batteryPrice * batteriesPurchased;
                        cart.Batteries += batteriesPurchased;
                        break;
                    case 4:
                        shoppingSubMenu.Header.Add("Tienes " + cart.Food + " libras de comida en su carrito y $" + cart.Money);
                        shoppingSubMenu.Header.Add("Costos de comida $" + foodPrice + " por libra");
                        shoppingSubMenu.InputPrompt = "¿Cuánto quieres comprar? >>";
                        int foodPurchased = getMoneyOption(shoppingSubMenu, cart.Money, foodPrice);
                        cart.Money -= foodPrice * foodPurchased;
                        cart.Food += foodPurchased;
                        break;
                    case 5:
                        shoppingSubMenu.Header.Add("Tienes " + cart.Wheels + " ruedas y $" + cart.Money);
                        shoppingSubMenu.Header.Add("Ruedas valen $" + wheelPrice);
                        shoppingSubMenu.InputPrompt = "¿Cómo quieres vender?? >>";
                        int wheelsSold = getVenderOption(shoppingSubMenu, cart.Wheels);
                        cart.Money += wheelPrice * wheelsSold;
                        cart.Wheels -= wheelsSold;
                        break;
                    case 6:
                        shoppingSubMenu.Header.Add("Tienes " + cart.Axles + " Ejes and $" + cart.Money);
                        shoppingSubMenu.Header.Add("Ejes valen $" + axlePrice);
                        shoppingSubMenu.InputPrompt = "¿Cómo quieres vender?? >>";
                        int EjesSold = getVenderOption(shoppingSubMenu, cart.Axles);
                        cart.Money += axlePrice * EjesSold;
                        cart.Axles -= EjesSold;
                        break;
                    case 7:
                        shoppingSubMenu.Header.Add("Tienes " + cart.Batteries + " Baterias y $" + cart.Money);
                        shoppingSubMenu.Header.Add("Baterias valen $" + batteryPrice);
                        shoppingSubMenu.InputPrompt = "¿Cómo quieres vender?? >>";
                        int batteriesSold = getVenderOption(shoppingSubMenu, cart.Batteries);
                        cart.Money += batteryPrice * batteriesSold;
                        cart.Batteries -= batteriesSold;
                        break;
                    case 8:
                        shoppingSubMenu.Header.Add("Tienes " + cart.Food + " libras de comida en su carrito y $" + cart.Money);
                        shoppingSubMenu.Header.Add("La comida vale la pena $" + foodPrice + " por libra");
                        shoppingSubMenu.InputPrompt = "¿Cuánto quieres vender? >>";
                        foodPurchased = getVenderOption(shoppingSubMenu, cart.Food);
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
            changePace.Header.Add("Which would you like to Comprar?");
            changePace.Options.Add("Freaky Fast");
            changePace.Options.Add("Dominoes Fast");
            changePace.Options.Add("Pizza Hut Fast");
            changePace.Options.Add("SnailMail Fast");
            changePace.InputPrompt = "Ingrese su elección>>";
            int option = getPlayerOption(changePace);
            map.Pace = option;
        }

        public void continueTravel(Days day)
        {
            while (inputController.loopUntilKeypress() == false)
            {
                //Can weather just return a string like this???
                TextUIModel continueTravel = new TextUIModel();
                continueTravel.Header.Add("Dia: " + day.Day);
                continueTravel.Header.Add("Terrano: " + Terrain.getTerrain());
                presenter.showTextUIModel(continueTravel);
                day.continueTravel();
            }
        }

        public void breakAxleNotification(int otroEjes)
        {
            TextUIModel breakAxleModel = new TextUIModel();
            breakAxleModel.Header.Add("un eje se rompio. Tu tienes " + otroEjes + " ejes a la izquierda");
            breakAxleModel.InputPrompt = "Ingrese su elección>>";
            presenter.showTextUIModel(breakAxleModel);
            inputController.waitForKeyPress();
        }

        public void breakWheelNotification(int otroWheels)
        {
            TextUIModel breakAxleModel = new TextUIModel();
            breakAxleModel.Header.Add("Una rueda se rompió. Tienes " + otroWheels + " ruedas dejadas");
            breakAxleModel.InputPrompt = "Ingrese su elección>>";
            presenter.showTextUIModel(breakAxleModel);
            inputController.waitForKeyPress();
        }

        public void breakBatteryNotification(int otroBatteries)
        {
            TextUIModel breakAxleModel = new TextUIModel();
            breakAxleModel.Header.Add("Una batería se rompió. Tienes " + otroBatteries + " baterías dejadas");
            breakAxleModel.InputPrompt = "Ingrese su elección>>";
            presenter.showTextUIModel(breakAxleModel);
            inputController.waitForKeyPress();
        }

        public bool ongoingFightMenu(Fight fight)
        {
            TextUIModel fightModel = new TextUIModel();
            fightModel.Header.Add("A " + fight.Enemy.Name + " enfoques." + " Tiene " + fight.Enemy.Health + " salud, " + fight.Enemy.Strength + " fuerza");
            foreach (Hunter hunter in fight.Hunters)
            {
                if (hunter.isAlive()) fightModel.Header.Add(hunter.Name + ": " + hunter.Health + " salud, " + hunter.Strength + " fuerza");
                else fightModel.Header.Add(hunter.Name + " ha muerto");
            }
            fightModel.Options.Add("Lucha");
            fightModel.Options.Add("Huir");
            fightModel.InputPrompt = "Qué quieres hacer? >>";
            presenter.showTextUIModel(fightModel);
            int option = getPlayerOption(fightModel);
            bool continueFighting = true;
            if (option == 2)
            {
                continueFighting = false;
            }
            return continueFighting;
        }

        public void playerWonFightMenu(Enemy enemy)
        {
            TextUIModel fightWonModel = new TextUIModel();
            fightWonModel.Header.Add("Derrotaste al " + enemy.Name);
            fightWonModel.Header.Add("Tu tienes " + enemy.FoodAmount + " comida para ganar");
            fightWonModel.Header.Add(enemy.ScoreValue + " Se han añadido puntos a tu puntuación final.");
            fightWonModel.InputPrompt = "Ingrese su elección>>";
            presenter.showTextUIModel(fightWonModel);
            inputController.waitForKeyPress();
        }

        public void showDead(List<Hunter> deadHunters)
        {
            TextUIModel model = new TextUIModel();
            foreach (Hunter deadHunter in deadHunters)
            {
                model.Header.Add(deadHunter.Name + " ha muerto");
            }
            model.InputPrompt = "Ingrese su elección>>";
            presenter.showTextUIModel(model);
            inputController.waitForKeyPress();
        }

        public void showGameOver()
        {
            TextUIModel model = new TextUIModel();
            model.Header.Add("Juego terminado");
            model.InputPrompt = "Pulse cualquier tecla para volver al menú principal.>>";
            presenter.showTextUIModel(model);
            inputController.waitForKeyPress();
        }

        public void travelMenu(GolfCart cart, List<Hunter> hunters, Map map, Days day)
        {
            TextUIModel model = new TextUIModel();
            model.Header.Add("Dia: " + day + "      " + "Terreno: " + Terrain.getTerrain());
            foreach (Hunter hunter in hunters)
            {
                model.Header.Add(hunter.Name + "'s salud: " + hunter.Health);
            }

            //model.Header.Add(hunters[1].Name + "'s health: " + hunters[1].Health);
            //model.Header.Add(hunters[2].Name + "'s health: " + hunters[2].Health);
            presenter.showTextUIModel(model);
            System.Threading.Thread.Sleep(1000);
        }

        public int arrivalMenu(Map map)
        {
            TextUIModel model = new TextUIModel();
            model.Header.Add("Tienes llegado a " + map.MapList[map.CurrentLocation] + ". Que te gustaría hacer?");
            model.Options.Add("Seguir viajando");
            model.Options.Add("Para y compra");
            model.InputPrompt = "Ingrese su elección>>";
            int option = getPlayerOption(model);
            return option;
        }

        public void winningMenu()
        {
            TextUIModel model = new TextUIModel();
            model.Header.Add("¡Felicitaciones has ganado!");
            model.InputPrompt = "Pulse cualquier tecla para volver al menú principal.>>";
            presenter.showTextUIModel(model);
            inputController.waitForKeyPress();
        }

        public int displayFork(Map map)
        {
            TextUIModel model = new TextUIModel();
            model.Header.Add("¡Has llegado a un tenedor! Elige una dirección");
            Location currentLocation = map.MapList[map.CurrentLocation];
            Location firstOption = map.MapList[currentLocation.Next];
            Location secondOption = map.MapList[currentLocation.SecondNext];
            model.Options.Add(firstOption.Name);
            model.Options.Add(secondOption.Name);
            int option = getPlayerOption(model);
            return option;

        }

        public string askName()
        {
            TextUIModel model = new TextUIModel();
            model.Header.Add("Ingrese su nombre para su puntaje");
            presenter.showTextUIModel(model);
            string name = inputController.getStringInput();
            return name;
        }

        public void waitForKey()
        {
            TextUIModel model = new TextUIModel();
            model.Header.Add("Ingrese su elección");
            presenter.showTextUIModel(model);
            inputController.waitForKeyPress();
        }
    }
}

