using System.ComponentModel;

//Code adapted from "The World's Simplest C# WPF MVVM Example"
//by Mark Withall 2013-03-01
//https://www.markwithall.com/programming/2013/03/01/worlds-simplest-csharp-wpf-mvvm-example.html
namespace CaseConverterMVVM.ViewModels
{
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChangedEvent(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
