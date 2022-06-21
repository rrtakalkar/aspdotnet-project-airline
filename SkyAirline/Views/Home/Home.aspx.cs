using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SkyAirline
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserMessagePanel.Visible = Session["UserName"] != null && Session["Admin"] == null;
            AdminMessagePanel.Visible = Session["Admin"] != null;
        }
    }
}