using Assignment.EventArguments;
using Assignment.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Models
{
    public class ModeModel
    {
        private ModeType _modeType;
        public ModeType ModeType
        {
            get => _modeType;

            set
            {
                if (_modeType != value)
                {
                    _modeType = value;
                    _emitModeTypeChanged();
                }
            }
        }

        public event EventHandler<ModeTypeChangedEventArgs>? OnModeTypeChanged;

        private void _emitModeTypeChanged()
        {
            var eventArgs = new ModeTypeChangedEventArgs(_modeType);
            OnModeTypeChanged?.Invoke(this, eventArgs);
        }

    }
}
