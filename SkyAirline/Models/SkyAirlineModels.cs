using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace SkyAirline.Models
{
    public class SkyAirlineContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
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

    public enum Country
    {
        India
    }
}