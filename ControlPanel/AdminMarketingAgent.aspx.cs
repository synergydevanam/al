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
 public partial class AdminMarketingAgent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadMarketingAgentData();
         
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showMarketingAgentData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	MarketingAgent marketingAgent = new MarketingAgent ();
//	marketingAgent.MarketingAgentID=  int.Parse(ddlMarketingAgentID.SelectedValue);
	marketingAgent.MarketingAgenName=  txtMarketingAgenName.Text;
	int resutl =MarketingAgentManager.InsertMarketingAgent(marketingAgent);
	Response.Redirect("AdminDisplayMarketingAgent.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	MarketingAgent marketingAgent = new MarketingAgent ();
	marketingAgent.MarketingAgentID=  int.Parse(Request.QueryString["ID"].ToString());
	marketingAgent.MarketingAgenName=  txtMarketingAgenName.Text;
	bool  resutl =MarketingAgentManager.UpdateMarketingAgent(marketingAgent);
	Response.Redirect("AdminDisplayMarketingAgent.aspx");
	}
	private void showMarketingAgentData()
	{
	 	MarketingAgent marketingAgent  = new MarketingAgent ();
	 	marketingAgent = MarketingAgentManager.GetMarketingAgentByMarketingAgentID(Int32.Parse(Request.QueryString["ID"]));
	 	txtMarketingAgenName.Text =marketingAgent.MarketingAgenName.ToString();
	}
	
}

