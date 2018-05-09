using System;
using VehicleCheck.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using VehicleCheck.Models;

namespace VehicleCheck.Views
{
    public sealed partial class MainPage
    {
        private readonly MainViewViewModel _mvvm;

        public MainPage()
        {
            InitializeComponent();

            _mvvm = (MainViewViewModel) DataContext;
            _mvvm.Loading = true;
            Fetch();
        }

        public async void Fetch()
        {
            await _mvvm.FetchVehicleData();
            _mvvm.Loading = false;
        }

        private void GridView_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (GridView.SelectedItem == null)
                return;

            GridView.SelectedItem = null;
        }
        
        private void AddVehicle_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddVehicle));
        }

        private async void SignOut_OnClick(object sender, RoutedEventArgs e)
        {
            var result = await new ContentDialog
            {
                Content = "Are you sure you want to sign out of Vehicle Check?",
                CloseButtonText = "No",
                PrimaryButtonText = "Yes"
            }.ShowAsync();

            if (result == ContentDialogResult.Primary)
                Frame.GoBack();
        }

        private void Edit_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private async void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            /*
            var veh = (Vehicle) GridView.SelectedItem;
            if (veh == null)
                return;

            var vehicle = (Vehicle) sender;
            var result = await new ContentDialog
            {
                Content = "Are you sure you want delete vehicle " + vehicle.Name + "?",
                CloseButtonText = "No",
                PrimaryButtonText = "Yes"
            }.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                _mvvm.Loading = true;
                await App.SyncVehicles.DeleteAsync(vehicle);
                //_mvvm.Vehicles.Remove(vehicle);
                _mvvm.Loading = false;
            }*/
        }
    }
}