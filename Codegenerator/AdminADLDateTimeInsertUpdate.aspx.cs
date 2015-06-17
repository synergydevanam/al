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

public partial class AdminADLDateTimeInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["aDLDateTimeID"] != null)
            {
                int aDLDateTimeID = Int32.Parse(Request.QueryString["aDLDateTimeID"]);
                if (aDLDateTimeID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showADLDateTimeData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ADLDateTime aDLDateTime = new ADLDateTime();

        aDLDateTime.ADLDateTime = txtADLDateTime.Text;
        int resutl = ADLDateTimeManager.InsertADLDateTime(aDLDateTime);
        Response.Redirect("AdminADLDateTimeDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        ADLDateTime aDLDateTime = new ADLDateTime();
        aDLDateTime = ADLDateTimeManager.GetADLDateTimeByID(Int32.Parse(Request.QueryString["aDLDateTimeID"]));
        ADLDateTime tempADLDateTime = new ADLDateTime();
        tempADLDateTime.ADLDateTimeID = aDLDateTime.ADLDateTimeID;

        tempADLDateTime.ADLDateTime = txtADLDateTime.Text;
        bool result = ADLDateTimeManager.UpdateADLDateTime(tempADLDateTime);
        Response.Redirect("AdminADLDateTimeDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtADLDateTime.Text = "";
    }
    private void showADLDateTimeData()
    {
        ADLDateTime aDLDateTime = new ADLDateTime();
        aDLDateTime = ADLDateTimeManager.GetADLDateTimeByID(Int32.Parse(Request.QueryString["aDLDateTimeID"]));

        txtADLDateTime.Text = aDLDateTime.ADLDateTime;
    }
}
