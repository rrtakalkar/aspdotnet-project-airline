using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyAirline.Models
{
    public class SkyAirlineContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payment { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Flight>()
                .HasOptional<Airport>(f => f.Departure)
                .WithRequired()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Flight>()
                .HasOptional<Airport>(f => f.Arrival)
                .WithRequired()
                .WillCascadeOnDelete(false);*/
        }

    }

    public class City
    {
        [Key, Display(Name = "ID")]
        [ScaffoldColumn(false)]
        public int CityID { get; set; }

        [Required, StringLength(100), Display(Name = "City Name")]
        public string CityName { get; set; }

        [EnumDataType(typeof(Country)), Display(Name = "Country")]
        public Country Country { get; set; }

    }

    public class Airport
    {
        [Key, Display(Name = "ID")]
        [ScaffoldColumn(false)]
        public int AirportID { get; set; }

        [Required, StringLength(100), Display(Name = "Airport Code")]
        public string AirportCode { get; set; }

        [Required, Display(Name = "City")]
        public int CityID { get; set; }

        public virtual City AirportLocation { get; set; }

        public string Location()
        {
            return AirportCode + " - " + AirportLocation.CityName + " - " + AirportLocation.Country;
        } 
    }

    public class Flight
    {
        [Key, Display(Name = "ID")]
        [ScaffoldColumn(false)]
        public int FlightID { get; set; }

        [Required, StringLength(10), Display(Name = "Flight Number")]
        public string FlightNumber { get; set; }

        [Required, Display(Name = "Departure Location")]
        [ForeignKey("Departure")]
        public int DepartureID { get; set; }

        [Required, Display(Name = "Arrival Location")]
        [ForeignKey("Arrival")]
        public int ArrivalID { get; set; }

        [Required, Display(Name = "Economy Class Seats")]
        public int EconomyClassSeats { get; set; }

        [Required, Display(Name = "Business Class Seats")]
        public int BusinessClassSeats { get; set; }
        
        public virtual Airport Departure { get; set; }
        
        public virtual Airport Arrival { get; set; }

        // public virtual ICollection<Schedule> schedules { get; set; }
    }

    public class Schedule
    {
        [Key, Display(Name = "ID")]
        [ScaffoldColumn(false)]
        public int ScheduleID { get; set; }

        [Required, Display(Name = "Flight ID")]
        public int FlightID { get; set; }

        [Required, Display(Name = "Departure Date")]
        public DateTime DepartureDate { get; set; }

        [Required, Display(Name = "Arrival Date")]
        public DateTime ArrivalDate { get; set; }

        [Required, Display(Name = "Economy Class Seat Fare")]
        public int EconomyClassFare { get; set; }

        [Required, Display(Name = "Business Class Seat Fare")]
        public int BusinessClassFare { get; set; }

        [Required, Display(Name = "Available Economy Class Seats")]
        public int AvailableEconomyClassSeats { get; set; }

        [Required, Display(Name = "Available Business Class Seats")]
        public int AvailableBusinessClassSeats { get; set; }

        public virtual Flight Flight { get; set; }



        // public virtual ICollection<Booking> bookings { get; set; }

    }

    public class Booking
    {
        [Key, Display(Name = "ID")]
        [ScaffoldColumn(false)]
        public int BookingID { get; set; }

        [Required, Display(Name = "Booking Date")]
        public DateTime BookingDate { get; set; }

        [Required, Display(Name = "Flight ID")]
        public int ScheduleID { get; set; }
        
        [Required, Display(Name = "Passenger ID")]
        public int PassengerID { get; set; }

        [Required, Display(Name = "Booking Status")]
        [EnumDataType(typeof(BookingStatus))]
        public BookingStatus BookingStatus { get; set; }

        public virtual Schedule Schedule { get; set; }

        public virtual Passenger Passenger { get; set; }

        // public virtual ICollection<Payment> payments { get; set; }

    }

    public class Payment
    {
        [Key, Display(Name = "ID")]
        [ScaffoldColumn(false)]
        public int PaymentID { get; set; }

        [Required, Display(Name = "Payment Date")]
        public DateTime PaymentDate { get; set; }

        [Required, Display(Name = "Payment Mode")]
        [EnumDataType(typeof(PaymentMode))]
        public PaymentMode PaymentMode { get; set; }

        [Required, Display(Name = "Amount")]
        public int PaymentAmount { get; set; }

        [Required, Display(Name = "Booking Date")]
        public int BookingID { get; set; }

        public virtual Booking Booking { get; set; }

    }

    public class Passenger
    {
        [Key, Display(Name = "ID")]
        [ScaffoldColumn(false)]
        public int PassengerID { get; set; }

        [Required, StringLength(100), Display(Name = "Name")]
        public string PassengerName { get; set; }

        [Required, StringLength(100), Display(Name = "Email")]
        public string PassengerEmail { get; set; }

        [Required, StringLength(10), Display(Name = "Mobile No.")]
        public string PassengerMobileNo { get; set; }

        [Required, StringLength(200), Display(Name = "Address")]
        public string PassengerAddress { get; set; }

        [Required, EnumDataType(typeof(Gender)),  Display(Name = "Gender")]
        public Gender PassengerGender { get; set; }

        [Required, EnumDataType(typeof(Identity)), Display(Name = "Identity Type")]
        public Identity PassengerIdentityType { get; set; }

        [Required, StringLength(100), Display(Name = "Identity Value")]
        public string PassengerIdentity { get; set; }

        [Required, StringLength(10), Display(Name = "Password")]
        public string PassengerPassword { get; set; }

        [Required, Display(Name = "Date Of Birth")]
        public DateTime PassengerDateOfBirth { get; set; }

        // public virtual ICollection<Booking> bookings { get; set; }

    }

    public enum SeatClass
    {
        Economy,
        Business
    }

    public enum BookingStatus
    {
        Confirm,
        Waiting,
        PaymentFailed
    }

    public enum PaymentMode    {
        UPI,
        CreditCard,
        DebitCard,
        NetBanking,
        Cash
    }

    public enum Identity
    {
        VoterId,
        Passport,
        Aadhar
    }

    public enum Gender
    {
        Male,
        Female
    }

    public enum Country
    {
        India
    }

    
}