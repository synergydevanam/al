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
using System.Collections.Generic;

public partial class AdminResidentDisplay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadProperty();
            showResidentGrid();
        }
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

    private void loadProperty()
    {
        ListItem li = new ListItem("All Properties...", "0");
        ddlPropertyID.Items.Add(li);

        List<Property> properties = new List<Property>();
        properties = PropertyManager.GetAllPropertiesSearch("Where AL_Property.ExtraField7 <> 'InActive' and AL_Property.PropertyID in (0" +( getLogin().ExtraField3==""?"":","+getLogin().ExtraField3) + ")"); 
        foreach (Property property in properties)
        {
            ListItem item = new ListItem(property.Address.ToString(), property.PropertyID.ToString());
            ddlPropertyID.Items.Add(item);
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminResidentInsertUpdate.aspx?residentID=0");
    }
    protected void lbSelect_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("AdminResidentInsertUpdate.aspx?residentID=" + id);
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        bool result = ResidentManager.DeleteResident(Convert.ToInt32(linkButton.CommandArgument));
        showResidentGrid();
    }

    private void showResidentGrid()
    {
        string searchString = "Where " + (ddlStatus.SelectedValue == "All" ? "" : "AL_Resident.ExtraField10='"+ddlStatus.SelectedValue+"' and") + " AL_Resident.ExtraField1 in ('0" + (getLogin().ExtraField3 == "" ? "" : "','" + getLogin().ExtraField3.Replace(",", "','")) + "')";

        if (Request.QueryString["SearchKey"] != null && hfHasSearchDone.Value=="0")
        {
            hfHasSearchDone.Value = "1";
            searchString += " and AL_Resident.Address  like '%" + Request.QueryString["SearchKey"] + "%' or  AL_Resident.Name like '%" + Request.QueryString["SearchKey"] + "%' ";
        }
        searchString += " order by AL_Property.PropertyID, AL_Resident.Name";

        List<Resident> searchResult = new List<Resident>();
        searchResult = ResidentManager.SearchResidents(searchString);

        lblCount.Text = " ("+searchResult.Count.ToString()+") ";
        LinkPermissionChecking(searchResult);
        gvResident.DataSource = searchResult;
        gvResident.DataBind();
        LoadGridColor();
    }

    private void LinkPermissionChecking(List<Resident> searchResult)
    {
        bool li_ADLRecord = ButtonManager.GetAllButtonsByPageURLnUserIDnButtonName("li_ADLRecord", HttpContext.Current.Request.Url.AbsoluteUri, getLogin().LoginID.ToString());
        bool li_ComprehensiveAssessment = ButtonManager.GetAllButtonsByPageURLnUserIDnButtonName("li_ComprehensiveAssessment", HttpContext.Current.Request.Url.AbsoluteUri, getLogin().LoginID.ToString());
        bool li_ServiceCareAssessment = ButtonManager.GetAllButtonsByPageURLnUserIDnButtonName("li_ServiceCareAssessment", HttpContext.Current.Request.Url.AbsoluteUri, getLogin().LoginID.ToString());
        bool li_Medicaiton = ButtonManager.GetAllButtonsByPageURLnUserIDnButtonName("li_Medicaiton", HttpContext.Current.Request.Url.AbsoluteUri, getLogin().LoginID.ToString());
        bool li_ObservationLog = ButtonManager.GetAllButtonsByPageURLnUserIDnButtonName("li_ObservationLog", HttpContext.Current.Request.Url.AbsoluteUri, getLogin().LoginID.ToString());
        bool li_DoctorsOrder = ButtonManager.GetAllButtonsByPageURLnUserIDnButtonName("li_DoctorsOrder", HttpContext.Current.Request.Url.AbsoluteUri, getLogin().LoginID.ToString());

        foreach (Resident item in searchResult)
        {
            item.li_ADLRecord = li_ADLRecord;
            item.li_ComprehensiveAssessment = li_ComprehensiveAssessment;
            item.li_DoctorsOrder = li_DoctorsOrder;
            item.li_Medicaiton = li_Medicaiton;
            item.li_ObservationLog = li_ObservationLog;
            item.li_ServiceCareAssessment = li_ServiceCareAssessment;
        }
    }
    protected void ddlPropertyID_SelectedIndexChanged(object sender, EventArgs e)
    {
        string searchString = "Where 1=1 " + (ddlStatus.SelectedValue == "All" ? "" : "and AL_Resident.ExtraField10='" + ddlStatus.SelectedValue + "'");

        if (ddlPropertyID.SelectedIndex!=0)
        {
            searchString += " And AL_Resident.ExtraField1 = " + ddlPropertyID.SelectedValue;
        }
        searchString += " order by AL_Property.PropertyID, AL_Resident.Name";

        List<Resident> searchResult = new List<Resident>();
        searchResult = ResidentManager.SearchResidents(searchString);

        lblCount.Text = " (" + searchResult.Count.ToString() + ") ";
        LinkPermissionChecking(searchResult);
        gvResident.DataSource = searchResult;
        gvResident.DataBind();
        LoadGridColor();
    }

    private void LoadGridColor()
    {
        bool lightGray = false;
        string lastProperty = "";
        foreach (GridViewRow item in gvResident.Rows)
	    {
            Label lblProperty = (Label)item.FindControl("lblProperty");
            if (lastProperty == "")
            {
                lastProperty = lblProperty.Text;
            }
            else 
            {
                if (lblProperty.Text != lastProperty)
                {
                    lastProperty = lblProperty.Text;
                    lightGray = !lightGray;
                }
            }

            if (lightGray)
            {
                item.BackColor = System.Drawing.Color.LightGray;
            }
            else
            {
                item.BackColor = System.Drawing.Color.White;
            }
	    }
    }
}
