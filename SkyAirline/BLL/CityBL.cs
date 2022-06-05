using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using SkyAirline.Models;

namespace SkyAirline.BLL
{
    public class CityBL : IDisposable
    {
        SkyAirlineContext db = new SkyAirlineContext();

        public IQueryable<City> GetCities()
        {
            var query = db.Cities.Distinct();
            return query;
        }

        public City GetCityByName(string cityName)
        {
            var cityByName = db.Cities.Include(cityName);
            cityByName.Where(x => x.CityName == cityName).ToList();
                
            //Find(db.Cities.Where(c => c.CityName == cityName));
            return null;
        }

        public void InsertCity(ModelMethodContext context)
        {
            var item = new City();

            context.TryUpdateModel(item);
            if (context.ModelState.IsValid)
            {
                db.Cities.Add(item);
                db.SaveChanges();
            }
        }

        public void UpdateCity(int cityID, ModelMethodContext context)
        {
            City item = null;
                item = db.Cities.Find(cityID);
            var cityBYName = db.Cities.FirstOrDefault(c => c.CityName == item.CityName && c.CityID != item.CityID);
           
        
             if (item == null)
            {
                context.ModelState.AddModelError("", String.Format("Item with id {0} was not found", cityID));
                return;
            }
           

            context.TryUpdateModel(item);
            if (cityBYName == null)
            {
                context.ModelState.AddModelError("", String.Format("City with name {0} alredy exits", item.CityName));
                return;
            }
            if (context.ModelState.IsValid)
            {
                db.SaveChanges();
            }
        }

        public void DeleteCity(int cityID, ModelMethodContext context)
        {
            var item = new City { CityID = cityID };
            db.Entry(item).State = EntityState.Deleted;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                context.ModelState.AddModelError("",
                    String.Format("Item with id {0} no longer exists in the database.", cityID));
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