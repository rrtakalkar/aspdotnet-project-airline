using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SkyAirline.Models;

namespace SkyAirline.Views.City
{
    public partial class AddCity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Array ddlContries = Enum.GetValues(typeof(SkyAirline.Models.Country));
                foreach (SkyAirline.Models.Country country in ddlContries)
                {
                    Country.Items.Add(new ListItem(country.ToString(), ((int)country).ToString()));
                }
            }

        }

        protected void addCityForm_Click(object sender, EventArgs e)
        {
            var city = new SkyAirline.Models.City() { CityName = CityName.Text, Country = SkyAirline.Models.Country.India };

            if (ModelState.IsValid)
            {
                using (SkyAirlineContext db = new SkyAirlineContext())
                {
                    var cityBYName = db.Cities.FirstOrDefault(c => c.CityName == CityName.Text);
                    if (cityBYName == null)
                    {
                        db.Cities.Add(city);
                        db.SaveChanges();
                        Response.Redirect("~/Views/City/Cities");
                    }
                    else
                    {
                        ErrorMessage.Text = "City name already Exists.";
                    }
                }
                
            }
            else
            {
                ErrorMessage.Text = "Failed to insert new city";
            }

        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/City/Cities");
        }

        protected void addCityForm_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            Response.Redirect("~/Views/City/Cities");
        }
    }
}