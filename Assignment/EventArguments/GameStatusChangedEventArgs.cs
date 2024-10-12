using Assignment.Types;

namespace Assignment.EventArguments
{
    public class GameStatusChangedEventArgs(GameStatus status) : EventArgs
    {
        public GameStatus status { get; } = status;
    }
}
