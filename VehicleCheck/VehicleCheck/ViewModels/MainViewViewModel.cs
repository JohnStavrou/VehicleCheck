using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using VehicleCheck.Models;

namespace VehicleCheck.ViewModels
{
    public class MainViewViewModel : INotifyPropertyChanged
    {
        private bool _loading;
        private ObservableCollection<Vehicle> _vehicles;
        private Vehicle _vehicle;

        public bool Loading
        {
            get { return _loading; }
            set
            {
                _loading = value;
                OnPropertyChanged(nameof(Loading));
            }
        }

        public ObservableCollection<Vehicle> Vehicles
        {
            get { return _vehicles; }
            set
            {
                _vehicles = value;
                OnPropertyChanged(nameof(Vehicles));
            }
        }

        public async Task FetchVehicleData()
        {
            Vehicles = new ObservableCollection<Vehicle>(await App.SyncVehicles.Where(x => x.UserId == App.User.Id).ToListAsync());
            /*foreach (var vehicle in Vehicles)
            {
                Task.Run(() =>
                {
                    _vehicle = vehicle;
                    vehicle.Timer = new DispatcherTimer();
                    vehicle.Timer.Interval = new TimeSpan(0, 0, 1);
                    vehicle.Basetime = 60;
                    vehicle.Timer.Tick += Timer_Tick;
                    vehicle.Timer.Start();
                });
            }*/
        }
        /*
        private void Timer_Tick(object sender, object e)
        {
            _vehicle.Basetime--;
            if (_vehicle.Basetime == 0)
                _vehicle.Timer.Stop();
        }*/

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}