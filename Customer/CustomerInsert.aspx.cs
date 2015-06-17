using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;

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
            string CustomerID = Request.QueryString["ID"];
            if (!string.IsNullOrEmpty(CustomerID))
            {

                mCusomerID.Value = CustomerID;

                Customer customer = new Customer();
                customer = CustomerManager.GetCustomerByCustomerID(Convert.ToInt32(CustomerID));
                LoadTourInfo(Convert.ToInt32(CustomerID));
                LoadMarktingInfo(Convert.ToInt32(CustomerID));
                showAppointment(Convert.ToInt32(CustomerID));
                EditAppoiment.Visible = true;
                EditAppoimentBody.Visible = true;
                traddAppoinment.Visible = false;
                trAppoinmentdtls.Visible = false;
                if (customer != null)
                {
                    LoadCustomerInfo(customer);
                    btnAdd0.Text = "Update";
                }

                hplapplookup.Attributes.Add("onclick", "window.open('" + "admin/AppointmentLookUp.aspx?mID=" + "0" + "',null,'height=450, width=650,status= no, resizable= no, scrollbars=no, toolbar=no,location=no,menubar=no ');");
  
            }
            else
            {
                EditAppoiment.Visible = false;
                EditAppoimentBody.Visible = false;
                traddAppoinment.Visible = true;
                trAppoinmentdtls.Visible = true;
            }
        }
        ddlRelationshipID.Attributes.Add("onchange", "getRoleDescription()");
        
    }
    private void showAppointment(int clientID)
    {
        SetPermission();
        gvAppointmnet.DataSource = AppointmnetManager.GetAllAppointmnetByClientID(clientID);
        gvAppointmnet.DataBind();

        //  Appointmnet appointmnet = new Appointmnet();
        //appointmnet = AppointmnetManager.GetAppointmnetByClientID(clientID);

        // txtAppointmentDate.Text = appointmnet.Date.ToString("MM/dd/yyyy");
        // txtAppointmentTime.Text = appointmnet.Time.ToString();
        //  hdnappointmnetID.Value = appointmnet.AppointmnetID.ToString();
        //  ddlAppointmentCityID.SelectedValue = appointmnet.City.ToString();
        // ddlAppointMentMetroLocationID.SelectedValue = appointmnet.MetroLocationID.ToString();
        // ddlStastusID.SelectedValue = appointmnet.StastusID.ToString();
        //  txtCreatedDate.Text = appointmnet.CreatedDate.ToString();
    }
    public void LoadMarktingInfo(int CustometID)
    {

        Marketing marketing = new Marketing();
        marketing = MarketingManager.GetCustomerByCustomerID(CustometID);
        //	marketing.MarketingID=  int.Parse(ddlMarketingID.SelectedValue);
        marketing.CustomerID = CustometID;
        mMarketingID.Value = marketing.MarketingID.ToString();

        ddlMarketingAgentID.SelectedIndex = ddlMarketingAgentID.Items.IndexOf(ddlMarketingAgentID.Items.FindByValue(marketing.MarketingAgentID.ToString()));
        ddlMarketingCloserID.SelectedIndex = ddlMarketingCloserID.Items.IndexOf(ddlMarketingCloserID.Items.FindByValue(marketing.MarketingCloserID.ToString()));
        ddlMarketingVanueID.SelectedIndex = ddlMarketingVanueID.Items.IndexOf(ddlMarketingVanueID.Items.FindByValue(marketing.MarketingVanueID.ToString()));

        ddlLeadSourceID.SelectedIndex = ddlLeadSourceID.Items.IndexOf(ddlLeadSourceID.Items.FindByValue(marketing.LeadSourceID.ToString()));
        ddlGiftID.SelectedIndex = ddlLeadSourceID.Items.IndexOf(ddlGiftID.Items.FindByValue(marketing.GiftID.ToString()));
        ddlGiftID.SelectedIndex = ddlLeadSourceID.Items.IndexOf(ddlGiftID.Items.FindByValue(marketing.GiftID.ToString()));



        if (marketing.DepositAmount != 0)
        {
            txtDepositAmount.Text = marketing.DepositAmount.ToString();
        }

        if (marketing.Refundable)
        {
            ddlDepositRefundable.SelectedIndex = ddlDepositRefundable.Items.IndexOf(ddlDepositRefundable.Items.FindByValue("True"));
        }
        else
        {
            ddlDepositRefundable.SelectedIndex = ddlDepositRefundable.Items.IndexOf(ddlDepositRefundable.Items.FindByValue("False"));
        }

        txtNotes.Text = marketing.Notes;

    }
    public void LoadTourInfo(int customerID)
    { 
        Tour tour = new Tour();
        tour = TourManager.GetTourByCustomerID(customerID);
        mTourID.Value = tour.TourID.ToString();
        if (tour.TourDate.Year != 1900)
        {
            txtTourDate.Text = tour.TourDate.ToString("MM/dd/yyyy");
        }
        
        txtTourTime.Text = tour.TourTime;
        
        ddlTourStatusID.SelectedIndex = ddlTourStatusID.Items.IndexOf(ddlTourStatusID.Items.FindByValue(tour.TourStatusID.ToString()));
        ddlSalesCenterID.SelectedIndex = ddlSalesCenterID.Items.IndexOf(ddlSalesCenterID.Items.FindByValue( tour.SalesCenterID.ToString()));



    }
    public void LoadCustomerInfo(Customer customer)
    {
        try
        {
            
            //	customer.CustomerID=  int.Parse(ddlCustomerID.SelectedValue);
            txtFirstName.Text = customer.FirstName;
             txtLastName.Text = customer.LastName ;
            int result = 0;
            if (int.TryParse(customer.Age.ToString(), out result))
            {
                customer.Age = int.Parse(customer.Age.ToString());
            }
            else
            {
                customer.Age = 0;
            }

            if (customer.Age == 0)
            {
                txtAge.Text = "";
            }
            else
            {
                txtAge.Text = customer.Age.ToString();
            }

            txtPrimaryPhone.Text = customer.PrimaryPhone;
            txtSecondaryPhone.Text = customer.SecondaryPhone;
            txtAddress1.Text = customer.Address1;
            txtAddress2.Text = customer.Address2;
            txtCity.Text = customer.City;
            txtGuestFirstName.Text = customer.GuestFirstname;
            txtGuestLastName.Text = customer.GuestLastname;
            txtGuestNotes.Text = customer.GuestNotes;
            txtGuestPhone.Text = customer.GuestPhone;
            txtGuestZip.Text = customer.GuestZip;
            txtGuestCity.Text = customer.GuestCity;
            txtGuestaddress.Text = customer.GuestAddress;
            txtGuestEmail.Text = customer.GuestEmail;
            txtBusiness.Text = customer.Business;
            txtEmail.Text = customer.Email;
            
            customer.GuestName = customer.GuestName;
            if (customer.GuestAge == 0)
            {
                txtGuestAge.Text = "";
            }
            else
            {
                txtGuestAge.Text = customer.GuestAge.ToString();
            }


            ddlGuestState.SelectedIndex = ddlGuestState.Items.IndexOf(ddlGuestState.Items.FindByValue(customer.Gueststate));
            ddlRelationshipID.SelectedIndex = ddlRelationshipID.Items.IndexOf(ddlRelationshipID.Items.FindByValue(customer.RelationshipID.ToString()));
            ddlIncomeID.SelectedIndex = ddlIncomeID.Items.IndexOf(ddlIncomeID.Items.FindByValue(customer.IncomeID.ToString()));
            ddlState.SelectedIndex = ddlState.Items.IndexOf(ddlState.Items.FindByValue(customer.State.ToString()));
            ddlCountry.SelectedIndex = ddlCountry.Items.IndexOf(ddlCountry.Items.FindByValue(customer.Country.ToString()));


        
              if (customer.RelationshipID == 3 )
              {
                  dGuestAccompany.Visible = true;
                  dGuestAccompany.Style.Add("display", "");

              }
             
            if (customer.GuestAccompany == "Yes")
            {
                rYes.Checked = true;
                gfName.Style.Add("display", "");
                glname.Style.Add("display", "");
                glname.Style.Add("display", "");
                GuestZip.Style.Add("display", "");
                dGuestAccompany.Style.Add("display", "");
                GuestAge.Style.Add("display", "");
                GuestPhone.Style.Add("display", "");
                Guestaddress.Style.Add("display", "");
                GuestEmail.Style.Add("display", "");
                gNotes.Style.Add("display", "");
                Gueststate.Style.Add("display", "");

              
            }
//                Request.Form["GuestYN"].




            
        }
        catch { }
            
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                Customer customer = new Customer();
                //	customer.CustomerID=  int.Parse(ddlCustomerID.SelectedValue);
                customer.FirstName = txtFirstName.Text;
                customer.LastName = txtLastName.Text;
                int result = 0;
                if (int.TryParse(txtAge.Text, out result))
                {
                    customer.Age = int.Parse(txtAge.Text);
                }
                else
                {
                    customer.Age = 0;
                }

                customer.GuestName = "";

                if (int.TryParse(txtGuestAge.Text, out result))
                {
                    customer.GuestAge = int.Parse(txtGuestAge.Text);
                }
                else
                {
                    customer.GuestAge = 0;
                }

                if (int.TryParse(ddlRelationshipID.SelectedValue, out result))
                {
                    customer.RelationshipID = int.Parse(ddlRelationshipID.SelectedValue);
                }
                else
                {
                    customer.RelationshipID = 0;
                }


                if (int.TryParse(ddlIncomeID.SelectedValue, out result))
                {
                    customer.IncomeID = int.Parse(ddlIncomeID.SelectedValue);
                }
                else
                {
                    customer.IncomeID = 0;
                }

                customer.Zipcode = txtZipcode.Text;
                customer.PrimaryPhone = txtPrimaryPhone.Text;
                customer.SecondaryPhone = txtSecondaryPhone.Text;
                customer.Address1 = txtAddress1.Text;
                customer.Address2 = txtAddress2.Text;
                customer.City = txtCity.Text;
                if (int.TryParse(ddlState.SelectedValue, out result))
                {
                    customer.State = int.Parse(ddlState.SelectedItem.Value);
                }
                else
                {
                    customer.State = 0;
                }

                if (int.TryParse(ddlCountry.SelectedValue, out result))
                {
                    customer.Country = int.Parse(ddlCountry.SelectedItem.Value);
                }
                else
                {
                    customer.Country = 0;
                }

                customer.Business = txtBusiness.Text;
                customer.Email = txtEmail.Text;
                if (Request.Form["GuestYN"] != null)
                {
                    customer.GuestAccompany = Request.Form["GuestYN"];
                }
                else
                {
                    customer.GuestAccompany = "";
                }

                if (rYes.Checked)
                {
                    customer.GuestAccompany = "Yes";
                }
                else
                {
                    customer.GuestAccompany = "No";
                }
                customer.GuestFirstname = txtGuestFirstName.Text.Trim();
                customer.GuestLastname = txtGuestLastName.Text.Trim();
                customer.GuestNotes = txtGuestNotes.Text.Trim();
                customer.GuestPhone = txtGuestPhone.Text.Trim();
                customer.Gueststate = ddlGuestState.SelectedItem.Value;
                customer.GuestZip = txtGuestZip.Text.Trim();
                customer.GuestCity = txtGuestCity.Text.Trim();
                customer.GuestAddress = txtGuestaddress.Text.Trim();
                customer.GuestEmail = txtGuestEmail.Text.Trim();

                if (btnAdd0.Text == "Update")
                {

                    customer.CustomerID = Convert.ToInt32(mCusomerID.Value);
                    CustomerManager.UpdateCustomer(customer);
                    UpdateTour();
                    UpdateMarketing();
                }
                else
                {
                    int CustomerID = CustomerManager.InsertCustomer(customer);

                    insertTour(CustomerID);
                    insetMarketing(CustomerID);
                    addAppoinmemnt(CustomerID);
                }
            }
            catch { }
            Response.Redirect("DisplayCustomer.aspx");
        }
        
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
    public void UpdateMarketing()
    {

        Marketing marketing = new Marketing();
        marketing.MarketingID = Convert.ToInt32(mMarketingID.Value); 
        marketing.CustomerID = Convert.ToInt32(mCusomerID.Value);
        marketing.MarketingAgentID = int.Parse(ddlMarketingAgentID.SelectedValue);
        marketing.MarketingCloserID = int.Parse(ddlMarketingCloserID.SelectedValue);
        marketing.MarketingVanueID = int.Parse(ddlMarketingVanueID.SelectedValue);
        marketing.LeadSourceID = int.Parse(ddlLeadSourceID.SelectedValue);
        marketing.GiftID = int.Parse(ddlGiftID.SelectedValue);

        decimal result = 0;
        if (decimal.TryParse(txtDepositAmount.Text, out result))
        {
            marketing.DepositAmount = decimal.Parse(txtDepositAmount.Text);
        }
        else
        {
            marketing.DepositAmount = 0;
        }


        marketing.Refundable = ddlDepositRefundable.SelectedValue == "Yes" ? true : false;
        marketing.Notes = txtNotes.Text;
        MarketingManager.UpdateMarketing(marketing);
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

        decimal result = 0;
        if (decimal.TryParse(txtDepositAmount.Text, out result))
        {
            marketing.DepositAmount = decimal.Parse(txtDepositAmount.Text);
        }
        else
        {
            marketing.DepositAmount = 0;
        }
        
      
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
        if (!string.IsNullOrEmpty(txtTourDate.Text.Trim()))
        {
            tour.TourDate = DateTime.Parse(txtTourDate.Text);
        }
        else
        {
            tour.TourDate = Convert.ToDateTime("1/1/1900");
        }
        tour.TourTime = txtTourTime.Text;
        int resutl = TourManager.InsertTour(tour);
       
    }
    public void UpdateTour()
    {
        Tour tour = new Tour();
        //	tour.TourID=  int.Parse(ddlTourID.SelectedValue);
        tour.CustomerID =  Convert.ToInt32(mCusomerID.Value) ;
        tour.TourID = Convert.ToInt32(mTourID.Value);
        tour.TourName = "";
        tour.TourStatusID = int.Parse(ddlTourStatusID.SelectedValue);
        tour.SalesCenterID = int.Parse(ddlSalesCenterID.SelectedValue);
        if (!string.IsNullOrEmpty(txtTourDate.Text.Trim()))
        {
            tour.TourDate = DateTime.Parse(txtTourDate.Text);
        }
        else
        {
            tour.TourDate = Convert.ToDateTime("1/1/1900");
        }
        tour.TourTime = txtTourTime.Text;
        TourManager.UpdateTour(tour);

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

    public void addAppoinmemnt(int clientid)
    {
        MembershipUser currentUser;
        currentUser = Membership.GetUser();



        if (txtAppointmentDate.Text != "" && txtAppointmentTime.Text != "")
        {
            Appointmnet appointmnet = new Appointmnet();
            //	appointmnet.AppointmnetID=  int.Parse(ddlAppointmnetID.SelectedValue);
            appointmnet.ClientID = clientid;
            appointmnet.Date = DateTime.Parse(txtAppointmentDate.Text);
            appointmnet.Time = txtAppointmentTime.Text;
            appointmnet.CreateBy = currentUser.ProviderUserKey.ToString();
            appointmnet.City = txtCity.Text;
            appointmnet.MetroLocationID = int.Parse("0");
            appointmnet.StastusID = 1;
            appointmnet.CreatedDate = DateTime.Now;
            int resutl = AppointmnetManager.InsertAppointmnet(appointmnet);

        }
    }


    protected void btnAddAppointment_Click(object sender, EventArgs e)
    {
        div_appointmentadd.Visible = true;

        btnSaveAppointment.Visible = true;
        btnCancelAppointment.Visible = true;
        btnAddAppointment.Visible = false;
    }
    public FormRights fright;
    public void SetPermission()
    {



        MembershipUser currentUser;
        currentUser = Membership.GetUser();
        if (currentUser == null)
            Response.Redirect("~/login.aspx");
        var clientID = currentUser.ProviderUserKey.ToString();
        string pageName = "AddCustomer";
        if (fright != null)
        {
        fright = FormRightsManager.GetFormRightsByUserIDFormID(pageName, clientID);



        //update option
        btnAddAppointment.Visible = fright.UpdateRight == true ? true : false;
        
   

        btnAddAppointment.Visible = fright.InsertRight == true ? true : false;
        }
        
        //GlobalFunction gf = new GlobalFunction();
        //GlobalFunction.SetFormPermission(this, fright);
    }
   
    protected void btnSaveAppointment_Click(object sender, EventArgs e)
    {
       

        MembershipUser currentUser;
        currentUser = Membership.GetUser();
        Appointmnet appointmnet = new Appointmnet();
        //	appointmnet.AppointmnetID=  int.Parse(ddlAppointmnetID.SelectedValue);
        appointmnet.ClientID = Convert.ToInt32(mCusomerID.Value);
        appointmnet.Date = DateTime.Parse(txtAptDate.Text);
        appointmnet.Time = txtApttime.Text;
        appointmnet.CreateBy = currentUser.ProviderUserKey.ToString();
        // appointmnet.City = int.Parse(ddlAppointmentCityID.SelectedValue);
        appointmnet.MetroLocationID = int.Parse("0");
        appointmnet.StastusID = 1;
        appointmnet.CreatedDate = DateTime.Now;
        int resutl = AppointmnetManager.InsertAppointmnet(appointmnet);
        showAppointment(Convert.ToInt32(mCusomerID.Value));
        div_appointmentadd.Visible = false;

        btnSaveAppointment.Visible = false;
        btnCancelAppointment.Visible = false;
        btnAddAppointment.Visible = true;
        ClearAppointment();
    }
    private void ClearAppointment()
    {
        txtAppointmentDate.Text = "";
        txtAppointmentTime.Text = "";
    }

    protected void btnCancelAppointment_Click(object sender, EventArgs e)
    {
        div_appointmentadd.Visible = false;

        btnSaveAppointment.Visible = false;
        btnCancelAppointment.Visible = false;
        btnAddAppointment.Visible = true;
        ClearAppointment();
    }

    protected void gvAppointmnet_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvAppointmnet.EditIndex = -1;

        var clientId = int.Parse(Request.QueryString["ID"].ToString());
        showAppointment(clientId);
    }
    protected void gvAppointmnet_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvAppointmnet.EditIndex = e.NewEditIndex;
        var clientId = int.Parse(Request.QueryString["ID"].ToString());
        showAppointment(clientId);
    }
    protected void gvAppointmnet_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var lnkAppointmentId = (Label)gvAppointmnet.Rows[e.RowIndex].FindControl("_lnkAppointmentId");
        var ddlStatus = (DropDownList)gvAppointmnet.Rows[e.RowIndex].FindControl("_ddlStatus");

        var status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        var id = Convert.ToInt32(lnkAppointmentId.Text.Trim());

        var result = AppointmnetManager.UpdateAppointmnetStatus(id, status);
        gvAppointmnet.EditIndex = -1;

        var clientId = int.Parse(Request.QueryString["ID"].ToString());
        showAppointment(clientId);
    }
    protected void gvAppointmnet_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton _btnEdit = (LinkButton)e.Row.FindControl("_btnEdit");
            //LinkButton btnDelete = (LinkButton)gvAppointmnet.FindControl("LinkButton");
            if (_btnEdit != null)
            {
                if (fright != null)
                _btnEdit.Visible = fright.UpdateRight == true ? true : false;
            }
        }
    }
}