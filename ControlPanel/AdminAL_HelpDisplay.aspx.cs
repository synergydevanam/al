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

public partial class AdminAL_HelpDisplay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            showAL_HelpGrid();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminAL_HelpInsertUpdate.aspx?aL_HelpID=0");
    }
    protected void lbSelect_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("AdminAL_HelpInsertUpdate.aspx?aL_HelpID=" + id);
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        bool result = AL_HelpManager.DeleteAL_Help(Convert.ToInt32(linkButton.CommandArgument));
        showAL_HelpGrid();
    }

    private void showAL_HelpGrid()
    {
        gvAL_Help.DataSource = AL_HelpManager.GetAllAL_Helps();
        gvAL_Help.DataBind();
    }
}
