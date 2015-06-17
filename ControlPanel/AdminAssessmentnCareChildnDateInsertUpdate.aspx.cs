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

public partial class AdminAssessmentnCareChildnDateInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadAssessmentnCareChild();
            loadAssessmentnCareDate();
            if (Request.QueryString["assessmentnCareChildnDateID"] != null)
            {
                int assessmentnCareChildnDateID = Int32.Parse(Request.QueryString["assessmentnCareChildnDateID"]);
                if (assessmentnCareChildnDateID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showAssessmentnCareChildnDateData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        AssessmentnCareChildnDate assessmentnCareChildnDate = new AssessmentnCareChildnDate();

        assessmentnCareChildnDate.AssessmentnCareChildID = Int32.Parse(ddlAssessmentnCareChild.SelectedValue);
        assessmentnCareChildnDate.AssessmentnCareDateID = Int32.Parse(ddlAssessmentnCareDate.SelectedValue);
        int resutl = AssessmentnCareChildnDateManager.InsertAssessmentnCareChildnDate(assessmentnCareChildnDate);
        Response.Redirect("AdminAssessmentnCareChildnDateDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        AssessmentnCareChildnDate assessmentnCareChildnDate = new AssessmentnCareChildnDate();
        assessmentnCareChildnDate = AssessmentnCareChildnDateManager.GetAssessmentnCareChildnDateByID(Int32.Parse(Request.QueryString["assessmentnCareChildnDateID"]));
        AssessmentnCareChildnDate tempAssessmentnCareChildnDate = new AssessmentnCareChildnDate();
        tempAssessmentnCareChildnDate.AssessmentnCareChildnDateID = assessmentnCareChildnDate.AssessmentnCareChildnDateID;

        tempAssessmentnCareChildnDate.AssessmentnCareChildID = Int32.Parse(ddlAssessmentnCareChild.SelectedValue);
        tempAssessmentnCareChildnDate.AssessmentnCareDateID = Int32.Parse(ddlAssessmentnCareDate.SelectedValue);
        bool result = AssessmentnCareChildnDateManager.UpdateAssessmentnCareChildnDate(tempAssessmentnCareChildnDate);
        Response.Redirect("AdminAssessmentnCareChildnDateDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlAssessmentnCareChild.SelectedIndex = 0;
        ddlAssessmentnCareDate.SelectedIndex = 0;
    }
    private void showAssessmentnCareChildnDateData()
    {
        AssessmentnCareChildnDate assessmentnCareChildnDate = new AssessmentnCareChildnDate();
        assessmentnCareChildnDate = AssessmentnCareChildnDateManager.GetAssessmentnCareChildnDateByID(Int32.Parse(Request.QueryString["assessmentnCareChildnDateID"]));

        ddlAssessmentnCareChild.SelectedValue = assessmentnCareChildnDate.AssessmentnCareChildID.ToString();
        ddlAssessmentnCareDate.SelectedValue = assessmentnCareChildnDate.AssessmentnCareDateID.ToString();
    }
    private void loadAssessmentnCareChild()
    {
        ListItem li = new ListItem("Select AssessmentnCareChild...", "0");
        ddlAssessmentnCareChild.Items.Add(li);

        List<AssessmentnCareChild> assessmentnCareChilds = new List<AssessmentnCareChild>();
        assessmentnCareChilds = AssessmentnCareChildManager.GetAllAssessmentnCareChilds();
        foreach (AssessmentnCareChild assessmentnCareChild in assessmentnCareChilds)
        {
            ListItem item = new ListItem(assessmentnCareChild.AssessmentnCareChildName.ToString(), assessmentnCareChild.AssessmentnCareChildID.ToString());
            ddlAssessmentnCareChild.Items.Add(item);
        }
    }
    private void loadAssessmentnCareDate()
    {
        ListItem li = new ListItem("Select AssessmentnCareDate...", "0");
        ddlAssessmentnCareDate.Items.Add(li);

        List<AssessmentnCareDate> assessmentnCareDates = new List<AssessmentnCareDate>();
        assessmentnCareDates = AssessmentnCareDateIDManager.GetAllAssessmentnCareDates();
        foreach (AssessmentnCareDate assessmentnCareDate in assessmentnCareDates)
        {
            ListItem item = new ListItem(assessmentnCareDate.AssessmentnCareDateName.ToString("yyyy-MM-dd hh:mm tt"), assessmentnCareDate.AssessmentnCareDateIDID.ToString());
            ddlAssessmentnCareDate.Items.Add(item);
        }
    }
}
