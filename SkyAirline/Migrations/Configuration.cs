namespace SkyAirline.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SkyAirline.Models.SkyAirlineContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SkyAirline.Models.SkyAirlineContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Cities.AddOrUpdate(
                 new Models.City
                 {
                     CityName = "Delhi",
                     Country = Models.Country.India
                 },
                 new Models.City
                 {
                     CityName = "Mumbai",
                     Country = Models.Country.India
                 },
                 new Models.City
                 {
                     CityName = "Pune",
                     Country = Models.Country.India
                 },
                 new Models.City
                 {
                     CityName = "Chennai",
                     Country = Models.Country.India
                 },
                 new Models.City
                 {
                     CityName = "Goa",
                     Country = Models.Country.India
                 }
            );

            context.SaveChanges();
        }
    }
}
