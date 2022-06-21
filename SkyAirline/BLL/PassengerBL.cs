using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SkyAirline.Models;

namespace SkyAirline.BLL
{
    public class PassengerBL : IDisposable
    {
        SkyAirlineContext db = new SkyAirlineContext();

        public IQueryable<Passenger> GetPassengers()
        {
            var query = db.Passengers.Distinct();
            return query;
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