using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SkyAirline.Models;

namespace SkyAirline.Views.Search
{
    public partial class MyBookings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var passengerEmail = (string)Session["UserName"];
                using (SkyAirlineContext db = new SkyAirlineContext())
                {              
                    var bookings = db.Bookings.Where(b => b.Passenger.PassengerEmail == passengerEmail).Distinct().ToList();
                    MyBookingsGridView.DataSource = bookings;
                    MyBookingsGridView.DataBind();
                }
            }
         
        }
    }
}