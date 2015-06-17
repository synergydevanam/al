using System;
using System.Collections;
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

public partial class AdminADLHeaderDetailDisplay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            showADLHeaderDetailGrid();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminADLHeaderDetailInsertUpdate.aspx?aDLHeaderDetailID=0");
    }
    protected void lbSelect_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("AdminADLHeaderDetailInsertUpdate.aspx?aDLHeaderDetailID=" + id);
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        bool result = ADLHeaderDetailManager.DeleteADLHeaderDetail(Convert.ToInt32(linkButton.CommandArgument));
        showADLHeaderDetailGrid();
    }

    private void showADLHeaderDetailGrid()
    {
        gvADLHeaderDetail.DataSource = ADLHeaderDetailManager.GetAllADLHeaderDetails();
        gvADLHeaderDetail.DataBind();
    }
}
