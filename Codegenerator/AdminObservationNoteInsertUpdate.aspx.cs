using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class AdminObservationNoteInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadResident();
            if (Request.QueryString["observationNoteID"] != null)
            {
                int observationNoteID = Int32.Parse(Request.QueryString["observationNoteID"]);
                if (observationNoteID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showObservationNoteData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ObservationNote observationNote = new ObservationNote();

        observationNote.Note = txtNote.Text;
        observationNote.ResidentID = Int32.Parse(ddlResident.SelectedValue);
        observationNote.AddeBy = Int32.Parse(txtAddeBy.Text);
        observationNote.AddedDate = DateTime.Now;
        observationNote.ExtraField1 = txtExtraField1.Text;
        observationNote.ExtraField2 = txtExtraField2.Text;
        observationNote.ExtraField3 = txtExtraField3.Text;
        observationNote.ExtraField4 = txtExtraField4.Text;
        observationNote.ExtraField5 = txtExtraField5.Text;
        int resutl = ObservationNoteManager.InsertObservationNote(observationNote);
        Response.Redirect("AdminObservationNoteDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        ObservationNote observationNote = new ObservationNote();
        observationNote = ObservationNoteManager.GetObservationNoteByID(Int32.Parse(Request.QueryString["observationNoteID"]));
        ObservationNote tempObservationNote = new ObservationNote();
        tempObservationNote.ObservationNoteID = observationNote.ObservationNoteID;

        tempObservationNote.Note = txtNote.Text;
        tempObservationNote.ResidentID = Int32.Parse(ddlResident.SelectedValue);
        tempObservationNote.AddeBy = Int32.Parse(txtAddeBy.Text);
        tempObservationNote.AddedDate = DateTime.Now;
        tempObservationNote.ExtraField1 = txtExtraField1.Text;
        tempObservationNote.ExtraField2 = txtExtraField2.Text;
        tempObservationNote.ExtraField3 = txtExtraField3.Text;
        tempObservationNote.ExtraField4 = txtExtraField4.Text;
        tempObservationNote.ExtraField5 = txtExtraField5.Text;
        bool result = ObservationNoteManager.UpdateObservationNote(tempObservationNote);
        Response.Redirect("AdminObservationNoteDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtNote.Text = "";
        ddlResident.SelectedIndex = 0;
        txtAddeBy.Text = "";
        txtExtraField1.Text = "";
        txtExtraField2.Text = "";
        txtExtraField3.Text = "";
        txtExtraField4.Text = "";
        txtExtraField5.Text = "";
    }
    private void showObservationNoteData()
    {
        ObservationNote observationNote = new ObservationNote();
        observationNote = ObservationNoteManager.GetObservationNoteByID(Int32.Parse(Request.QueryString["observationNoteID"]));

        txtNote.Text = observationNote.Note;
        ddlResident.SelectedValue = observationNote.ResidentID.ToString();
        txtAddeBy.Text = observationNote.AddeBy.ToString();
        txtExtraField1.Text = observationNote.ExtraField1;
        txtExtraField2.Text = observationNote.ExtraField2;
        txtExtraField3.Text = observationNote.ExtraField3;
        txtExtraField4.Text = observationNote.ExtraField4;
        txtExtraField5.Text = observationNote.ExtraField5;
    }
    private void loadResident()
    {
        ListItem li = new ListItem("Select Resident...", "0");
        ddlResident.Items.Add(li);

        List<Resident> residents = new List<Resident>();
        residents = ResidentManager.GetAllResidents();
        foreach (Resident resident in residents)
        {
            ListItem item = new ListItem(resident.ResidentName.ToString(), resident.ResidentID.ToString());
            ddlResident.Items.Add(item);
        }
    }
}
