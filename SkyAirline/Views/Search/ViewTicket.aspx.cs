using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SkyAirline.Models;

namespace SkyAirline.Views.Search
{
    public partial class ViewTicket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                var bookingID = int.Parse(Request.Params["bookingid"]);
                //var passengerEmail = (string)Session["UserName"];
                using (SkyAirlineContext db = new SkyAirlineContext())
                {
                    var booking = db.Bookings.Where(b => b.BookingID == bookingID).FirstOrDefault();
                    //var passenger = db.Passengers.Where(p => p.PassengerEmail == passengerEmail).FirstOrDefault();
                    if (booking != null)
                    {
                        PassengerName.Text = booking.Passenger.PassengerName;
                        FlightNumber.Text = booking.Schedule.Flight.FlightNumber;
                        DepartureLocation.Text = booking.Schedule.Flight.Departure.Location();
                        ArrivalLocation.Text = booking.Schedule.Flight.Arrival.Location();
                        DepartureDate.Text = booking.Schedule.DepartureDate.ToString();
                        ArrivalDate.Text = booking.Schedule.ArrivalDate.ToString();
                    }
                    else
                    {
                        ErrorMessage.Text = "Invalid Booking ID, Please contact Administrator";
                    }

                }                
            }
        }
    }
}