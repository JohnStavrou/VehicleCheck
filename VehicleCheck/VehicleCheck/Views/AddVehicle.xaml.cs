using System;
using VehicleCheck.ViewModels;
using Windows.UI.Xaml;
using VehicleCheck.Models;

namespace VehicleCheck.Views
{
    public sealed partial class AddVehicle
    {
        private readonly MainViewViewModel _mvvm;

        public AddVehicle()
        {
            InitializeComponent();

            _mvvm = (MainViewViewModel)DataContext;
        }

        private void Back_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private async void Add_OnClick(object sender, RoutedEventArgs e)
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
            _mvvm.Loading = true;
            Back_OnClick(sender, e);
        }
    }
}