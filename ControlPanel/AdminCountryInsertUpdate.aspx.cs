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

public partial class AdminCountryInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["countryID"] != null)
            {
                int countryID = Int32.Parse(Request.QueryString["countryID"]);
                if (countryID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showCountryData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Country country = new Country();

        country.CountryName = txtCountryName.Text;
        int resutl = CountryManager.InsertCountry(country);
        Response.Redirect("AdminCountryDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Country country = new Country();
        country = CountryManager.GetCountryByID(Int32.Parse(Request.QueryString["countryID"]));
        Country tempCountry = new Country();
        tempCountry.CountryID = country.CountryID;

        tempCountry.CountryName = txtCountryName.Text;
        bool result = CountryManager.UpdateCountry(tempCountry);
        Response.Redirect("AdminCountryDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtCountryName.Text = "";
    }
    private void showCountryData()
    {
        Country country = new Country();
        country = CountryManager.GetCountryByID(Int32.Parse(Request.QueryString["countryID"]));

        txtCountryName.Text = country.CountryName;
    }
}
