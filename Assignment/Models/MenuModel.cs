using Assignment.EventArguments;
using Assignment.Types;

namespace Assignment.Models
{
    public class MenuModel: ModeModel
    {
        private MenuStatus _status;

        public MenuStatus Status {
            get => _status;

            set
            {
                _status = value;
                _emitStatusChanged();
        
            }
        }

        public event EventHandler<MenuStatusChangedEventArgs>? OnStatusChange;

        private void _emitStatusChanged()
        {
            var eventArgs = new MenuStatusChangedEventArgs(_status);
            OnStatusChange?.Invoke(this, eventArgs);
        }
        
    }
}
