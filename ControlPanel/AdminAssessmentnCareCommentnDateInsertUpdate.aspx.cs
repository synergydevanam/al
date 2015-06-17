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

public partial class AdminAssessmentnCareCommentnDateInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadAssessmentnCareDate();
            loadAssessmentnCareParent();
            if (Request.QueryString["assessmentnCareCommentnDateID"] != null)
            {
                int assessmentnCareCommentnDateID = Int32.Parse(Request.QueryString["assessmentnCareCommentnDateID"]);
                if (assessmentnCareCommentnDateID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showAssessmentnCareCommentnDateData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        AssessmentnCareCommentnDate assessmentnCareCommentnDate = new AssessmentnCareCommentnDate();

        assessmentnCareCommentnDate.AssessmentnCareDateID = Int32.Parse(ddlAssessmentnCareDate.SelectedValue);
        assessmentnCareCommentnDate.AssessmentnCareParentID = Int32.Parse(ddlAssessmentnCareParent.SelectedValue);
        assessmentnCareCommentnDate.Comment = txtComment.Text;
        int resutl = AssessmentnCareCommentnDateManager.InsertAssessmentnCareCommentnDate(assessmentnCareCommentnDate);
        Response.Redirect("AdminAssessmentnCareCommentnDateDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        AssessmentnCareCommentnDate assessmentnCareCommentnDate = new AssessmentnCareCommentnDate();
        assessmentnCareCommentnDate = AssessmentnCareCommentnDateManager.GetAssessmentnCareCommentnDateByID(Int32.Parse(Request.QueryString["assessmentnCareCommentnDateID"]));
        AssessmentnCareCommentnDate tempAssessmentnCareCommentnDate = new AssessmentnCareCommentnDate();
        tempAssessmentnCareCommentnDate.AssessmentnCareCommentnDateID = assessmentnCareCommentnDate.AssessmentnCareCommentnDateID;

        tempAssessmentnCareCommentnDate.AssessmentnCareDateID = Int32.Parse(ddlAssessmentnCareDate.SelectedValue);
        tempAssessmentnCareCommentnDate.AssessmentnCareParentID = Int32.Parse(ddlAssessmentnCareParent.SelectedValue);
        tempAssessmentnCareCommentnDate.Comment = txtComment.Text;
        bool result = AssessmentnCareCommentnDateManager.UpdateAssessmentnCareCommentnDate(tempAssessmentnCareCommentnDate);
        Response.Redirect("AdminAssessmentnCareCommentnDateDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlAssessmentnCareDate.SelectedIndex = 0;
        ddlAssessmentnCareParent.SelectedIndex = 0;
        txtComment.Text = "";
    }
    private void showAssessmentnCareCommentnDateData()
    {
        AssessmentnCareCommentnDate assessmentnCareCommentnDate = new AssessmentnCareCommentnDate();
        assessmentnCareCommentnDate = AssessmentnCareCommentnDateManager.GetAssessmentnCareCommentnDateByID(Int32.Parse(Request.QueryString["assessmentnCareCommentnDateID"]));

        ddlAssessmentnCareDate.SelectedValue = assessmentnCareCommentnDate.AssessmentnCareDateID.ToString();
        ddlAssessmentnCareParent.SelectedValue = assessmentnCareCommentnDate.AssessmentnCareParentID.ToString();
        txtComment.Text = assessmentnCareCommentnDate.Comment;
    }
    private void loadAssessmentnCareDate()
    {
        ListItem li = new ListItem("Select AssessmentnCareDate...", "0");
        ddlAssessmentnCareDate.Items.Add(li);

        List<AssessmentnCareDate> assessmentnCareDates = new List<AssessmentnCareDate>();
        assessmentnCareDates = AssessmentnCareDateManager.GetAllAssessmentnCareDates();
        foreach (AssessmentnCareDate assessmentnCareDate in assessmentnCareDates)
        {
            ListItem item = new ListItem(assessmentnCareDate.AssessmentnCareDateName.ToString(), assessmentnCareDate.AssessmentnCareDateID.ToString());
            ddlAssessmentnCareDate.Items.Add(item);
        }
    }
    private void loadAssessmentnCareParent()
    {
        ListItem li = new ListItem("Select AssessmentnCareParent...", "0");
        ddlAssessmentnCareParent.Items.Add(li);

        List<AssessmentnCareParent> assessmentnCareParents = new List<AssessmentnCareParent>();
        assessmentnCareParents = AssessmentnCareParentManager.GetAllAssessmentnCareParents();
        foreach (AssessmentnCareParent assessmentnCareParent in assessmentnCareParents)
        {
            ListItem item = new ListItem(assessmentnCareParent.AssessmentnCareParentName.ToString(), assessmentnCareParent.AssessmentnCareParentID.ToString());
            ddlAssessmentnCareParent.Items.Add(item);
        }
    }
}
