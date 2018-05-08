using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace VehicleCheck.Models
{
    public sealed class Vehicle : INotifyPropertyChanged
    {
        private string _id;
        private string _name;
        private User _user;
        private string _userId;
        private string _licensePlate;
        private DateTime _insurance;
        private DateTime _tax;
        private DateTime _mot;
        private DateTime _gasEmissionsCard;

        [JsonProperty("id")]
        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged("User");
            }
        }

        public string UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                OnPropertyChanged("UserId");
            }
        }

        public string LicensePlate
        {
            get { return _licensePlate; }
            set
            {
                _licensePlate = value;
                OnPropertyChanged("LicensePlate");
            }
        }

        public DateTime Insurance
        {
            get { return _insurance; }
            set
            {
                _insurance = value;
                OnPropertyChanged("Insurance");
            }
        }

        public DateTime Tax
        {
            get { return _tax; }
            set
            {
                _tax = value;
                OnPropertyChanged("Tax");
            }
        }

        public DateTime Mot
        {
            get { return _mot; }
            set
            {
                _mot = value;
                OnPropertyChanged("Mot");
            }
        }

        public DateTime GasEmissionsCard
        {
            get { return _gasEmissionsCard; }
            set
            {
                _gasEmissionsCard = value;
                OnPropertyChanged("GasEmissionsCard");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}