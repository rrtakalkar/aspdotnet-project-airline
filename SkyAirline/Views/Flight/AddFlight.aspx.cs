using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SkyAirline.Models;

namespace SkyAirline.Views.Flight
{
    public partial class AddFlight : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                using (SkyAirlineContext db = new SkyAirlineContext())
                {
                    var ddlAirports = db.Airports.Distinct();

                    foreach (SkyAirline.Models.Airport airport in ddlAirports)
                    {
                        Departure.Items.Add(new ListItem(airport.Location(), ((int)airport.AirportID).ToString()));
                        Arrival.Items.Add(new ListItem(airport.Location(), ((int)airport.AirportID).ToString()));
                    }
                }
            }
        }

        protected void addFlightForm_Click(object sender, EventArgs e)
        {
            var flight = new SkyAirline.Models.Flight() 
            {
                FlightNumber = FlightNumber.Text,
                DepartureID = int.Parse(Departure.SelectedItem.Value),
                ArrivalID = int.Parse(Arrival.SelectedItem.Value),
                EconomyClassSeats = int.Parse(EconomyClassSeats.Text),
                BusinessClassSeats = int.Parse(BusinessClassSeats.Text)
            };

            if (ModelState.IsValid)
            {
                using (SkyAirlineContext db = new SkyAirlineContext())
                {
                    var flightByNumber = db.Flights.FirstOrDefault(f => f.FlightNumber == FlightNumber.Text);
                    if (flightByNumber == null)
                    {
                        db.Flights.Add(flight);
                        db.SaveChanges();
                        Response.Redirect("~/Views/Flight/Flights");
                    }
                    else
                    {
                        ErrorMessage.Text = "Flight with number already Exists.";
                    }
                }

            }
            else
            {
                ErrorMessage.Text = "Failed to insert new flight";
            }

        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Flight/Flights");
        }
        
    }
}