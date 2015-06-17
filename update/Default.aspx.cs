using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class update_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Redirect("https://docs.google.com/spreadsheets/d/1H8uDKq1AjlA1xBDM6GyEl34w56zb0Qq8D9IED7aVYew/edit?usp=sharing");
    }
}