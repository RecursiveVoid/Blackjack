using Assignment.Types;

namespace Assignment.EventArguments
{
    public class MenuStatusChangedEventArgs(MenuStatus status) : EventArgs
    {
        public MenuStatus status { get; } = status;
    }
}
