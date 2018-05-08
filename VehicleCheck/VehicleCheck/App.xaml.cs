using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VehicleCheck.Models;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Microsoft.WindowsAzure.MobileServices;

namespace VehicleCheck
{
    sealed partial class App
    {
        public MobileServiceClient Client { get; set; }

        public static IMobileServiceTable<User> SyncUsers { get; set; }
        public static IMobileServiceTable<Vehicle> SyncVehicles { get; set; }
        public static MobileServiceCollection<Vehicle, Vehicle> Vehicles { get; set; }

        public App()
        {
            InitializeComponent();
            Suspending += OnSuspending;
           
            Init();
        }

        public async void Init()
        {
            try
            {
                Client = new MobileServiceClient("https://vehiclecheck.azurewebsites.net");

                SyncVehicles = Client.GetTable<Vehicle>();
                SyncUsers = Client.GetTable<User>();
                await VehicleFetchData();
            }
            catch
            {
                Console.WriteLine("Database Connection Error!");
            }
        }

        public async Task VehicleFetchData()
        {/*
            var user = new User
            {
                Id = Guid.NewGuid().ToString("N"),
                Username = "John"
            };
            await SyncUsers.InsertAsync(user);

            var vehicle = new Vehicle
            {
                Id = Guid.NewGuid().ToString("N"),
                Name = "Αμαξι",
                UserId = user.Id,
                LicensePlate = "rjng34g",
                Insurance = DateTime.Now,
                Tax = DateTime.Now,
                Mot = DateTime.Now,
                GasEmissionsCard = DateTime.Now

            };
            await SyncVehicles.InsertAsync(vehicle);*/

            Vehicles = await SyncVehicles.ToCollectionAsync();
            var mpla = await SyncUsers.ToCollectionAsync();
            var m = 1;
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame == null)
            {
                rootFrame = new Frame();
                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {

                }

                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);

                ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(10000, 200));
                Window.Current.Activate();
            }
        }

        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            e.SuspendingOperation.GetDeferral().Complete();
        }
    }
}