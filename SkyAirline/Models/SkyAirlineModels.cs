using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace SkyAirline.Models
{
    public class SkyAirlineContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Airport> Airports { get; set; }
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
    }

    public enum Country
    {
        India
    }
}