using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class control_PrintingControlResidentInfo : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            laodResitentInfo();
        }
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
    private void laodResitentInfo()
    {
    try
    {
        Resident resident = ResidentManager.GetResidentByID(int.Parse(Request.QueryString["ResidentID"]));
        lblAdmittedFrom.Text = resident.AdmissionFrom;
        lblPharmacyPreference.Text = resident.PharmacyPreference + (resident.PharmacyPreferenceTelephone!=""? (", "+resident.PharmacyPreferenceTelephone):"");
        lblPhysicianName.Text = resident.AttendingPhysician;
        lblResidentName.Text = resident.Name;
        lblProperty.Text = resident.ExtraField7;
        lblCompnayName.Text = resident.ExtraField9;
        lblAllergy.Text = resident.ExtraField11;
        }
        catch(Exception ex)
        {}
    }
}