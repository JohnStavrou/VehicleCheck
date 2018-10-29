using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VC_App.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace VC_App
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new SignInPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
