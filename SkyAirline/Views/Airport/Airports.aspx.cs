using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SkyAirline.Models;

namespace SkyAirline.Views.Airport
{
    public partial class Airports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*using (SkyAirlineContext db = new SkyAirlineContext())
            {
                var ddlCities = db.Cities.Distinct();

                foreach (SkyAirline.Models.City city in ddlCities)
                {
                    City.Items.Add(new ListItem(city.CityName, ((int)city.CityID).ToString()));
                }
            }*/

        }
        protected void airportsGrid_CallingDataMethods(object sender, CallingDataMethodsEventArgs e)
        {
            e.DataMethodsObject = new SkyAirline.BLL.AirportBL();
        }

        protected void RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && citiesGrid.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddlCities = (DropDownList)e.Row.FindControl("ddlCities");

                using (SkyAirlineContext db = new SkyAirlineContext())
                {
                    var cities = db.Cities.Distinct();
                    foreach (SkyAirline.Models.City city in cities)
                    {
                        ddlCities.Items.Add(new ListItem(city.CityName, ((int)city.CityID).ToString()));  
                    }
                    string selectedCity = DataBinder.Eval(e.Row.DataItem, "CityID").ToString();
                    ddlCities.Items.FindByValue(selectedCity).Selected = true;
                }
            }
        }
    }
}