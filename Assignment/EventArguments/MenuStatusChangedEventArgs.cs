using Assignment.Types;

namespace Assignment.EventArguments
{
    public class MenuStatusChangedEventArgs(MenuStatus status) : EventArgs
    {
        public MenuStatus Status { get; } = status;
    }
}
