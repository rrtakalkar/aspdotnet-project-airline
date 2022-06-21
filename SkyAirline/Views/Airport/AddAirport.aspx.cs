using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SkyAirline.Models;

namespace SkyAirline.Views.Airport
{
    public partial class AddAirport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                using (SkyAirlineContext db = new SkyAirlineContext())
                {
                    var ddlCities = db.Cities.Distinct();

                    foreach (SkyAirline.Models.City city in ddlCities)
                    {
                        City.Items.Add(new ListItem(city.CityName, ((int)city.CityID).ToString()));
                    }
                }
            }
        }

        protected void addAirportForm_Click(object sender, EventArgs e)
        {
            var airport = new SkyAirline.Models.Airport()
            {
                AirportCode = AirportCode.Text,
                CityID = int.Parse(City.SelectedItem.Value),
            };

            if (ModelState.IsValid)
            {
                using (SkyAirlineContext db = new SkyAirlineContext())
                {
                    var airportByCode = db.Airports.FirstOrDefault(a => a.AirportCode == AirportCode.Text);
                    if (airportByCode == null)
                    {
                        db.Airports.Add(airport);
                        db.SaveChanges();
                        Response.Redirect("~/Views/Airport/Airports");
                    }
                    else
                    {
                        ErrorMessage.Text = "Airport code already Exists.";
                    }
                }

            }
            else
            {
                ErrorMessage.Text = "Failed to insert new airport";
            }

        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Airport/Airports");
        }

        protected void addAirportForm_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            Response.Redirect("~/Views/Airport/Airports");
        }

    }
}