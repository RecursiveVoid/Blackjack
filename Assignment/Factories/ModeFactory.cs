using Assignment.Controllers;
using Assignment.Models;
using Assignment.Modes;
using Assignment.Views;

namespace Assignment.Factories
{
    public class ModeFactory
    {
        public Mode CreateGameMode()
        {
            var model = new GameModel();
            var view = new GameView(model);
            return new Mode {
                Controller = new GameController(model, view),
                View = view,
                Model = model,
                Type = Types.ModeType.GAME,
            };
        }

        public Mode CreateMenuMode()
        {
            var model = new MenuModel();
            var view = new MenuView(model);
            return new Mode
            {
                Controller = new MenuController(model, view),
                View = view,
                Model = model,
                Type = Types.ModeType.MENU,
            };
        }
    }
}
