namespace SkyAirline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityID = c.Int(nullable: false, identity: true),
                        CityName = c.String(nullable: false, maxLength: 100),
                        Country = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CityID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cities");
        }
    }
}
