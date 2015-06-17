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

public partial class AdminAssessmentnCareDateIDInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadResident();
            if (Request.QueryString["assessmentnCareDateIDID"] != null)
            {
                int assessmentnCareDateIDID = Int32.Parse(Request.QueryString["assessmentnCareDateIDID"]);
                if (assessmentnCareDateIDID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showAssessmentnCareDateIDData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        AssessmentnCareDate assessmentnCareDateID = new AssessmentnCareDate();

        assessmentnCareDateID.AssessmentnCareDate = txtAssessmentnCareDate.Text;
        assessmentnCareDateID.ResidentID = Int32.Parse(ddlResident.SelectedValue);
        assessmentnCareDateID.AddedBy = Int32.Parse(txtAddedBy.Text);
        assessmentnCareDateID.AddedDate = DateTime.Now;
        assessmentnCareDateID.UpdatedBy = Int32.Parse(txtUpdatedBy.Text);
        assessmentnCareDateID.UpdatedDate = txtUpdatedDate.Text;
        int resutl = AssessmentnCareDateIDManager.InsertAssessmentnCareDateID(assessmentnCareDateID);
        Response.Redirect("AdminAssessmentnCareDateIDDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        AssessmentnCareDate assessmentnCareDateID = new AssessmentnCareDate();
        assessmentnCareDateID = AssessmentnCareDateIDManager.GetAssessmentnCareDateIDByID(Int32.Parse(Request.QueryString["assessmentnCareDateIDID"]));
        AssessmentnCareDateID tempAssessmentnCareDateID = new AssessmentnCareDateID();
        tempAssessmentnCareDateID.AssessmentnCareDateIDID = assessmentnCareDateID.AssessmentnCareDateIDID;

        tempAssessmentnCareDateID.AssessmentnCareDate = txtAssessmentnCareDate.Text;
        tempAssessmentnCareDateID.ResidentID = Int32.Parse(ddlResident.SelectedValue);
        tempAssessmentnCareDateID.AddedBy = Int32.Parse(txtAddedBy.Text);
        tempAssessmentnCareDateID.AddedDate = DateTime.Now;
        tempAssessmentnCareDateID.UpdatedBy = Int32.Parse(txtUpdatedBy.Text);
        tempAssessmentnCareDateID.UpdatedDate = txtUpdatedDate.Text;
        bool result = AssessmentnCareDateIDManager.UpdateAssessmentnCareDateID(tempAssessmentnCareDateID);
        Response.Redirect("AdminAssessmentnCareDateIDDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtAssessmentnCareDate.Text = "";
        ddlResident.SelectedIndex = 0;
        txtAddedBy.Text = "";
        txtUpdatedBy.Text = "";
        txtUpdatedDate.Text = "";
    }
    private void showAssessmentnCareDateIDData()
    {
        AssessmentnCareDate assessmentnCareDateID = new AssessmentnCareDate();
        assessmentnCareDateID = AssessmentnCareDateIDManager.GetAssessmentnCareDateIDByID(Int32.Parse(Request.QueryString["assessmentnCareDateIDID"]));

        txtAssessmentnCareDate.Text = assessmentnCareDateID.AssessmentnCareDate;
        ddlResident.SelectedValue = assessmentnCareDateID.ResidentID.ToString();
        txtAddedBy.Text = assessmentnCareDateID.AddedBy.ToString();
        txtUpdatedBy.Text = assessmentnCareDateID.UpdatedBy.ToString();
        txtUpdatedDate.Text = assessmentnCareDateID.UpdatedDate;
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
