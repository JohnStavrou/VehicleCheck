using System;
using Microsoft.Azure.Mobile.Server;

namespace VehicleCheckService.DataObjects
{
    public class Vehicle : EntityData
    {
        public string Name { get; set; }
        public string UserId { get; set; }
        public string LicensePlate { get; set; }
        public DateTime Insurance { get; set; }
        public DateTime Tax { get; set; }
        public DateTime Mot { get; set; }
        public DateTime GasEmissionsCard { get; set; }
    }
}