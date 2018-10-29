using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using VC_App.Models;

namespace VC_App.Services
{
    public class DataService : IDataService<Vehicle>
    {

        public MobileServiceClient Client { get; set; }

        public static IMobileServiceTable<User> SyncUsers { get; set; }
        public static IMobileServiceTable<Vehicle> SyncVehicles { get; set; }

        public static User User { get; set; }


        List<Vehicle> Vehicles;

        public DataService()
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
            /*
            Vehicles = new List<Vehicle>();
            

            foreach (var Vehicle in mockVehicles)
            {
                Vehicles.Add(Vehicle);
            }*/
        }

        public async Task<bool> AddVehicleAsync(Vehicle vehicle)
        {
            Vehicles.Add(vehicle);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateVehicleAsync(Vehicle vehicle)
        {
            var oldVehicle = Vehicles.Where((Vehicle arg) => arg.Id == vehicle.Id).FirstOrDefault();
            Vehicles.Remove(oldVehicle);
            Vehicles.Add(vehicle);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteVehicleAsync(string id)
        {
            var oldVehicle = Vehicles.Where((Vehicle arg) => arg.Id == id).FirstOrDefault();
            Vehicles.Remove(oldVehicle);

            return await Task.FromResult(true);
        }

        public async Task<Vehicle> GetVehicleAsync(string id)
        {
            return await Task.FromResult(Vehicles.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Vehicles);
        }

        public string Hash(string password)
        {
            var sb = new StringBuilder();
            foreach (var b in SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password)))
                sb.Append(b.ToString("x2"));
            return sb.ToString();
        }
    }
}