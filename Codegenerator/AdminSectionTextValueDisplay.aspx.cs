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

public partial class AdminSectionTextValueDisplay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            showSectionTextValueGrid();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminSectionTextValueInsertUpdate.aspx?sectionTextValueID=0");
    }
    protected void lbSelect_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("AdminSectionTextValueInsertUpdate.aspx?sectionTextValueID=" + id);
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        bool result = SectionTextValueManager.DeleteSectionTextValue(Convert.ToInt32(linkButton.CommandArgument));
        showSectionTextValueGrid();
    }

    private void showSectionTextValueGrid()
    {
        gvSectionTextValue.DataSource = SectionTextValueManager.GetAllSectionTextValues();
        gvSectionTextValue.DataBind();
    }
}
