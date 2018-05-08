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

        private async void SignIn_OnClick(object sender, RoutedEventArgs e)
        {
            if (UsernameTextBox.Text == "")
                return;

            var username = UsernameTextBox.Text;
            var password = PasswordTextBox.Password;

            //loading
            App.User = (await App.SyncUsers.Where(x => x.Username == username && x.Password == password).ToListAsync()).FirstOrDefault();

            if(App.User != null)
                await _mvvm.FetchVehicleData();
            else
            {
                //kodikas efae akuro
            }
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
                _mvvm.Cοnnected = false;
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