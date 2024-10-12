using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Views
{
    // Lets imagine this as an Container where we can show and hide during rendering.
    public abstract class ModeView(ModeModel model)
    {
        protected ModeModel _model = model;

        protected abstract void _show();

        protected abstract void _hide();
    }
}
