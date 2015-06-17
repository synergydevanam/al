using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
 

public partial class Admin_AppointmentLookUp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["mID"] != null)
            {
                var metroID = int.Parse(Request.QueryString["mID"].ToString());

              //  lblMetro.Text = MetroLocationManager.GetMetroLocationByMetroLocationID(metroID).MetroLocationName;

                gvAppointmnet.DataSource = AppointmnetManager.GetAllAppointmnetByMetroLocationID(metroID);
                gvAppointmnet.DataBind();


            }
          //  MetroLocationIDLoad();
        }
    }
  
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        

        var dateFrom = txtDateFrom.Text;
        var dateTo = txtDateTo.Text;

        gvAppointmnet.DataSource = AppointmnetManager.SearchAppointMent("0", dateFrom, dateTo);
        gvAppointmnet.DataBind();

    }
}