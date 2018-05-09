using System;
using System.Linq;
using VehicleCheck.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace VehicleCheck.Views
{
    public sealed partial class NewUser : Page
    {
        private readonly MainViewViewModel _mvvm;

        public NewUser()
        {
            InitializeComponent();

            _mvvm = (MainViewViewModel) DataContext;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}