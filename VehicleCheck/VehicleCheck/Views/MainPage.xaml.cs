using System;
using System.Linq;
using VehicleCheck.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace VehicleCheck.Views
{
    public sealed partial class MainPage : Page
    {
        private readonly MainViewViewModel _mvvm;

        public MainPage()
        {
            InitializeComponent();

            _mvvm = (MainViewViewModel) DataContext;
            _mvvm.Cοnnecting = true;
            Fetch();
        }

        public async void Fetch()
        {
            await _mvvm.FetchVehicleData();
            _mvvm.Cοnnecting = false;
        }

        private void GridView_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (GridView.SelectedItem == null)
                return;

            //(new MessageDialog(((Vehicle) GridView.SelectedItem).Name)).ShowAsync();
            GridView.SelectedItem = null;
        }
        
        private void AddVehicle_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(NewUser));
            
        }

        private async void SignOut_OnClick(object sender, RoutedEventArgs e)
        {
            var result = await new ContentDialog
            {
                Title = "Vehicle Check",
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

        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {

        }
    }
}