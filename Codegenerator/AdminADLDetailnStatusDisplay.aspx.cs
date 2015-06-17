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

public partial class AdminADLDetailnStatusDisplay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            showADLDetailnStatusGrid();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminADLDetailnStatusInsertUpdate.aspx?aDLDetailnStatusID=0");
    }
    protected void lbSelect_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("AdminADLDetailnStatusInsertUpdate.aspx?aDLDetailnStatusID=" + id);
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        bool result = ADLDetailnStatusManager.DeleteADLDetailnStatus(Convert.ToInt32(linkButton.CommandArgument));
        showADLDetailnStatusGrid();
    }

    private void showADLDetailnStatusGrid()
    {

        gvADLDetailnStatus.DataSource = ADLDetailnStatusManager.GetAllADLDetailnStatuss();
        gvADLDetailnStatus.DataBind();
    }
}
