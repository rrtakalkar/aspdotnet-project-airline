using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SkyAirline.Models;

namespace SkyAirline.Views.Flight
{
    public partial class Flights : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void flightsGrid_CallingDataMethods(object sender, CallingDataMethodsEventArgs e)
        {
            e.DataMethodsObject = new SkyAirline.BLL.FlightBL();
        }

        protected void RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && flightsGrid.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddlDepartureAirports = (DropDownList)e.Row.FindControl("ddlDepartureAirports");
                DropDownList ddlArrivalAirports = (DropDownList)e.Row.FindControl("ddlArrivalAirports");

                using (SkyAirlineContext db = new SkyAirlineContext())
                {
                    var airports = db.Airports.Distinct();
                    foreach (SkyAirline.Models.Airport airport in airports)
                    {
                        ddlDepartureAirports.Items.Add(new ListItem(airport.AirportCode, ((int)airport.AirportID).ToString()));
                        ddlArrivalAirports.Items.Add(new ListItem(airport.AirportCode, ((int)airport.AirportID).ToString()));
                    }
                    //string selectedCity = DataBinder.Eval(e.Row.DataItem, "CityID").ToString();
                    //ddlDepartureAirports.Items.FindByValue(selectedCity).Selected = true;
                }
            }
        }
    }
}