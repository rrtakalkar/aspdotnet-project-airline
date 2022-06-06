using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using SkyAirline.Models;

namespace SkyAirline.BLL
{
    public class AirportBL : IDisposable
    {
        SkyAirlineContext db = new SkyAirlineContext();

        public IQueryable<Airport> GetAirports()
        {
            var query = db.Airports.Distinct();
            return query;
        }

        public void InsertAirport(ModelMethodContext context)
        {
            var item = new Airport();

            context.TryUpdateModel(item);
            if (context.ModelState.IsValid)
            {
                db.Airports.Add(item);
                db.SaveChanges();
            }
        }

        public void UpdateAirport(int airportID, ModelMethodContext context)
        {
            Airport item = null;
            item = db.Airports.Find(airportID);

            if (item == null)
            {
                context.ModelState.AddModelError("", String.Format("Item with id {0} was not found", airportID));
                return;
            }
            context.TryUpdateModel(item);
            if (context.ModelState.IsValid)
            {
                db.SaveChanges();
            }
        }

        public void DeleteAirport(int airportID, ModelMethodContext context)
        {
            var item = new Airport { AirportID = airportID };
            db.Entry(item).State = EntityState.Deleted;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                context.ModelState.AddModelError("",
                    String.Format("Item with id {0} no longer exists in the database.", airportID));
            }
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}