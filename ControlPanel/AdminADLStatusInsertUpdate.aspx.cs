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

public partial class AdminADLStatusInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["aDLStatusID"] != null)
            {
                int aDLStatusID = Int32.Parse(Request.QueryString["aDLStatusID"]);
                if (aDLStatusID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showADLStatusData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ADLStatus aDLStatus = new ADLStatus();

        aDLStatus.ADLStatusName = txtADLStatusName.Text;
        int resutl = ADLStatusManager.InsertADLStatus(aDLStatus);
        Response.Redirect("AdminADLStatusDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        ADLStatus aDLStatus = new ADLStatus();
        aDLStatus = ADLStatusManager.GetADLStatusByID(Int32.Parse(Request.QueryString["aDLStatusID"]));
        ADLStatus tempADLStatus = new ADLStatus();
        tempADLStatus.ADLStatusID = aDLStatus.ADLStatusID;

        tempADLStatus.ADLStatusName = txtADLStatusName.Text;
        bool result = ADLStatusManager.UpdateADLStatus(tempADLStatus);
        Response.Redirect("AdminADLStatusDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtADLStatusName.Text = "";
    }
    private void showADLStatusData()
    {
        ADLStatus aDLStatus = new ADLStatus();
        aDLStatus = ADLStatusManager.GetADLStatusByID(Int32.Parse(Request.QueryString["aDLStatusID"]));

        txtADLStatusName.Text = aDLStatus.ADLStatusName;
    }
}
