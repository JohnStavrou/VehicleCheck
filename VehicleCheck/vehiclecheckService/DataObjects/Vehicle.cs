using System;
using Microsoft.Azure.Mobile.Server;

namespace VehicleCheckService.DataObjects
{
    public class Vehicle : EntityData
    {
        public string Name { get; set; }
        public string UserId { get; set; }
        public string LicensePlate { get; set; }
        public DateTimeOffset Insurance { get; set; }
        public DateTimeOffset Tax { get; set; }
        public DateTimeOffset Mot { get; set; }
        public DateTimeOffset GasEmissionsCard { get; set; }
    }
}