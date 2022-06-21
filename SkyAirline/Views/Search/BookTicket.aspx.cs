using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SkyAirline.Models;

namespace SkyAirline.Views.Search
{
    public partial class BookTicket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                var scheduleID = int.Parse(Request.Params["scheduleid"]);
                var passengerEmail = (string)Session["UserName"];
                using (SkyAirlineContext db = new SkyAirlineContext())
                {
                    var schedule = db.Schedules.Where(s => s.ScheduleID == scheduleID).FirstOrDefault();
                    var passenger = db.Passengers.Where(p => p.PassengerEmail == passengerEmail).FirstOrDefault();

                    ScheduleID.Text = schedule.ScheduleID.ToString();
                    PassengerID.Text = passenger.PassengerID.ToString();
                    PassengerName.Text = passenger.PassengerName;
                    FlightNumber.Text = schedule.Flight.FlightNumber;
                    DepartureLocation.Text = schedule.Flight.Departure.Location();
                    ArrivalLocation.Text = schedule.Flight.Arrival.Location();
                    DepartureDate.Text = schedule.DepartureDate.ToString();
                    ArrivalDate.Text = schedule.ArrivalDate.ToString();
                    PaymentAmount.Text = schedule.EconomyClassFare.ToString();
                }


                Array ddlPaymentModes = Enum.GetValues(typeof(SkyAirline.Models.PaymentMode));
                foreach (SkyAirline.Models.PaymentMode paymentMode in ddlPaymentModes)
                {
                    PaymentMode.Items.Add(new ListItem(paymentMode.ToString(), ((int)paymentMode).ToString()));
                }

                Array ddlSeatClass = Enum.GetValues(typeof(SkyAirline.Models.SeatClass));
                foreach (SkyAirline.Models.SeatClass seatClass in ddlSeatClass)
                {
                    SeatClass.Items.Add(new ListItem(seatClass.ToString(), ((int)seatClass).ToString()));
                }
            }
        }

        protected void seatClass_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            SeatClass seatClass = (SeatClass)Enum.Parse(typeof(SeatClass), SeatClass.SelectedItem.Value);

            var scheduleID = int.Parse(Request.Params["scheduleid"]);
            using (SkyAirlineContext db = new SkyAirlineContext())
            {
                var schedule = db.Schedules.Where(s => s.ScheduleID == scheduleID).FirstOrDefault();
                if (seatClass == Models.SeatClass.Economy)
                {
                    PaymentAmount.Text = schedule.EconomyClassFare.ToString();
                }
                else
                {
                    PaymentAmount.Text = schedule.BusinessClassFare.ToString();
                }
            }
        }

        protected void bookTicketForm_Click(object sender, EventArgs e)
        {
            var booking = new SkyAirline.Models.Booking()
            {
                BookingDate = DateTime.Now,
                BookingStatus = BookingStatus.Confirm,
                PassengerID = int.Parse(PassengerID.Text),
                ScheduleID = int.Parse(ScheduleID.Text),
            };

            var payment = new SkyAirline.Models.Payment()
            {
                PaymentDate = DateTime.Now,
                PaymentAmount = int.Parse(PaymentAmount.Text),
                PaymentMode = (PaymentMode)Enum.Parse(typeof(PaymentMode), PaymentMode.SelectedItem.Value)
            };

            if (ModelState.IsValid)
            {
                using (SkyAirlineContext db = new SkyAirlineContext())
                {
                    Booking bking = db.Bookings.Add(booking);
                    db.SaveChanges();

                    payment.BookingID = bking.BookingID;
                    db.Payment.Add(payment);
                    db.SaveChanges();

                    var schedule = db.Schedules.Where(s => s.ScheduleID == booking.ScheduleID).FirstOrDefault();
                    SeatClass seatClass = (SeatClass)Enum.Parse(typeof(SeatClass), SeatClass.SelectedItem.Value);

                    if (seatClass == Models.SeatClass.Economy)
                    {
                        schedule.AvailableEconomyClassSeats -= 1;
                    }
                    else
                    {
                        schedule.AvailableBusinessClassSeats -= 1;
                    }
                    db.SaveChanges();
                }
            }
            
            Response.Redirect("~/Views/Home/Home");
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Home/Home");
        }

    }

}