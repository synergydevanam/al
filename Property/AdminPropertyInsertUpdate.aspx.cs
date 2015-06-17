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

public partial class AdminPropertyInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadCountry();
            loadState();
            loadCity();
            loadCompany();
            if (Request.QueryString["propertyID"] != null)
            {
                int propertyID = Int32.Parse(Request.QueryString["propertyID"]);
                if (propertyID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showPropertyData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Property property = new Property();

        property.PropertyName = txtPropertyName.Text;
        property.Address = txtAddress.Text;
        property.CountryID = Int32.Parse(ddlCountry.SelectedValue);
        property.StateID = Int32.Parse(ddlState.SelectedValue);
        property.CityID = Int32.Parse(ddlCity.SelectedValue);
        property.ExtraField1 = txtExtraField1.Text;
        property.ExtraField2 = txtExtraField2.Text;
        property.ExtraField3 = txtExtraField3.Text;
        property.ExtraField4 = txtExtraField4.Text;
        property.ExtraField5 = ddlCompnay.SelectedValue;
        property.ExtraField6 = txtExtraField6.Text;
        property.ExtraField7 = ddlStatus.SelectedValue; 
        property.ExtraField8 = txtExtraField8.Text;
        property.ExtraField9 = txtExtraField9.Text;
        property.ExtraField10 = txtExtraField10.Text;
        int resutl = PropertyManager.InsertProperty(property);
        Response.Redirect("AdminPropertyDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Property property = new Property();
        property = PropertyManager.GetPropertyByID(Int32.Parse(Request.QueryString["propertyID"]));
        Property tempProperty = new Property();
        tempProperty.PropertyID = property.PropertyID;

        tempProperty.PropertyName = txtPropertyName.Text;
        tempProperty.Address = txtAddress.Text;
        tempProperty.CountryID = Int32.Parse(ddlCountry.SelectedValue);
        tempProperty.StateID = Int32.Parse(ddlState.SelectedValue);
        tempProperty.CityID = Int32.Parse(ddlCity.SelectedValue);
        tempProperty.ExtraField1 = txtExtraField1.Text;
        tempProperty.ExtraField2 = txtExtraField2.Text;
        tempProperty.ExtraField3 = txtExtraField3.Text;
        tempProperty.ExtraField4 = txtExtraField4.Text;
        tempProperty.ExtraField5 = ddlCompnay.SelectedValue;
        tempProperty.ExtraField6 = txtExtraField6.Text;
        tempProperty.ExtraField7 = ddlStatus.SelectedValue;
        tempProperty.ExtraField8 = txtExtraField8.Text;
        tempProperty.ExtraField9 = txtExtraField9.Text;
        tempProperty.ExtraField10 = txtExtraField10.Text;
        bool result = PropertyManager.UpdateProperty(tempProperty);
        Response.Redirect("AdminPropertyDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtPropertyName.Text = "";
        txtAddress.Text = "";
        ddlCountry.SelectedIndex = 0;
        ddlState.SelectedIndex = 0;
        ddlCity.SelectedIndex = 0;
        ddlCompnay.SelectedIndex=0;
        txtExtraField1.Text = "";
        txtExtraField2.Text = "";
        txtExtraField3.Text = "";
        txtExtraField4.Text = "";
        txtExtraField5.Text = "";
        txtExtraField6.Text = "";
        txtExtraField7.Text = "";
        txtExtraField8.Text = "";
        txtExtraField9.Text = "";
        txtExtraField10.Text = "";
    }
    private void showPropertyData()
    {
        Property property = new Property();
        property = PropertyManager.GetPropertyByID(Int32.Parse(Request.QueryString["propertyID"]));

        txtPropertyName.Text = property.PropertyName;
        txtAddress.Text = property.Address;
        ddlCountry.SelectedValue = property.CountryID.ToString();
        ddlState.SelectedValue = property.StateID.ToString();
        ddlCity.SelectedValue = property.CityID.ToString();
        txtExtraField1.Text = property.ExtraField1;
        txtExtraField2.Text = property.ExtraField2;
        txtExtraField3.Text = property.ExtraField3;
        txtExtraField4.Text = property.ExtraField4;
        ddlCompnay.SelectedValue = property.ExtraField5;
        txtExtraField6.Text = property.ExtraField6;
        ddlStatus.SelectedValue = property.ExtraField7=="InActive"?"InActive":"Active";
        txtExtraField8.Text = property.ExtraField8;
        txtExtraField9.Text = property.ExtraField9;
        txtExtraField10.Text = property.ExtraField10;
    }
    private void loadCountry()
    {
        ListItem li = new ListItem("Select Country...", "0");
        ddlCountry.Items.Add(li);

        //List<Country> countries = new List<Country>();
        //countries = CountryManager.GetAllCountries();
        //foreach (Country country in countries)
        //{
        //    ListItem item = new ListItem(country.CountryName.ToString(), country.CountryID.ToString());
        //    ddlCountry.Items.Add(item);
        //}
    }

    private void loadCompany()
    {
        ListItem li = new ListItem("Select >>", "0");
        ddlCompnay.Items.Add(li);

        List<Company> Companies = new List<Company>();
        Companies = CompanyManager.GetAllCompanies();
        foreach (Company country in Companies)
        {
            ListItem item = new ListItem(country.CompanyName.ToString(), country.CompanyID.ToString());
            ddlCompnay.Items.Add(item);
        }
    }
    private void loadState()
    {
        ListItem li = new ListItem("Select State...", "0");
        ddlState.Items.Add(li);

        List<State> states = new List<State>();
        states = StateManager.GetAllStates();
        foreach (State state in states)
        {
            ListItem item = new ListItem(state.StateName.ToString(), state.StateID.ToString());
            ddlState.Items.Add(item);
        }
    }
    private void loadCity()
    {
        ListItem li = new ListItem("Select City...", "0");
        ddlCity.Items.Add(li);

        //List<City> cities = new List<City>();
        //cities = CityManager.GetAllCities();
        //foreach (City city in cities)
        //{
        //    ListItem item = new ListItem(city.CityName.ToString(), city.CityID.ToString());
        //    ddlCity.Items.Add(item);
        //}
    }
}
