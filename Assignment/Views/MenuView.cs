using Assignment.EventArguments;
using Assignment.Models;
using Assignment.Utils;

namespace Assignment.Views
{
    public class MenuView: ModeView
    {
        public MenuView(MenuModel model): base(model) {
            model.OnStatusChange += _handleChangeStatus;
        }
        protected override void _show()
        {
            _printLogo();
            ConsoleWritter.WriteInGreen("PRESS 1 TO START NEW GAME");
            ConsoleWritter.WriteInRed("Press any other key to Exit");
        }


        private void _handleChangeStatus(object? sender, MenuStatusChangedEventArgs args)
        {
           switch(args.Status)
            {
                case Types.MenuStatus.INIT:
                    _show();
                break;
                case Types.MenuStatus.EXIT:
                case Types.MenuStatus.NEW_GAME:
                    _hide();
                break;
           }
        }   

        protected override void _hide()
        {
            Console.Clear();
        }

        private void _printLogo()
        {
            ConsoleWritter.WriteInYellow(" .----------------.  .----------------. \r\n| .--------------. || .--------------. |\r\n| |    _____     | || |     __       | |\r\n| |   / ___ `.   | || |    /  |      | |\r\n| |  |_/___) |   | || |    `| |      | |\r\n| |   .'____.'   | || |     | |      | |\r\n| |  / /____     | || |    _| |_     | |\r\n| |  |_______|   | || |   |_____|    | |\r\n| |              | || |              | |\r\n| '--------------' || '--------------' |\r\n '----------------'  '----------------' ");
        }
    }
}
