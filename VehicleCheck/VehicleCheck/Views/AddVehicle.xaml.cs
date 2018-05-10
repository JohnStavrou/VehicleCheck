using System;
using VehicleCheck.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VehicleCheck.Models;

namespace VehicleCheck.Views
{
    public sealed partial class AddVehicle
    {
        private readonly MainViewViewModel _mvvm;
        private string _name;
        private string _licensePlate;

        public AddVehicle()
        {
            InitializeComponent();

            _mvvm = (MainViewViewModel)DataContext;
        }

        private void Back_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void NameTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            _name = NameTextBox.Text;
            if (_name == "")
                NameError.Visibility = Visibility.Visible;
            else
                NameError.Visibility = Visibility.Collapsed;
            EnableButton();
        }

        private void LicensePlateTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            _licensePlate = LicensePlateTextBox.Text;
            if (_licensePlate == "")
                LicensePlateError.Visibility = Visibility.Visible;
            else
                LicensePlateError.Visibility = Visibility.Collapsed;
            EnableButton();
        }

        public void EnableButton()
        {
            if (NameError.Visibility == Visibility.Collapsed &&
                LicensePlateError.Visibility == Visibility.Collapsed)
            {
                AddButton.IsEnabled = true;
            }
            else
                AddButton.IsEnabled = false;
        }

        private async void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mvvm.Loading = true;
            var vehicle = new Vehicle
            {
                Id = Guid.NewGuid().ToString("N"),
                Name = NameTextBox.Text,
                UserId = App.User.Id,
                LicensePlate = LicensePlateTextBox.Text,
                Insurance = InsuranceDatePicker.Date,
                Tax = TaxDatePicker.Date,
                Mot = MotDatePicker.Date,
                GasEmissionsCard = GasEmissionsCardDatePicker.Date
            };
            await App.SyncVehicles.InsertAsync(vehicle);
            _mvvm.Loading = false;
            Back_OnClick(sender, e);
        }
    }
}