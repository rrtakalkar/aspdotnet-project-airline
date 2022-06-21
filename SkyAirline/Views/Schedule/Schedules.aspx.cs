using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SkyAirline.BLL;
using SkyAirline.Models;

namespace SkyAirline.Views.Schedule
{
    public partial class Schedules : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void schedulesGrid_CallingDataMethods(object sender, CallingDataMethodsEventArgs e)
        {
            e.DataMethodsObject = new SkyAirline.BLL.ScheduleBL();
        }

        protected void RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && schedulesGrid.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddlFlights = (DropDownList)e.Row.FindControl("ddlFlights");

                using (SkyAirlineContext db = new SkyAirlineContext())
                {
                    var flights = db.Flights.Distinct();
                    foreach (SkyAirline.Models.Flight flight in flights)
                    {
                        ddlFlights.Items.Add(new ListItem(flight.FlightNumber, ((int)flight.FlightID).ToString()));                    
                    }
                }
            }
        }

    }
}