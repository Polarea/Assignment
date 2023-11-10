// See https://aka.ms/new-console-template for more information
using Inversion_of_Control_Container.Classes;
using Inversion_of_Control_Container.Interfaces;

Console.Title = "Learning Reflection";

var iocContainer = new IoCContainer();
iocContainer.Register<IWaterService, TapWaterService>();
var waterService = iocContainer.Resolve<IWaterService>();

iocContainer.Register<ICoffeeService, CoffeeService>();
var coffeeService = iocContainer.Resolve<ICoffeeService>();

Console.ReadLine();
