using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using SkyAirline.Models;

namespace SkyAirline.Views.Passenger
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (ModelState.IsValid)
            {
                if (Email.Text == "admin@skyairline.in" && Password.Text == "SkyAirline")
                {
                    Session["UserName"] = Email.Text;
                    Session["Admin"] = "true";
                    Response.Redirect("~/Views/Home/Home");
                }
                else
                {
                    using (SkyAirlineContext db = new SkyAirlineContext())
                    {
                        var passengerByEmail = db.Passengers.Where(p => p.PassengerEmail == Email.Text).SingleOrDefault();
                        if (passengerByEmail == null)
                        {
                            ErrorMessage.Visible = true;
                            FailureText.Text = "Invalid login attempt!!";
                        }
                        else
                        {
                            Session["UserName"] = Email.Text;
                            Response.Redirect("~/Views/Home/Home");
                        }
                    }
                }
                
            }
        }
    }
}