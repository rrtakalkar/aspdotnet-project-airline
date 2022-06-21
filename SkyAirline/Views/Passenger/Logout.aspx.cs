using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SkyAirline.Views.Passenger
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UserName"] = null;
            Session.RemoveAll();
            Response.Redirect("~/Views/Home/Home");
        }
    }
}