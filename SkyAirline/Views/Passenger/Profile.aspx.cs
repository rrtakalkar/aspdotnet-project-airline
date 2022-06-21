using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SkyAirline.Models;

namespace SkyAirline.Views.Passenger
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string email = (string)Session["UserName"];
                if (email != null && email != "admin@skyairline.in")
                {
                    Array ddlGenders = Enum.GetValues(typeof(SkyAirline.Models.Gender));
                    foreach (SkyAirline.Models.Gender gender in ddlGenders)
                    {
                        PassengerGender.Items.Add(new ListItem(gender.ToString(), ((int)gender).ToString()));
                    }

                    Array ddlIdentities = Enum.GetValues(typeof(SkyAirline.Models.Identity));
                    foreach (SkyAirline.Models.Identity identity in ddlIdentities)
                    {
                        PassengerIdentityType.Items.Add(new ListItem(identity.ToString(), ((int)identity).ToString()));
                    }

                    using (SkyAirlineContext db = new SkyAirlineContext())
                    {
                        var passengerByEmail = db.Passengers.Where(p => p.PassengerEmail == email).SingleOrDefault();
                        PassengerGender.ClearSelection();
                        PassengerIdentityType.ClearSelection();

                        PassengerName.Text = passengerByEmail.PassengerName;
                        PassengerEmail.Text = passengerByEmail.PassengerEmail;
                        PassengerMobileNo.Text = passengerByEmail.PassengerMobileNo;
                        PassengerAddress.Text = passengerByEmail.PassengerAddress;
                        PassengerGender.Text = passengerByEmail.PassengerGender.ToString();
                        PassengerIdentityType.Text = passengerByEmail.PassengerIdentityType.ToString();
                        PassengerIdentity.Text = passengerByEmail.PassengerIdentity;
                        PassengerDateOfBirth.Text = passengerByEmail.PassengerDateOfBirth.ToShortDateString();
                    
                    }

                    
                }
                else
                {
                    Response.Redirect("~/Views/Home/Home");
                }

            }
        }

        protected void updatePassengerForm_Click(object sender, EventArgs e)
        {
            var passenger = new SkyAirline.Models.Passenger()
            {
                PassengerName = PassengerName.Text,
                PassengerEmail = PassengerEmail.Text,
                PassengerMobileNo = PassengerMobileNo.Text,
                PassengerAddress = PassengerAddress.Text,
                PassengerGender = (Gender)Enum.Parse(typeof(Gender), PassengerGender.SelectedValue),
                PassengerIdentityType = (Identity)Enum.Parse(typeof(Identity), PassengerIdentityType.SelectedValue),
                PassengerIdentity = PassengerIdentity.Text,
                PassengerDateOfBirth = DateTime.Parse(PassengerDateOfBirth.Text)
            };

            if (ModelState.IsValid)
            {
                using (SkyAirlineContext db = new SkyAirlineContext())
                {
                    var passengerByEmail = db.Passengers.Where(p => p.PassengerEmail == PassengerEmail.Text).SingleOrDefault();
                    if (passengerByEmail == null)
                    {
                        ErrorMessage.Text = "Passenger record not found!!";
                    }
                    else
                    {
                        passengerByEmail.PassengerName = passenger.PassengerName;
                        db.SaveChanges();
                        Response.Redirect("~/Views/Home/Home");                        
                    }
                }

            }
            else
            {
                ErrorMessage.Text = "Failed to register new passenger";
            }

        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Home/Home");
        }
    }
}