using Assignment.EventArguments;
using Assignment.Models;

namespace Assignment.Views
{
  
    // This sounds a little funny when you concider an AppView in a console application.
    // If it was a 2d/3d game engine, here we would mount/unmount the views instead. 
    public class AppView
    {
        private AppModel _model;

        public AppView(AppModel model)
        {
            _model = model;
            _model.OnModeTypeChanged += _handlChangeModeType;
        }

        private void _handlChangeModeType(object sender, ModeTypeChangedEventArgs args)
        {
           Console.Clear();
        }

    }
}
