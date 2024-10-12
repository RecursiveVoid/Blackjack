using Assignment.Models;
using Assignment.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Controllers
{
    public abstract class ModeController(ModeModel model, ModeView view)
    {
        protected ModeView _view = view;
        protected ModeModel _model = model;
        public abstract void Start();
        public abstract void Stop();
    }

   
}
