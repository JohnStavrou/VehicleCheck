using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using VehicleCheck.Models;

namespace VehicleCheck.ViewModels
{
    public class MainViewViewModel : INotifyPropertyChanged
    {
        private bool _cοnnecting;
        private ObservableCollection<Vehicle> _vehicles;

        public bool Cοnnecting
        {
            get { return _cοnnecting; }
            set
            {
                _cοnnecting = value;
                OnPropertyChanged(nameof(Cοnnecting));
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