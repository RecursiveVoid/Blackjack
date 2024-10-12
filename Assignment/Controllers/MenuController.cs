using Assignment.EventArguments;
using Assignment.Models;
using Assignment.Types;
using Assignment.Views;

namespace Assignment.Controllers
{
    public class MenuController(MenuModel model, MenuView view) : ModeController(model, view)
    {
        public override void Start()
        {
            var menuModel = (MenuModel)_model;
            menuModel.Status = MenuStatus.INIT;
            _handleMenuInput();
 ;        }

        private void _handleMenuInput()
        {
            var menuModel = (MenuModel)_model;
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.D1)
                {
                    menuModel.Status = MenuStatus.NEW_GAME;
                }
                else
                {
                    menuModel.Status = MenuStatus.EXIT;
                }
            
        }

        public override void Stop()
        {
           // throw new NotImplementedException();
        }
    }
}
