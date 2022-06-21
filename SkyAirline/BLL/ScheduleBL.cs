using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using SkyAirline.Models;

namespace SkyAirline.BLL
{
    public class ScheduleBL : IDisposable
    {
        SkyAirlineContext db = new SkyAirlineContext();

        public IQueryable<Schedule> GetSchedules()
        {
            var query = db.Schedules.Distinct();
            return query;
        }

        public void UpdateSchedule(int scheduleID, ModelMethodContext context)
        {
            Schedule item = db.Schedules.Find(scheduleID);

            if (item == null)
            {
                context.ModelState.AddModelError("", String.Format("Item with id {0} was not found", scheduleID));
                return;
            }
            context.TryUpdateModel(item);
            if (context.ModelState.IsValid)
            {
                db.SaveChanges();
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