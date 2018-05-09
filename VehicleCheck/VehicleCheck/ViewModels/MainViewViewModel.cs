using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using VehicleCheck.Models;

namespace VehicleCheck.ViewModels
{
    public class MainViewViewModel : INotifyPropertyChanged
    {
        private bool _loading;
        private ObservableCollection<Vehicle> _vehicles;

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
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}