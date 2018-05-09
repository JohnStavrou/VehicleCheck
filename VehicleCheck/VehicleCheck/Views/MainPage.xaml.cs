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
        private Vehicle _vehicle;
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
            _vehicle = (Vehicle) GridView.SelectedItem;
            if (_vehicle == null)
                return;

            var item = (UIElement) e.OriginalSource;
            FlyOut.ShowAt(item, e.GetPosition(item));
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
            {
                App.User = null;
                Frame.GoBack();
            }
        }

        private void Edit_OnClick(object sender, RoutedEventArgs e)
        {
            GridView.SelectedItem = null;
        }

        private async void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            var result = await new ContentDialog
            {
                Content = "Are you sure you want delete vehicle " + _vehicle.Name + "?",
                CloseButtonText = "No",
                PrimaryButtonText = "Yes"
            }.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                _mvvm.Loading = true;
                await App.SyncVehicles.DeleteAsync(_vehicle);
                _mvvm.Vehicles.Remove(_vehicle);
                _mvvm.Loading = false;
            }
            GridView.SelectedItem = null;
        }

        private void Grid_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            GridView.SelectedItem = null;
        }
    }
}