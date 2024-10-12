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

        private void _handleChangeModeType(object? sender, ModeTypeChangedEventArgs args)
        {
            var currentMode = _model.CurrentMode;
            currentMode.Controller.Stop();
            currentMode = _model.GetModeByType(args.Type);
            _model.CurrentMode = currentMode;
            currentMode.Controller.Start();
        } 

        private void _prepareMenuModelEvents()
        {
            var menuMode = _model.GetModeByType(ModeType.MENU);
            var menuModel = (MenuModel)menuMode.Model;
            menuModel.OnStatusChange += _handleChangeMenuStatus;
        }

        private void _handleChangeMenuStatus(object? sender, MenuStatusChangedEventArgs args)
        {
            switch (args.Status)
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
            var gameModel = (GameModel)gameMode.Model;
            gameModel.OnStatusChange += _handleChangeGameStatus;
        }

        private void _exitGracefully()
        {
            Environment.Exit(0);   
        }

        private void _handleChangeGameStatus(object? sender, GameStatusChangedEventArgs args)
        {
            switch (args.Status)
            {
                case GameStatus.EXIT:
                    _setModeTypeToMenu();
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
            _model.Modes.Add(factory.CreateGameMode());
            _model.Modes.Add(menuMode);
            _model.CurrentMode = menuMode;
        }
    }
}
