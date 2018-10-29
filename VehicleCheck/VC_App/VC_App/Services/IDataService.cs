using System.Collections.Generic;
using System.Threading.Tasks;

namespace VC_App.Services
{
    public interface IDataService<T>
    {
        Task<bool> AddVehicleAsync(T vehicle);
        Task<bool> UpdateVehicleAsync(T vehicle);
        Task<bool> DeleteVehicleAsync(string id);
        Task<T> GetVehicleAsync(string id);
        Task<IEnumerable<T>> GetVehiclesAsync(bool forceRefresh = false);
    }
}
