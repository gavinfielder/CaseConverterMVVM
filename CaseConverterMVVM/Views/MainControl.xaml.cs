using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CaseConverterMVVM.Views
{
    /// <summary>
    /// Interaction logic for MainControl.xaml
    /// </summary>
    public partial class MainControl : UserControl
    {
        public MainControl()
        {
            InitializeComponent();
        }
        /*
        public void PascalTextChanged(object sender, TextChangedEventArgs e)
        {
            //Only trigger if user is changing pascal text
            if (PascalText.IsFocused)
            {
                var binding = ((TextBox)sender).GetBindingExpression(TextBox.TextProperty);
                binding.UpdateSource();
            }
        }

        public void CamelTextChanged(object sender, TextChangedEventArgs e)
        {
            //Only trigger if user is changing pascal text
            if (CamelText.IsFocused)
            {
                var binding = ((TextBox)sender).GetBindingExpression(TextBox.TextProperty);
                binding.UpdateSource();
            }
        }

        public void SpacedTextChanged(object sender, TextChangedEventArgs e)
        {
            //Only trigger if user is changing spaced text
            if (SpacedText.IsFocused)
            {
                var binding = ((TextBox)sender).GetBindingExpression(TextBox.TextProperty);
                binding.UpdateSource();
            }
        }
        */
    }
}
