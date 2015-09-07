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

public partial class AdminPropertyDisplay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            showPropertyGrid();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminPropertyInsertUpdate.aspx?propertyID=0");
    }
    protected void lbSelect_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("AdminPropertyInsertUpdate.aspx?propertyID=" + id);
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        bool result = PropertyManager.DeleteProperty(Convert.ToInt32(linkButton.CommandArgument));
        showPropertyGrid();
    }

    private void showPropertyGrid()
    {
        /*
        string searchString = "";
        if (hfHasSearchCompleted.Value == "0" && Request.QueryString["SearchKey"]!=null)
        {
            hfHasSearchCompleted.Value = "1";
            searchString = "Where AL_Property.ExtraField1 like '%" + Request.QueryString["SearchKey"] + "%' or AL_Property.Address like '%" + Request.QueryString["SearchKey"] + "%'";        
        }
         * */
        gvProperty.DataSource = PropertyManager.GetAllPropertiesSearch("Where AL_Property.PropertyID in (0" + getLogin().ExtraField3 + ")");
        gvProperty.DataBind();
        /*gvProperty.DataSource = PropertyManager.GetAllPropertiesSearch(searchString);
        gvProperty.DataBind();
         * */
    }

    private Login getLogin()
    {
        Login login = new Login();
        try
        {
            if (Session["Login"] == null) { Session["PreviousPage"] = HttpContext.Current.Request.Url.AbsoluteUri; Response.Redirect("../LoginPage.aspx"); }

            login = (Login)Session["Login"];
        }
        catch (Exception ex)
        { }

        return login;
    }
}
