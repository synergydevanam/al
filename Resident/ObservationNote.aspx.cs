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
            loadObservationType();
            if (Request.QueryString["ResidentID"] != null)
            {
                laodResitentInfo();
                loadGrid();
            }
            txtMadeBy.Text = getLogin().FirstName;

        }
    }

    private void loadObservationType()
    {
        ListItem li = new ListItem("Select >>", "0");
        ListItem liView = new ListItem("-- All --", "0");
        ddlObservationType.Items.Add(li);
        ddlObservationTypeForView.Items.Add(liView);

        List<ObservationType> observationTypes = new List<ObservationType>();
        observationTypes = ObservationTypeManager.GetAllObservationTypes();
        foreach (ObservationType observationType in observationTypes)
        {
            ListItem item = new ListItem(observationType.ObservationTypeName.ToString(), observationType.ObservationTypeID.ToString());
            ddlObservationType.Items.Add(item);
            ddlObservationTypeForView.Items.Add(item);
        }
    }

    private void laodResitentInfo()
    {
        
    }


    private void loadGrid()
    {
        if (ddlObservationTypeForView.SelectedValue == "0")
        {
            gvObservationNote.DataSource = ObservationNoteManager.GetAllObservationNotesByResidentID(int.Parse(Request.QueryString["ResidentID"]));
            gvObservationNote.DataBind();
        }
        else
        {
            gvObservationNote.DataSource = ObservationNoteManager.GetAllObservationNotesByResidentIDWithType(int.Parse(Request.QueryString["ResidentID"]),int.Parse(ddlObservationTypeForView.SelectedValue));
            gvObservationNote.DataBind();
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

    
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ObservationNote observationNote = new ObservationNote();

        observationNote.Note = txtObservationOrComment.Text;
        observationNote.ResidentID = Int32.Parse(Request.QueryString["ResidentID"]);
        observationNote.AddeBy =getLogin().LoginID;
        observationNote.AddedDate = DateTime.Parse(DateTime.Parse(txtDate.Text).ToString("yyyy-MM-dd") + " " + txtTakingTime.Text);
        observationNote.ExtraField1 = txtMadeBy.Text;
        observationNote.ExtraField2 = ddlObservationType.SelectedValue;
        observationNote.ExtraField3 = "";
        observationNote.ExtraField4 = "";
        observationNote.ExtraField5 = "";
        int resutl = ObservationNoteManager.InsertObservationNote(observationNote);
        
        loadGrid();
    }

    protected void ddlObservationTypeForView_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadGrid();
    }
}