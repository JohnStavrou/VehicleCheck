namespace VehicleCheckService.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Email");
        }
    }
}