using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SkyAirline.Models;

namespace SkyAirline.Views.Schedule
{
    public partial class AddSchedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                using (SkyAirlineContext db = new SkyAirlineContext())
                {
                    var ddlFlights = db.Flights.Distinct();

                    foreach (SkyAirline.Models.Flight flight in ddlFlights)
                    {
                        Flight.Items.Add(new ListItem(flight.FlightNumber, ((int)flight.FlightID).ToString()));
                    }
                }
            }
        }

        protected void addScheduleForm_Click(object sender, EventArgs e)
        {
            var schedule = new SkyAirline.Models.Schedule()
            {
                FlightID = int.Parse(Flight.SelectedItem.Value),
                DepartureDate = DateTime.Parse(DepartureDate.Text),
                ArrivalDate = DateTime.Parse(ArrivalDate.Text),
                EconomyClassFare = int.Parse(EconomyClassFare.Text),
                BusinessClassFare = int.Parse(BusinessClassFare.Text)
            };

            if (ModelState.IsValid)
            {
                using (SkyAirlineContext db = new SkyAirlineContext())
                {
                   var flight = db.Flights.Where(f => f.FlightID == schedule.FlightID).FirstOrDefault();
                    schedule.AvailableEconomyClassSeats = flight.EconomyClassSeats;
                    schedule.AvailableBusinessClassSeats = flight.BusinessClassSeats;

                    db.Schedules.Add(schedule);
                    db.SaveChanges();
                    Response.Redirect("~/Views/Schedule/Schedules");                   
                }

            }
            else
            {
                ErrorMessage.Text = "Failed to insert new flight schedule";
            }

        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Schedule/Schedules");
        }

    }
}