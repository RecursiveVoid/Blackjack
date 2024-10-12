using Assignment.EventArguments;
using Assignment.Modes;
using Assignment.Types;

namespace Assignment.Models
{
    public class AppModel: ModeModel
    {
        public AppModel()
        {
            modes = new List<Mode>();
        }
        public Mode CurrentMode { get; set; }
        public List<Mode> modes { get; set; }

        public Mode GetModeByType(ModeType type)
        {
            return modes.Find(mode => mode.Type == type);
        }

    }
}
