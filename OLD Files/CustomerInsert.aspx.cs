using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class CustomerInsert : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            MarketingAgentIDLoad();
            MarketingCloserIDLoad();
            MarketingVanueIDLoad();
            LeadSourceIDLoad();
            GiftIDLoad();
            RelationshipIDLoad();
            IncomeIDLoad();
            TourStatusIDLoad();
            SalesCenterIDLoad();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Customer customer = new Customer();
        //	customer.CustomerID=  int.Parse(ddlCustomerID.SelectedValue);
        customer.FirstName = txtFirstName.Text;
        customer.LastName = txtLastName.Text;
        customer.Age = int.Parse(txtAge.Text);
        customer.GuestName = txtGuestName.Text;
        customer.GuestAge = int.Parse(txtGuestAge.Text);
        customer.RelationshipID = int.Parse(ddlRelationshipID.SelectedValue);
        customer.IncomeID = int.Parse(ddlIncomeID.SelectedValue);
        customer.PrimaryPhone = txtPrimaryPhone.Text;
        customer.SecondaryPhone = txtSecondaryPhone.Text;
        customer.Address1 = txtAddress1.Text;
        customer.Address2 = txtAddress2.Text;
        customer.City = txtCity.Text;
        customer.State = int.Parse(ddlState.SelectedItem.Value);
        customer.Country = int.Parse(ddlCountry.SelectedItem.Value);
        customer.Business = txtBusiness.Text;
        customer.Email = txtEmail.Text;
        int CustomerID = CustomerManager.InsertCustomer(customer);

        insertTour(CustomerID);
        insetMarketing(CustomerID);

        Response.Redirect("DisplayCustomer.aspx");
    }
    
    private void SalesCenterIDLoad()
    {
        try
        {
            DataSet ds = SalesCenterManager.GetDropDownListAllSalesCenter();
            ddlSalesCenterID.DataValueField = "SalesCenterID";
            ddlSalesCenterID.DataTextField = "SalesCenterName";
            ddlSalesCenterID.DataSource = ds.Tables[0];
            ddlSalesCenterID.DataBind();
            ddlSalesCenterID.Items.Insert(0, new ListItem("Select Sales Center >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    private void TourStatusIDLoad()
    {
        try
        {
            DataSet ds = TourStatusManager.GetDropDownListAllTourStatus();
            ddlTourStatusID.DataValueField = "TourStatusID";
            ddlTourStatusID.DataTextField = "TourStatusName";
            ddlTourStatusID.DataSource = ds.Tables[0];
            ddlTourStatusID.DataBind();
            ddlTourStatusID.Items.Insert(0, new ListItem("Select TourStatus >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    public void insetMarketing(int cunstoreID)
    {

        Marketing marketing = new Marketing();
        //	marketing.MarketingID=  int.Parse(ddlMarketingID.SelectedValue);
        marketing.CustomerID = cunstoreID;
        marketing.MarketingAgentID = int.Parse(ddlMarketingAgentID.SelectedValue);
        marketing.MarketingCloserID = int.Parse(ddlMarketingCloserID.SelectedValue);
        marketing.MarketingVanueID = int.Parse(ddlMarketingVanueID.SelectedValue);
        marketing.LeadSourceID = int.Parse(ddlLeadSourceID.SelectedValue);
        marketing.GiftID = int.Parse(ddlGiftID.SelectedValue);
        marketing.DepositAmount = decimal.Parse(txtDepositAmount.Text);
      
        marketing.Refundable =ddlDepositRefundable.SelectedValue == "Yes" ? true : false ;
        marketing.Notes = txtNotes.Text;
        int resutl = MarketingManager.InsertMarketing(marketing);
    }

    public void insertTour(int CustomerID)
    {
        Tour tour = new Tour();
        //	tour.TourID=  int.Parse(ddlTourID.SelectedValue);
        tour.CustomerID =  CustomerID ;
        tour.TourName = "";
        tour.TourStatusID = int.Parse(ddlTourStatusID.SelectedValue);
        tour.SalesCenterID = int.Parse(ddlSalesCenterID.SelectedValue);
        tour.TourDate = DateTime.Parse(txtTourDate.Text);
        tour.TourTime = txtTourTime.Text;
        int resutl = TourManager.InsertTour(tour);
    }
    private void RelationshipIDLoad()
    {
        try
        {
            DataSet ds = RelationshipManager.GetDropDownListAllRelationship();
            ddlRelationshipID.DataValueField = "RelationshipID";
            ddlRelationshipID.DataTextField = "RelationshipName";
            ddlRelationshipID.DataSource = ds.Tables[0];
            ddlRelationshipID.DataBind();
            ddlRelationshipID.Items.Insert(0, new ListItem("Select Relationship >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    private void IncomeIDLoad()
    {
        try
        {
            DataSet ds = IncomeManager.GetDropDownListAllIncome();
            ddlIncomeID.DataValueField = "IncomeID";
            ddlIncomeID.DataTextField = "IncomeName";
            ddlIncomeID.DataSource = ds.Tables[0];
            ddlIncomeID.DataBind();
            ddlIncomeID.Items.Insert(0, new ListItem("Select Income >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    #region "Markeing"
    private void MarketingAgentIDLoad()
    {
        try
        {
            DataSet ds = MarketingAgentManager.GetDropDownListAllMarketingAgent();
            ddlMarketingAgentID.DataValueField = "MarketingAgentID";
            ddlMarketingAgentID.DataTextField = "MarketingAgentName";
            ddlMarketingAgentID.DataSource = ds.Tables[0];
            ddlMarketingAgentID.DataBind();
            ddlMarketingAgentID.Items.Insert(0, new ListItem("Select MarketingAgent >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    private void MarketingCloserIDLoad()
    {
        try
        {
            DataSet ds = MarketingAgentManager.GetDropDownListAllMarketingAgent();
            ddlMarketingCloserID.DataValueField = "MarketingAgentID";
            ddlMarketingCloserID.DataTextField = "MarketingAgentName";
            ddlMarketingCloserID.DataSource = ds.Tables[0];
            ddlMarketingCloserID.DataBind();
            ddlMarketingCloserID.Items.Insert(0, new ListItem("Select MarketingCloser >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    private void MarketingVanueIDLoad()
    {
        try
        {
            DataSet ds = MarketingVanueManager.GetDropDownListAllMarketingVanue();
            ddlMarketingVanueID.DataValueField = "MarketingVanueID";
            ddlMarketingVanueID.DataTextField = "MarketingVanueName";
            ddlMarketingVanueID.DataSource = ds.Tables[0];
            ddlMarketingVanueID.DataBind();
            ddlMarketingVanueID.Items.Insert(0, new ListItem("Select MarketingVanue >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    private void LeadSourceIDLoad()
    {
        try
        {
            DataSet ds = LeadSourceManager.GetDropDownListAllLeadSource();
            ddlLeadSourceID.DataValueField = "LeadSourceID";
            ddlLeadSourceID.DataTextField = "LeadSourceName";
            ddlLeadSourceID.DataSource = ds.Tables[0];
            ddlLeadSourceID.DataBind();
            ddlLeadSourceID.Items.Insert(0, new ListItem("Select LeadSource >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    private void GiftIDLoad()
    {
        try
        {
            DataSet ds = GiftManager.GetDropDownListAllGift();
            ddlGiftID.DataValueField = "GiftID";
            ddlGiftID.DataTextField = "GiftName";
            ddlGiftID.DataSource = ds.Tables[0];
            ddlGiftID.DataBind();
            ddlGiftID.Items.Insert(0, new ListItem("Select Gift >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    #endregion
}