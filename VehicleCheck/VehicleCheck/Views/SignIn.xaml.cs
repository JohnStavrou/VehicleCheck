using System;
using System.Linq;
using VehicleCheck.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace VehicleCheck.Views
{
    public sealed partial class SignIn
    {
        private readonly MainViewViewModel _mvvm;

        public SignIn()
        {
            InitializeComponent();

            _mvvm = (MainViewViewModel) DataContext;
        }
        
        private async void SignIn_OnClick(object sender, RoutedEventArgs e)
        {
            if (UsernameTextBox.Text == "" || PasswordTextBox.Password == "")
                return;

            _mvvm.Loading = true;

            var username = UsernameTextBox.Text;
            var password = PasswordTextBox.Password; // todo hash password
            App.User = (await App.SyncUsers.Where(x => x.Username == username && x.Password == password).ToListAsync()).FirstOrDefault();

            if (App.User != null)
            {
                _mvvm.Loading = false;
                Frame.Navigate(typeof(MainPage));
            }
            else
            {
                await new ContentDialog
                {
                    Content = "Incorrect username or password!",
                    CloseButtonText = "OK",
                }.ShowAsync();
            }
            _mvvm.Loading = false;
        }

        private void SignUp_OnClick(object sender, RoutedEventArgs e)
        {

        }
    }
}