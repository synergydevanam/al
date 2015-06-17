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

public partial class AdminAssessmentnCareParentInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["assessmentnCareParentID"] != null)
            {
                int assessmentnCareParentID = Int32.Parse(Request.QueryString["assessmentnCareParentID"]);
                if (assessmentnCareParentID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showAssessmentnCareParentData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        AssessmentnCareParent assessmentnCareParent = new AssessmentnCareParent();

        assessmentnCareParent.AssessmentnCareParentName = txtAssessmentnCareParentName.Text;
        int resutl = AssessmentnCareParentManager.InsertAssessmentnCareParent(assessmentnCareParent);
        Response.Redirect("AssessmentnCare.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        AssessmentnCareParent assessmentnCareParent = new AssessmentnCareParent();
        assessmentnCareParent = AssessmentnCareParentManager.GetAssessmentnCareParentByID(Int32.Parse(Request.QueryString["assessmentnCareParentID"]));
        AssessmentnCareParent tempAssessmentnCareParent = new AssessmentnCareParent();
        tempAssessmentnCareParent.AssessmentnCareParentID = assessmentnCareParent.AssessmentnCareParentID;

        tempAssessmentnCareParent.AssessmentnCareParentName = txtAssessmentnCareParentName.Text;
        bool result = AssessmentnCareParentManager.UpdateAssessmentnCareParent(tempAssessmentnCareParent);
        Response.Redirect("AssessmentnCare.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtAssessmentnCareParentName.Text = "";
    }
    private void showAssessmentnCareParentData()
    {
        AssessmentnCareParent assessmentnCareParent = new AssessmentnCareParent();
        assessmentnCareParent = AssessmentnCareParentManager.GetAssessmentnCareParentByID(Int32.Parse(Request.QueryString["assessmentnCareParentID"]));

        txtAssessmentnCareParentName.Text = assessmentnCareParent.AssessmentnCareParentName;
    }
}
