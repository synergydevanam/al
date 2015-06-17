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

public partial class AdminStateInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadCountry();
            if (Request.QueryString["stateID"] != null)
            {
                int stateID = Int32.Parse(Request.QueryString["stateID"]);
                if (stateID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showStateData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        State state = new State();

        state.StateName = txtStateName.Text;
        state.CountryID = Int32.Parse(ddlCountry.SelectedValue);
        int resutl = StateManager.InsertState(state);
        Response.Redirect("AdminStateDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        State state = new State();
        state = StateManager.GetStateByID(Int32.Parse(Request.QueryString["stateID"]));
        State tempState = new State();
        tempState.StateID = state.StateID;

        tempState.StateName = txtStateName.Text;
        tempState.CountryID = Int32.Parse(ddlCountry.SelectedValue);
        bool result = StateManager.UpdateState(tempState);
        Response.Redirect("AdminStateDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtStateName.Text = "";
        ddlCountry.SelectedIndex = 0;
    }
    private void showStateData()
    {
        State state = new State();
        state = StateManager.GetStateByID(Int32.Parse(Request.QueryString["stateID"]));

        txtStateName.Text = state.StateName;
        ddlCountry.SelectedValue = state.CountryID.ToString();
    }
    private void loadCountry()
    {
        ListItem li = new ListItem("Select Country...", "0");
        ddlCountry.Items.Add(li);

        List<Country> countries = new List<Country>();
        countries = CountryManager.GetAllCountries();
        foreach (Country country in countries)
        {
            ListItem item = new ListItem(country.CountryName.ToString(), country.CountryID.ToString());
            ddlCountry.Items.Add(item);
        }
    }
}
