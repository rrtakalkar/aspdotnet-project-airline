namespace SkyAirline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class availableseats : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "AvailableEconomyClassSeats", c => c.Int(nullable: false));
            AddColumn("dbo.Schedules", "AvailableBusinessClassSeats", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedules", "AvailableBusinessClassSeats");
            DropColumn("dbo.Schedules", "AvailableEconomyClassSeats");
        }
    }
}
