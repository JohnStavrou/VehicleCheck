using System.Collections.ObjectModel;
using System.ComponentModel;
using VehicleCheck.Models;

namespace VehicleCheck.ViewModels
{
    public class VehicleViewViewModel : INotifyPropertyChanged
    {
        private bool _cοnnected;
        private ObservableCollection<Vehicle> _vehicles;

        public bool Cοnnected
        {
            get { return _cοnnected; }
            set
            {
                _cοnnected = value;
                OnPropertyChanged(nameof(Cοnnected));
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

        public VehicleViewViewModel()
        {
            Vehicles = App.Vehicles;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}