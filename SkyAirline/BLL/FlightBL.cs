using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using SkyAirline.Models;

namespace SkyAirline.BLL
{
    public class FlightBL : IDisposable
    {
        SkyAirlineContext db = new SkyAirlineContext();

        public IQueryable<Flight> GetFlights()
        {
            var query = db.Flights.Distinct();
            return query;
        }

        public void InsertAirport(ModelMethodContext context)
        {
            var item = new Flight();

            context.TryUpdateModel(item);
            if (context.ModelState.IsValid)
            {
                db.Flights.Add(item);
                db.SaveChanges();
            }
        }

        public void UpdateFlight(int flightID, ModelMethodContext context)
        {
            Flight item = null;
            item = db.Flights.Find(flightID);

            if (item == null)
            {
                context.ModelState.AddModelError("", String.Format("Item with id {0} was not found", flightID));
                return;
            }
            context.TryUpdateModel(item);
            if (context.ModelState.IsValid)
            {
                db.SaveChanges();
            }
        }

        public void DeleteFlight(int flightID, ModelMethodContext context)
        {
            var item = new Flight { FlightID = flightID };
            db.Entry(item).State = EntityState.Deleted;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                context.ModelState.AddModelError("",
                    String.Format("Item with id {0} no longer exists in the database.", flightID));
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