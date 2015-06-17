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
 public partial class AdminMarketingVanue : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadMarketingVanueData();
         
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showMarketingVanueData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	MarketingVanue marketingVanue = new MarketingVanue ();
//	marketingVanue.MarketingVanueID=  int.Parse(ddlMarketingVanueID.SelectedValue);
	marketingVanue.MarketingVanueName=  txtMarketingVanueName.Text;
	int resutl =MarketingVanueManager.InsertMarketingVanue(marketingVanue);
	Response.Redirect("AdminDisplayMarketingVanue.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	MarketingVanue marketingVanue = new MarketingVanue ();
	marketingVanue.MarketingVanueID=  int.Parse(Request.QueryString["ID"].ToString());
	marketingVanue.MarketingVanueName=  txtMarketingVanueName.Text;
	bool  resutl =MarketingVanueManager.UpdateMarketingVanue(marketingVanue);
	Response.Redirect("AdminDisplayMarketingVanue.aspx");
	}
	private void showMarketingVanueData()
	{
	 	MarketingVanue marketingVanue  = new MarketingVanue ();
	 	marketingVanue = MarketingVanueManager.GetMarketingVanueByMarketingVanueID(Int32.Parse(Request.QueryString["ID"]));
	 	txtMarketingVanueName.Text =marketingVanue.MarketingVanueName.ToString();
	}
	
}

