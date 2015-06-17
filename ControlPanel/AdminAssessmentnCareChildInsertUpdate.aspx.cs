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

public partial class AdminAssessmentnCareChildInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadAssessmentnCareParent();
            if (Request.QueryString["AssessmentnCareParentID"] != null)
            {
                ddlAssessmentnCareParent.SelectedValue = Request.QueryString["AssessmentnCareParentID"];
            }
            if (Request.QueryString["assessmentnCareChildID"] != null)
            {
                int assessmentnCareChildID = Int32.Parse(Request.QueryString["assessmentnCareChildID"]);
                if (assessmentnCareChildID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showAssessmentnCareChildData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        AssessmentnCareChild assessmentnCareChild = new AssessmentnCareChild();

        assessmentnCareChild.AssessmentnCareParentID = Int32.Parse(ddlAssessmentnCareParent.SelectedValue);
        assessmentnCareChild.AssessmentnCareChildName = txtAssessmentnCareChildName.Text;
        int resutl = AssessmentnCareChildManager.InsertAssessmentnCareChild(assessmentnCareChild);
        txtAssessmentnCareChildName.Text = "";
        //Response.Redirect("AdminAssessmentnCareChildDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        AssessmentnCareChild assessmentnCareChild = new AssessmentnCareChild();
        assessmentnCareChild = AssessmentnCareChildManager.GetAssessmentnCareChildByID(Int32.Parse(Request.QueryString["assessmentnCareChildID"]));
        AssessmentnCareChild tempAssessmentnCareChild = new AssessmentnCareChild();
        tempAssessmentnCareChild.AssessmentnCareChildID = assessmentnCareChild.AssessmentnCareChildID;

        tempAssessmentnCareChild.AssessmentnCareParentID = Int32.Parse(ddlAssessmentnCareParent.SelectedValue);
        tempAssessmentnCareChild.AssessmentnCareChildName = txtAssessmentnCareChildName.Text;
        bool result = AssessmentnCareChildManager.UpdateAssessmentnCareChild(tempAssessmentnCareChild);
        Response.Redirect("AssessmentnCare.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlAssessmentnCareParent.SelectedIndex = 0;
        txtAssessmentnCareChildName.Text = "";
    }
    private void showAssessmentnCareChildData()
    {
        AssessmentnCareChild assessmentnCareChild = new AssessmentnCareChild();
        assessmentnCareChild = AssessmentnCareChildManager.GetAssessmentnCareChildByID(Int32.Parse(Request.QueryString["assessmentnCareChildID"]));

        ddlAssessmentnCareParent.SelectedValue = assessmentnCareChild.AssessmentnCareParentID.ToString();
        txtAssessmentnCareChildName.Text = assessmentnCareChild.AssessmentnCareChildName;
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
