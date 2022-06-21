namespace SkyAirline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Airports",
                c => new
                    {
                        AirportID = c.Int(nullable: false, identity: true),
                        AirportCode = c.String(nullable: false, maxLength: 100),
                        CityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AirportID)
                .ForeignKey("dbo.Cities", t => t.CityID, cascadeDelete: false)
                .Index(t => t.CityID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityID = c.Int(nullable: false, identity: true),
                        CityName = c.String(nullable: false, maxLength: 100),
                        Country = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CityID);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingID = c.Int(nullable: false, identity: true),
                        BookingDate = c.DateTime(nullable: false),
                        ScheduleID = c.Int(nullable: false),
                        PassengerID = c.Int(nullable: false),
                        BookingStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingID)
                .ForeignKey("dbo.Passengers", t => t.PassengerID, cascadeDelete: false)
                .ForeignKey("dbo.Schedules", t => t.ScheduleID, cascadeDelete: false)
                .Index(t => t.ScheduleID)
                .Index(t => t.PassengerID);
            
            CreateTable(
                "dbo.Passengers",
                c => new
                    {
                        PassengerID = c.Int(nullable: false, identity: true),
                        PassengerName = c.String(nullable: false, maxLength: 100),
                        PassengerEmail = c.String(nullable: false, maxLength: 100),
                        PassengerMobileNo = c.String(nullable: false, maxLength: 10),
                        PassengerAddress = c.String(nullable: false, maxLength: 200),
                        PassengerGender = c.Int(nullable: false),
                        PassengerIdentityType = c.Int(nullable: false),
                        PassengerIdentity = c.String(nullable: false, maxLength: 100),
                        PassengerPassword = c.String(nullable: false, maxLength: 10),
                        PassengerDateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PassengerID);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleID = c.Int(nullable: false, identity: true),
                        FlightID = c.Int(nullable: false),
                        DepartureDate = c.DateTime(nullable: false),
                        ArrivalDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ScheduleID)
                .ForeignKey("dbo.Flights", t => t.FlightID, cascadeDelete: false)
                .Index(t => t.FlightID);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        FlightID = c.Int(nullable: false, identity: true),
                        FlightNumber = c.String(nullable: false, maxLength: 10),
                        DepartureID = c.Int(nullable: false),
                        ArrivalID = c.Int(nullable: false),
                        EconomyClassSeats = c.Int(nullable: false),
                        BusinessClassSeats = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FlightID)
                .ForeignKey("dbo.Airports", t => t.ArrivalID, cascadeDelete: false)
                .ForeignKey("dbo.Airports", t => t.DepartureID, cascadeDelete: false)
                .Index(t => t.DepartureID)
                .Index(t => t.ArrivalID);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentID = c.Int(nullable: false, identity: true),
                        PaymentDate = c.DateTime(nullable: false),
                        PaymentMode = c.Int(nullable: false),
                        PaymentAmount = c.Int(nullable: false),
                        BookingID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentID)
                .ForeignKey("dbo.Bookings", t => t.BookingID, cascadeDelete: false)
                .Index(t => t.BookingID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "BookingID", "dbo.Bookings");
            DropForeignKey("dbo.Bookings", "ScheduleID", "dbo.Schedules");
            DropForeignKey("dbo.Schedules", "FlightID", "dbo.Flights");
            DropForeignKey("dbo.Flights", "DepartureID", "dbo.Airports");
            DropForeignKey("dbo.Flights", "ArrivalID", "dbo.Airports");
            DropForeignKey("dbo.Bookings", "PassengerID", "dbo.Passengers");
            DropForeignKey("dbo.Airports", "CityID", "dbo.Cities");
            DropIndex("dbo.Payments", new[] { "BookingID" });
            DropIndex("dbo.Flights", new[] { "ArrivalID" });
            DropIndex("dbo.Flights", new[] { "DepartureID" });
            DropIndex("dbo.Schedules", new[] { "FlightID" });
            DropIndex("dbo.Bookings", new[] { "PassengerID" });
            DropIndex("dbo.Bookings", new[] { "ScheduleID" });
            DropIndex("dbo.Airports", new[] { "CityID" });
            DropTable("dbo.Payments");
            DropTable("dbo.Flights");
            DropTable("dbo.Schedules");
            DropTable("dbo.Passengers");
            DropTable("dbo.Bookings");
            DropTable("dbo.Cities");
            DropTable("dbo.Airports");
        }
    }
}
