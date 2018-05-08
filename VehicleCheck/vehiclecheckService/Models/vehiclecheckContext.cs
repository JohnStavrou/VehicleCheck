using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.Azure.Mobile.Server.Tables;
using VehicleCheckService.DataObjects;

namespace VehicleCheckService.Models
{
    public class VehicleCheckContext : DbContext
    {
        private const string connectionStringName = "Name=MS_TableConnectionString";

        public VehicleCheckContext() : base(connectionStringName)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));
        }
    }
}