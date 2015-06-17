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

public partial class AdminADLDetailnStatusInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadADLDetail();
            loadADLStatus();
            if (Request.QueryString["aDLDetailnStatusID"] != null)
            {
                int aDLDetailnStatusID = Int32.Parse(Request.QueryString["aDLDetailnStatusID"]);
                if (aDLDetailnStatusID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showADLDetailnStatusData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ADLDetailnStatus aDLDetailnStatus = new ADLDetailnStatus();

        aDLDetailnStatus.ADLDetailID = Int32.Parse(ddlADLDetail.SelectedValue);
        aDLDetailnStatus.ADLStatusID = Int32.Parse(ddlADLStatus.SelectedValue);
        int resutl = ADLDetailnStatusManager.InsertADLDetailnStatus(aDLDetailnStatus);
        Response.Redirect("AdminADLDetailnStatusDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        ADLDetailnStatus aDLDetailnStatus = new ADLDetailnStatus();
        aDLDetailnStatus = ADLDetailnStatusManager.GetADLDetailnStatusByID(Int32.Parse(Request.QueryString["aDLDetailnStatusID"]));
        ADLDetailnStatus tempADLDetailnStatus = new ADLDetailnStatus();
        tempADLDetailnStatus.ADLDetailnStatusID = aDLDetailnStatus.ADLDetailnStatusID;

        tempADLDetailnStatus.ADLDetailID = Int32.Parse(ddlADLDetail.SelectedValue);
        tempADLDetailnStatus.ADLStatusID = Int32.Parse(ddlADLStatus.SelectedValue);
        bool result = ADLDetailnStatusManager.UpdateADLDetailnStatus(tempADLDetailnStatus);
        Response.Redirect("AdminADLDetailnStatusDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlADLDetail.SelectedIndex = 0;
        ddlADLStatus.SelectedIndex = 0;
    }
    private void showADLDetailnStatusData()
    {
        ADLDetailnStatus aDLDetailnStatus = new ADLDetailnStatus();
        aDLDetailnStatus = ADLDetailnStatusManager.GetADLDetailnStatusByID(Int32.Parse(Request.QueryString["aDLDetailnStatusID"]));

        ddlADLDetail.SelectedValue = aDLDetailnStatus.ADLDetailID.ToString();
        ddlADLStatus.SelectedValue = aDLDetailnStatus.ADLStatusID.ToString();
    }
    private void loadADLDetail()
    {
        ListItem li = new ListItem("Select ADLDetail...", "0");
        ddlADLDetail.Items.Add(li);

        List<ADLDetail> aDLDetails = new List<ADLDetail>();
        aDLDetails = ADLDetailManager.GetAllADLDetails();
        foreach (ADLDetail aDLDetail in aDLDetails)
        {
            ListItem item = new ListItem(aDLDetail.ADLDetailName.ToString(), aDLDetail.ADLDetailID.ToString());
            ddlADLDetail.Items.Add(item);
        }
    }
    private void loadADLStatus()
    {
        ListItem li = new ListItem("Select ADLStatus...", "0");
        ddlADLStatus.Items.Add(li);

        List<ADLStatus> aDLStatuss = new List<ADLStatus>();
        aDLStatuss = ADLStatusManager.GetAllADLStatuss();
        foreach (ADLStatus aDLStatus in aDLStatuss)
        {
            ListItem item = new ListItem(aDLStatus.ADLStatusName.ToString(), aDLStatus.ADLStatusID.ToString());
            ddlADLStatus.Items.Add(item);
        }
    }
}
