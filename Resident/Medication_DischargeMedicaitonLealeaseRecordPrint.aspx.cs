using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Resident_ADLRecord : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadGrid();
        }
    }

    
    private void loadGrid()
    {
        DataSet ds = MedicationTimeManager.GetAllMedicationTimesByResidentForPrint(int.Parse(Request.QueryString["ResidentID"]), int.Parse(Request.QueryString["PrintOption"]));
        gvMedicaiton.DataSource = ds.Tables[0];
        gvMedicaiton.DataBind();
    }

    private Login getLogin()
    {
        Login login = new Login();
        try
        {
            if (Session["Login"] == null) { Session["PreviousPage"] = HttpContext.Current.Request.Url.AbsoluteUri; Response.Redirect("../LoginPage.aspx"); }

            login = (Login)Session["Login"];
        }
        catch (Exception ex)
        { }

        return login;
    }

   

   
}