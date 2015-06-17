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
 public partial class AdminMarketing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadMarketingData();
         		CustomerIDLoad();
		MarketingAgentIDLoad();
		MarketingCloserIDLoad();
		MarketingVanueIDLoad();
		LeadSourceIDLoad();
		GiftIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showMarketingData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	Marketing marketing = new Marketing ();
//	marketing.MarketingID=  int.Parse(ddlMarketingID.SelectedValue);
	marketing.CustomerID=  int.Parse(ddlCustomerID.SelectedValue);
	marketing.MarketingAgentID=  int.Parse(ddlMarketingAgentID.SelectedValue);
	marketing.MarketingCloserID=  int.Parse(ddlMarketingCloserID.SelectedValue);
	marketing.MarketingVanueID=  int.Parse(ddlMarketingVanueID.SelectedValue);
	marketing.LeadSourceID=  int.Parse(ddlLeadSourceID.SelectedValue);
	marketing.GiftID=  int.Parse(ddlGiftID.SelectedValue);
	marketing.DepositAmount=  decimal.Parse(txtDepositAmount.Text);
	marketing.Refundable=  bool.Parse( radRefundable.SelectedValue);
	marketing.Notes=  txtNotes.Text;
	int resutl =MarketingManager.InsertMarketing(marketing);
	Response.Redirect("AdminDisplayMarketing.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	Marketing marketing = new Marketing ();
	marketing.MarketingID=  int.Parse(Request.QueryString["ID"].ToString());
	marketing.CustomerID=  int.Parse(ddlCustomerID.SelectedValue);
	marketing.MarketingAgentID=  int.Parse(ddlMarketingAgentID.SelectedValue);
	marketing.MarketingCloserID=  int.Parse(ddlMarketingCloserID.SelectedValue);
	marketing.MarketingVanueID=  int.Parse(ddlMarketingVanueID.SelectedValue);
	marketing.LeadSourceID=  int.Parse(ddlLeadSourceID.SelectedValue);
	marketing.GiftID=  int.Parse(ddlGiftID.SelectedValue);
	marketing.DepositAmount=  decimal.Parse(txtDepositAmount.Text);
	marketing.Refundable=  bool.Parse( radRefundable.SelectedValue);
	marketing.Notes=  txtNotes.Text;
	bool  resutl =MarketingManager.UpdateMarketing(marketing);
	Response.Redirect("AdminDisplayMarketing.aspx");
	}
	private void showMarketingData()
	{
	 	Marketing marketing  = new Marketing ();
	 	marketing = MarketingManager.GetMarketingByMarketingID(Int32.Parse(Request.QueryString["ID"]));
	 	ddlCustomerID.SelectedValue  =marketing.CustomerID.ToString();
	 	ddlMarketingAgentID.SelectedValue  =marketing.MarketingAgentID.ToString();
	 	ddlMarketingCloserID.SelectedValue  =marketing.MarketingCloserID.ToString();
	 	ddlMarketingVanueID.SelectedValue  =marketing.MarketingVanueID.ToString();
	 	ddlLeadSourceID.SelectedValue  =marketing.LeadSourceID.ToString();
	 	ddlGiftID.SelectedValue  =marketing.GiftID.ToString();
	 	txtDepositAmount.Text =marketing.DepositAmount.ToString();
	 	 radRefundable.SelectedValue  =marketing.Refundable.ToString();
	 	txtNotes.Text =marketing.Notes.ToString();
	}
	
	private void CustomerIDLoad()
	{
		try {
		DataSet ds = CustomerManager.GetDropDownListAllCustomer();
		ddlCustomerID.DataValueField = "CustomerID";
		ddlCustomerID.DataTextField = "CustomerName";
		ddlCustomerID.DataSource = ds.Tables[0];
		ddlCustomerID.DataBind();
		ddlCustomerID.Items.Insert(0, new ListItem("Select Customer >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void MarketingAgentIDLoad()
	{
		try {
		DataSet ds = MarketingAgentManager.GetDropDownListAllMarketingAgent();
		ddlMarketingAgentID.DataValueField = "MarketingAgentID";
		ddlMarketingAgentID.DataTextField = "MarketingAgentName";
		ddlMarketingAgentID.DataSource = ds.Tables[0];
		ddlMarketingAgentID.DataBind();
		ddlMarketingAgentID.Items.Insert(0, new ListItem("Select MarketingAgent >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void MarketingCloserIDLoad()
	{
		try {
            DataSet ds = MarketingAgentManager.GetDropDownListAllMarketingAgent();
		ddlMarketingCloserID.DataValueField = "MarketingCloserID";
		ddlMarketingCloserID.DataTextField = "MarketingCloserName";
		ddlMarketingCloserID.DataSource = ds.Tables[0];
		ddlMarketingCloserID.DataBind();
		ddlMarketingCloserID.Items.Insert(0, new ListItem("Select MarketingCloser >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void MarketingVanueIDLoad()
	{
		try {
		DataSet ds = MarketingVanueManager.GetDropDownListAllMarketingVanue();
		ddlMarketingVanueID.DataValueField = "MarketingVanueID";
		ddlMarketingVanueID.DataTextField = "MarketingVanueName";
		ddlMarketingVanueID.DataSource = ds.Tables[0];
		ddlMarketingVanueID.DataBind();
		ddlMarketingVanueID.Items.Insert(0, new ListItem("Select MarketingVanue >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void LeadSourceIDLoad()
	{
		try {
		DataSet ds = LeadSourceManager.GetDropDownListAllLeadSource();
		ddlLeadSourceID.DataValueField = "LeadSourceID";
		ddlLeadSourceID.DataTextField = "LeadSourceName";
		ddlLeadSourceID.DataSource = ds.Tables[0];
		ddlLeadSourceID.DataBind();
		ddlLeadSourceID.Items.Insert(0, new ListItem("Select LeadSource >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void GiftIDLoad()
	{
		try {
		DataSet ds = GiftManager.GetDropDownListAllGift();
		ddlGiftID.DataValueField = "GiftID";
		ddlGiftID.DataTextField = "GiftName";
		ddlGiftID.DataSource = ds.Tables[0];
		ddlGiftID.DataBind();
		ddlGiftID.Items.Insert(0, new ListItem("Select Gift >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
}

