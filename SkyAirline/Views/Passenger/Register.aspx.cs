using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SkyAirline.Models;
using System.Data.Entity.Validation;

namespace SkyAirline.Views.Passanger
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
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
            }

        }

        protected void registerPassengerForm_Click(object sender, EventArgs e)
        {
            var passenger = new SkyAirline.Models.Passenger() {
                PassengerName = PassengerName.Text,
                PassengerEmail = PassengerEmail.Text,
                PassengerMobileNo = PassengerMobileNo.Text,
                PassengerAddress = PassengerAddress.Text,
                PassengerGender = (Gender)Enum.Parse(typeof(Gender), PassengerGender.SelectedItem.Value),                
                PassengerIdentityType = (Identity) Enum.Parse(typeof(Identity), PassengerIdentityType.SelectedItem.Value),
                PassengerIdentity = PassengerIdentity.Text,
                PassengerPassword = PassengerPassword.Text,
                PassengerDateOfBirth = DateTime.Parse(PassengerDateOfBirth.Text)
            };

            if (ModelState.IsValid)
            {
                using (SkyAirlineContext db = new SkyAirlineContext())
                {
                    //var passengerByEmail = db.PassengersFirstOrDefault().Where(p => p.PassengerEmail == PassengerEmail.Text);

                    var passengerByEmail =  db.Passengers.Where(p => p.PassengerEmail == PassengerEmail.Text).SingleOrDefault();
                    if (passengerByEmail == null)
                    {
                        db.Passengers.Add(passenger);
                        db.SaveChanges();                       
                        Response.Redirect("~/Views/Home/Home");
                    }
                    else
                    {
                        ErrorMessage.Text = "Passenger with same email address already exists!!";
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

        protected void addPassengerForm_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            Response.Redirect("~/Views/Home/Home");
        }
    }
}