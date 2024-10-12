using Assignment.Controllers;
using Assignment.Models;
using Assignment.Types;
using Assignment.Views;

namespace Assignment.Modes
{
    public struct Mode
    {
        public ModeView View { get; set; }
        public ModeModel Model { get; set; }
        public ModeController Controller { get; set; }
        public ModeType Type { get; set; }
    }
}
