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

public partial class AdminADLHeaderDetailStatusInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["aDLHeaderDetailStatusID"] != null)
            {
                int aDLHeaderDetailStatusID = Int32.Parse(Request.QueryString["aDLHeaderDetailStatusID"]);
                if (aDLHeaderDetailStatusID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showADLHeaderDetailStatusData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ADLHeaderDetailStatus aDLHeaderDetailStatus = new ADLHeaderDetailStatus();

        aDLHeaderDetailStatus.ADLHeaderDetailStatusName = txtADLHeaderDetailStatusName.Text;
        int resutl = ADLHeaderDetailStatusManager.InsertADLHeaderDetailStatus(aDLHeaderDetailStatus);
        Response.Redirect("AdminADLHeaderDetailStatusDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        ADLHeaderDetailStatus aDLHeaderDetailStatus = new ADLHeaderDetailStatus();
        aDLHeaderDetailStatus = ADLHeaderDetailStatusManager.GetADLHeaderDetailStatusByID(Int32.Parse(Request.QueryString["aDLHeaderDetailStatusID"]));
        ADLHeaderDetailStatus tempADLHeaderDetailStatus = new ADLHeaderDetailStatus();
        tempADLHeaderDetailStatus.ADLHeaderDetailStatusID = aDLHeaderDetailStatus.ADLHeaderDetailStatusID;

        tempADLHeaderDetailStatus.ADLHeaderDetailStatusName = txtADLHeaderDetailStatusName.Text;
        bool result = ADLHeaderDetailStatusManager.UpdateADLHeaderDetailStatus(tempADLHeaderDetailStatus);
        Response.Redirect("AdminADLHeaderDetailStatusDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtADLHeaderDetailStatusName.Text = "";
    }
    private void showADLHeaderDetailStatusData()
    {
        ADLHeaderDetailStatus aDLHeaderDetailStatus = new ADLHeaderDetailStatus();
        aDLHeaderDetailStatus = ADLHeaderDetailStatusManager.GetADLHeaderDetailStatusByID(Int32.Parse(Request.QueryString["aDLHeaderDetailStatusID"]));

        txtADLHeaderDetailStatusName.Text = aDLHeaderDetailStatus.ADLHeaderDetailStatusName;
    }
}
