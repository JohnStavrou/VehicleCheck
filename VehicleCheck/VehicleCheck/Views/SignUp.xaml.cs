using System;
using System.Linq;
using System.Threading.Tasks;
using VehicleCheck.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VehicleCheck.Models;

namespace VehicleCheck.Views
{
    public sealed partial class SignUp
    {
        private readonly MainViewViewModel _mvvm;
        private string _username;
        private string _password;
        private string _confirmPassword;
        private bool _ok;

        public SignUp()
        {
            InitializeComponent();

            _mvvm = (MainViewViewModel) DataContext;
        }

        private void Back_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void UsernameTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            _username = UsernameTextBox.Text;
            if (_username == "")
                UsernameStar.Visibility = Visibility.Visible;
            else
                UsernameStar.Visibility = Visibility.Collapsed;
            EnableButton();
        }

        private void PasswordTextBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            _password = PasswordTextBox.Password;
            if (_password == "")
                PasswordStar.Visibility = Visibility.Visible;
            else
                PasswordStar.Visibility = Visibility.Collapsed;
            EnableButton();
        }

        private void ConfirmPasswordTextBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            _confirmPassword = ConfirmPasswordTextBox.Password;
            if (_confirmPassword == "")
                ConfirmPasswordStar.Visibility = Visibility.Visible;
            else
                ConfirmPasswordStar.Visibility = Visibility.Collapsed;
            EnableButton();
        }

        public void EnableButton()
        {
            if (UsernameStar.Visibility == Visibility.Collapsed &&
                PasswordStar.Visibility == Visibility.Collapsed &&
                ConfirmPasswordStar.Visibility == Visibility.Collapsed)
            {
                SignUpButton.IsEnabled = true;
            }
            else
                SignUpButton.IsEnabled = false;
        }

        private async void SignUpButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mvvm.Loading = true;
            _ok = false;
            await Check();
            if (!_ok)
                return;

            var user = new User
            {
                Id = Guid.NewGuid().ToString("N"),
                Username = UsernameTextBox.Text,
                Password = App.Hash(PasswordTextBox.Password)
            };
            await App.SyncUsers.InsertAsync(user);
            _mvvm.Loading = false;
            Frame.GoBack();
        }

        public async Task Check()
        {
            if ((await App.SyncUsers.Where(x => x.Username == _username).ToListAsync()).Any())
            {
                Note.Text = "Username already in use!";
                _mvvm.Loading = false;
                return;
            }

            if (_password != _confirmPassword)
            {
                Note.Text = "Passwords don't match!";
                _mvvm.Loading = false;
                return;
            }

            Note.Text = "";
            _ok = true;
        }
    }
}