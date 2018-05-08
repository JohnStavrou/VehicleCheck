using Microsoft.Azure.Mobile.Server;

namespace VehicleCheckService.DataObjects
{
    public class User : EntityData
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}