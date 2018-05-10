using VehicleCheck.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VehicleCheck.Models;

namespace VehicleCheck.Views
{
    public sealed partial class EditVehicle
    {
        private readonly MainViewViewModel _mvvm;
        private string _name;
        private string _licensePlate;
        public Vehicle Vehicle;

        public EditVehicle()
        {
            Vehicle = App.Vehicle;
            InitializeComponent();

            _mvvm = (MainViewViewModel) DataContext;
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
                SaveButton.IsEnabled = true;
            }
            else
                SaveButton.IsEnabled = false;
        }

        private async void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mvvm.Loading = true;

            App.Vehicle.Name = NameTextBox.Text;
            App.Vehicle.LicensePlate = LicensePlateTextBox.Text;
            App.Vehicle.Insurance = InsuranceDatePicker.Date;
            App.Vehicle.Tax = TaxDatePicker.Date;
            App.Vehicle.Mot = MotDatePicker.Date;
            App.Vehicle.GasEmissionsCard = GasEmissionsCardDatePicker.Date;

            await App.SyncVehicles.UpdateAsync(App.Vehicle);
            App.Vehicle = null;

            _mvvm.Loading = false;
            Back_OnClick(sender, e);
        }
    }
}