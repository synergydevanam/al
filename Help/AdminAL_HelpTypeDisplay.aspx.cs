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

public partial class AdminAL_HelpTypeDisplay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            showAL_HelpTypeGrid();
        }
    }
    protected void lbSelect_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        
        gvAL_Help.DataSource = AL_HelpManager.GetAllAL_Helps().FindAll(x=>(x.HelpTypeID==id));
        gvAL_Help.DataBind();
    }
   
    private void showAL_HelpTypeGrid()
    {
        gvAL_HelpType.DataSource = AL_HelpTypeManager.GetAllAL_HelpTypes();
        gvAL_HelpType.DataBind();
    }
}
