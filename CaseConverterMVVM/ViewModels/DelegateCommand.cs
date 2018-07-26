using System;
using System.Windows.Input;

//Code adapted from "The World's Simplest C# WPF MVVM Example"
//by Mark Withall 2013-03-01
//https://www.markwithall.com/programming/2013/03/01/worlds-simplest-csharp-wpf-mvvm-example.html
namespace CaseConverterMVVM.ViewModels
{
    public class DelegateCommand : ICommand
    {
        private readonly Action _action;

        public DelegateCommand(Action action)
        {
            _action = action;
        }

        public void Execute(object parameter)
        {
            _action();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        
        public event EventHandler CanExecuteChanged { add { } remove { } }
    }
}
