using System.Linq;
using VehicleCheck.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace VehicleCheck.Views
{
    public sealed partial class SignIn
    {
        private readonly MainViewViewModel _mvvm;
        private string _username;
        private string _password;

        public SignIn()
        {
            InitializeComponent();

            _mvvm = (MainViewViewModel) DataContext;
        }

        private void SignUp_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SignUp));
        }

        private void UsernameTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            _username = UsernameTextBox.Text;
            EnableButton();
        }

        private void PasswordTextBox_OnTextChanged(object sender, RoutedEventArgs e)
       {
            _password = PasswordTextBox.Password;
            EnableButton();
        }

        public void EnableButton()
        {
            if (_username == null || _password == null)
            {
                SignInButton.IsEnabled = false;
                return;
            }

            if (_username != "" && _password != "")
            {
                SignInButton.IsEnabled = true;
                return;
            }

            SignInButton.IsEnabled = false;
        }

        private async void SignIn_OnClick(object sender, RoutedEventArgs e)
        {
            _mvvm.Loading = true;

            App.User = (await App.SyncUsers.Where(x => x.Username == _username && x.Password == App.Hash(_password)).ToListAsync()).FirstOrDefault();

            if (App.User != null)
            {
                _mvvm.Loading = false;
                Frame.Navigate(typeof(MainPage));
            }
            else
                Note.Text = "Incorrect username or password!";
            _mvvm.Loading = false;
        }
    }
}