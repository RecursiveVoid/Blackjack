using Assignment.EventArguments;
using Assignment.Modes;
using Assignment.Types;

namespace Assignment.Models
{
    public class AppModel: ModeModel
    {
        public AppModel()
        {
            Modes = new List<Mode>();
        }
        public Mode CurrentMode { get; set; }
        public List<Mode> Modes { get; set; }

        public Mode GetModeByType(ModeType type)
        {
            return Modes.Find(mode => mode.Type == type);
        }

    }
}
