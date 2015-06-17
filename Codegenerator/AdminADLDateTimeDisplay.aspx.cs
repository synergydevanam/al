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

public partial class AdminADLDateTimeDisplay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            showADLDateTimeGrid();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminADLDateTimeInsertUpdate.aspx?aDLDateTimeID=0");
    }
    protected void lbSelect_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("AdminADLDateTimeInsertUpdate.aspx?aDLDateTimeID=" + id);
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        bool result = ADLDateTimeManager.DeleteADLDateTime(Convert.ToInt32(linkButton.CommandArgument));
        showADLDateTimeGrid();
    }

    private void showADLDateTimeGrid()
    {
        gvADLDateTime.DataSource = ADLDateTimeManager.GetAllADLDateTimes();
        gvADLDateTime.DataBind();
    }
}
