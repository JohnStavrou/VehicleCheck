using System;
using VehicleCheck.Models;
using VehicleCheck.ViewModels;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace VehicleCheck
{
    public sealed partial class MainPage : Page
    {
        private readonly VehicleViewViewModel _vvvm;

        public MainPage()
        {
            InitializeComponent();

            _vvvm = (VehicleViewViewModel) DataContext;
        }

        private void OnKeyDown(object sender, KeyRoutedEventArgs e)
        {

        }

        private void GridView_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (GridView.SelectedItem == null)
                return;

            //(new MessageDialog(((Vehicle) GridView.SelectedItem).Name)).ShowAsync();
            GridView.SelectedItem = null;
        }

        private void SignIn_OnClick(object sender, RoutedEventArgs e)
        {//todo fetch vehicles
            _vvvm.Cοnnected = true;

        }

        private void SignUp_OnClick(object sender, RoutedEventArgs e)
        {

        }
        
        private void Add_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private async void SignOut_OnClick(object sender, RoutedEventArgs e)
        {
            var result = await new ContentDialog
            {
                Title = "Vehicle Check",
                Content = "Are you sure you want to sign out of Vehicle Check?",
                CloseButtonText = "Yes",
                PrimaryButtonText = "No"
            }.ShowAsync();

            if (result != ContentDialogResult.Primary)
            {
                _vvvm.Cοnnected = false;
            }
        }

        /*
         public async Task VehicleFetchData()
        {
            Vehicles = await SyncVehicles.ToCollectionAsync();
        }
        */
    }
}