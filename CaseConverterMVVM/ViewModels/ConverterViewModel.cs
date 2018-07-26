using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CaseConverterMVVM.Models;

namespace CaseConverterMVVM.ViewModels
{
    public class ConverterViewModel : ObservableObject
    {
        //Internal fields
        private string _pascalText;
        private string _camelText;
        private string _spacedText;

        //Event-enabled properties
        public string PascalText
        {
            get
            {
                return _pascalText;
            }
            set
            {
                _pascalText = value;
                RaisePropertyChangedEvent("PascalText");
            }
        }
        public string CamelText
        {
            get
            {
                return _camelText;
            }
            set
            {
                _camelText = value;
                RaisePropertyChangedEvent("CamelText");
            }
        }
        public string SpacedText
        {
            get
            {
                return _spacedText;
            }
            set
            {
                _spacedText = value;
                RaisePropertyChangedEvent("SpacedText");
            }
        }

        //Commands invokeable from Views
        public ICommand ConvertFromPascalCommand
        {
            get { return new DelegateCommand(ConvertFromPascal); }
        }
        public ICommand ConvertFromCamelCommand
        {
            get { return new DelegateCommand(ConvertFromCamel); }
        }
        public ICommand ConvertFromSpacedCommand
        {
            get { return new DelegateCommand(ConvertFromSpaced); }
        }

        //Conversion functions, called with commands
        private void ConvertFromPascal()
        {
            CamelText = TextConverter.ConvertPascalToCamel(PascalText);
            SpacedText = TextConverter.ConvertPascalToSpaced(PascalText);
        }
        private void ConvertFromCamel()
        {
            PascalText = TextConverter.ConvertCamelToPascal(CamelText);
            SpacedText = TextConverter.ConvertPascalToSpaced(PascalText);
        }
        private void ConvertFromSpaced()
        {
            PascalText = TextConverter.ConvertSpacedToPascal(SpacedText);
            CamelText = TextConverter.ConvertPascalToCamel(PascalText);
        }
    }
}
