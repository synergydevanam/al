using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Resident_ADLRecord : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadGrid();
        }
    }

    protected void lbDelete_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        bool result = AssessmentnCareChildManager.DeleteAssessmentnCareChild(Convert.ToInt32(linkButton.CommandArgument));
        loadGrid();
    }

    protected void lbDeleteParent_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        bool result = AssessmentnCareParentManager.DeleteAssessmentnCareParent(Convert.ToInt32(linkButton.CommandArgument));
        loadGrid();
    }

    
    private void loadGrid()
    {
        gvAssessmentnCareParent.DataSource = AssessmentnCareParentManager.GetAllAssessmentnCareParents();
        gvAssessmentnCareParent.DataBind();

        List<AssessmentnCareChild> assessmentCareChilds = new List<AssessmentnCareChild>();
        assessmentCareChilds = AssessmentnCareChildManager.GetAllAssessmentnCareChilds();

        foreach (GridViewRow gvr in gvAssessmentnCareParent.Rows)
        {
            HiddenField hfAssessmentnCareParentID = (HiddenField)gvr.FindControl("hfAssessmentnCareParentID");
            DataList dlAssessmentnCareChild = (DataList)gvr.FindControl("dlAssessmentnCareChild");

            List<AssessmentnCareChild> assessmentCareChildByParentID = new List<AssessmentnCareChild>();
            foreach (AssessmentnCareChild item in assessmentCareChilds)
            {
                if (item.AssessmentnCareParentID.ToString() == hfAssessmentnCareParentID.Value)
                {
                    assessmentCareChildByParentID.Add(item);
                }
            }

            dlAssessmentnCareChild.DataSource = assessmentCareChildByParentID;
            dlAssessmentnCareChild.DataBind();
        }
    }

}