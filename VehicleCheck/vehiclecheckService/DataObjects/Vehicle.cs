using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Azure.Mobile.Server;

namespace vehiclecheckService.DataObjects
{
    public class Vehicle : EntityData
    {
        public string Name { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public string UserId { get; set; }
        public string LicensePlate { get; set; }
        public DateTime Insurance { get; set; }
        public DateTime Tax { get; set; }
        public DateTime Mot { get; set; }
        public DateTime GasEmissionsCard { get; set; }
    }
}