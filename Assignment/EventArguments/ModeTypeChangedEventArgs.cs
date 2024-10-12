using Assignment.Types;

namespace Assignment.EventArguments
{
    public class ModeTypeChangedEventArgs(ModeType status) : EventArgs
    {
        public ModeType Type { get; } = status;
    }
}
