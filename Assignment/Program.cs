using Assignment.Controllers;
using Assignment.Models;
using Assignment.Views;

var model = new AppModel();
var view = new AppView(model);
var controller = new AppController(model, view);

controller.Start();

