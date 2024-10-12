using Assignment.EventArguments;
using Assignment.Factories;
using Assignment.Models;
using Assignment.Views;
using Assignment.Types;

namespace Assignment.Controllers
{
    public class AppController
    {
        private AppModel _model;
        private AppView _view ;

        public AppController(AppModel model, AppView view)
        {
            _model = model;
            _view = view;
            _prepareModes();
            _model.OnModeTypeChanged += _handleChangeModeType;
            _prepareMenuModelEvents();
            _prepareGameModelEvents();
        }
        
        public void Start()
        {
            _setModeTypeToMenu();
        } 

        private void _handleChangeModeType(object sender, ModeTypeChangedEventArgs args)
        {
            var currentMode = _model.CurrentMode;
            currentMode.Controller.Stop();
            currentMode = _model.GetModeByType(args.type);
            _model.CurrentMode = currentMode;
            currentMode.Controller.Start();
        } 

        private void _prepareMenuModelEvents()
        {
            var menuMode = _model.GetModeByType(ModeType.MENU);
            var menuModel = menuMode.Model as MenuModel;
            menuModel.OnStatusChange += _handleChangeMenuStatus;
        }

        private void _handleChangeMenuStatus(object sender, MenuStatusChangedEventArgs args)
        {
            switch (args.status)
            {
                case MenuStatus.NEW_GAME:
                    _setModeTypeToGame();
                    break;
                case MenuStatus.EXIT:
                     _exitGracefully();
                break;
            }
        }

        private void _prepareGameModelEvents()
        {
            var gameMode = _model.GetModeByType(ModeType.GAME);
            var gameModel = gameMode.Model as GameModel;
            gameModel.OnStatusChange += _handleChangeGameStatus;
        }

        private void _exitGracefully()
        {
            Environment.Exit(0);   
        }

        private void _handleChangeGameStatus(object sender, GameStatusChangedEventArgs args)
        {
            Console.WriteLine($"game status changed to: {args.status}"); // Debug log
            switch (args.status)
            {
                case GameStatus.END:
                    _setModeTypeToMenu();
                    break;
                case GameStatus.EXIT:
                    _exitGracefully();
                    break;
            }
        }

        private void _setModeTypeToGame()
        {
            _model.ModeType = ModeType.GAME;
        }

        private void _setModeTypeToMenu()
        {
            _model.ModeType = ModeType.MENU;
        }

        private void _prepareModes() {
            var factory = new ModeFactory();
            var menuMode = factory.CreateMenuMode();
            _model.modes.Add(factory.CreateGameMode());
            _model.modes.Add(menuMode);
            _model.CurrentMode = menuMode;
        }
    }
}
