using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.Azure.Mobile.Server.Tables;
using vehiclecheckService.DataObjects;

namespace vehiclecheckService.Models
{
    public class vehiclecheckContext : DbContext
    {
        private const string connectionStringName = "Name=MS_TableConnectionString";

        public vehiclecheckContext() : base(connectionStringName)
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