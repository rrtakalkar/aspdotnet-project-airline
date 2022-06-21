using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SkyAirline.Models;

namespace SkyAirline.Views.Schedule
{
    public partial class SearchFlights : System.Web.UI.Page
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

        protected void searchForm_Click(object sender, EventArgs e)
        {

            var DateOfDeparture = DateTime.Parse(DepartureDate.Text);
            var DateOfArrival = DateTime.Parse(ArrivalDate.Text);
            var DepartureID = int.Parse(Departure.SelectedItem.Value);
            var ArrivalID = int.Parse(Arrival.SelectedItem.Value);

            using (SkyAirlineContext db = new SkyAirlineContext())
            {
                var flightsBySearchForm = db.Flights.Where(f => f.DepartureID == DepartureID)
                        .Where(f => f.ArrivalID == ArrivalID)
                        .Distinct()
                        .ToList();

                var scheduleBySearchForm = db.Schedules.Where(s => s.Flight.DepartureID == DepartureID)
                    .Where(s => s.Flight.ArrivalID == ArrivalID)
                    .Where(s => DbFunctions.TruncateTime(s.DepartureDate) == DateOfDeparture.Date)
                    .Where(s => DbFunctions.TruncateTime(s.ArrivalDate) == DateOfArrival.Date)
                    .Distinct()
                    .ToList();

                SearchResultsPanel.Visible = scheduleBySearchForm != null;

                IList<SearchFlightResults> searchFlightResults = new List<SearchFlightResults>();

                foreach (var schedule in scheduleBySearchForm)
                {
                    var searchFlightResult = new SearchFlightResults()
                    {
                        ScheduleID = schedule.ScheduleID,
                        FlightNumber = schedule.Flight.FlightNumber,
                        DepartureLocation = schedule.Flight.Departure.Location(),
                        ArrivalLocation = schedule.Flight.Arrival.Location(),
                        DepartureDate = schedule.DepartureDate,
                        ArrivalDate = schedule.ArrivalDate,
                        AvailableEconomySeats = schedule.AvailableEconomyClassSeats,
                        AvailableBusinessSeats = schedule.AvailableBusinessClassSeats
                    };

                    searchFlightResults.Add(searchFlightResult);
                }

                SearchResultGridView.DataSource = searchFlightResults;
                SearchResultGridView.DataBind();
            }
            
            // Response.Redirect("~/Views/Home/Home");
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Home/Home");
        }
    }

    public class SearchFlightResults
    {
        public int ScheduleID { get; set; }

        public string FlightNumber { get; set; }

        public string DepartureLocation { get; set; }

        public string ArrivalLocation { get; set; }

        public DateTime DepartureDate { get; set; }

        public DateTime ArrivalDate { get; set; }

        public int AvailableEconomySeats { get; set; }

        public int AvailableBusinessSeats { get; set; }
    }
}