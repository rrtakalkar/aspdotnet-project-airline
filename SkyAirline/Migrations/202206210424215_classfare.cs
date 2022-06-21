namespace SkyAirline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class classfare : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "EconomyClassFare", c => c.Int(nullable: false));
            AddColumn("dbo.Schedules", "BusinessClassFare", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedules", "BusinessClassFare");
            DropColumn("dbo.Schedules", "EconomyClassFare");
        }
    }
}
