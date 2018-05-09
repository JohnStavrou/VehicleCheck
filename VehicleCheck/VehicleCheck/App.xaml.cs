﻿using System;
using VehicleCheck.Models;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Microsoft.WindowsAzure.MobileServices;
using VehicleCheck.Views;

namespace VehicleCheck
{
    sealed partial class App
    {
        public MobileServiceClient Client { get; set; }

        public static IMobileServiceTable<User> SyncUsers { get; set; }
        public static IMobileServiceTable<Vehicle> SyncVehicles { get; set; }

        public static User User { get; set; }

        public App()
        {
            InitializeComponent();
            Suspending += OnSuspending;
           
            Init();
        }

        public void Init()
        {
            try
            {
                Client = new MobileServiceClient("https://vehiclecheck.azurewebsites.net");

                SyncUsers = Client.GetTable<User>();
                SyncVehicles = Client.GetTable<Vehicle>();
            }
            catch
            {
                Console.WriteLine("Database Connection Error!");
            }
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
                    rootFrame.Navigate(typeof(SignIn), e.Arguments);

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