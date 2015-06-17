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

public partial class AdminADLHeaderDetailnDateTimeInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadADLDateTime();
            loadADLHeaderDetail();
            loadADLHeaderDetail();
            if (Request.QueryString["aDLHeaderDetailnDateTimeID"] != null)
            {
                int aDLHeaderDetailnDateTimeID = Int32.Parse(Request.QueryString["aDLHeaderDetailnDateTimeID"]);
                if (aDLHeaderDetailnDateTimeID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showADLHeaderDetailnDateTimeData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ADLHeaderDetailnDateTime aDLHeaderDetailnDateTime = new ADLHeaderDetailnDateTime();

        aDLHeaderDetailnDateTime.ADLDateTimeID = Int32.Parse(ddlADLDateTime.SelectedValue);
        aDLHeaderDetailnDateTime.ADLHeaderDetailID = Int32.Parse(ddlADLHeaderDetail.SelectedValue);
        aDLHeaderDetailnDateTime.ADLHeaderDetailID = Int32.Parse(ddlADLHeaderDetail.SelectedValue);
        aDLHeaderDetailnDateTime.ExtraField1 = txtExtraField1.Text;
        aDLHeaderDetailnDateTime.ExtraField2 = txtExtraField2.Text;
        aDLHeaderDetailnDateTime.ExtraField3 = txtExtraField3.Text;
        aDLHeaderDetailnDateTime.ExtraField4 = txtExtraField4.Text;
        aDLHeaderDetailnDateTime.ExtraField5 = txtExtraField5.Text;
        int resutl = ADLHeaderDetailnDateTimeManager.InsertADLHeaderDetailnDateTime(aDLHeaderDetailnDateTime);
        Response.Redirect("AdminADLHeaderDetailnDateTimeDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        ADLHeaderDetailnDateTime aDLHeaderDetailnDateTime = new ADLHeaderDetailnDateTime();
        aDLHeaderDetailnDateTime = ADLHeaderDetailnDateTimeManager.GetADLHeaderDetailnDateTimeByID(Int32.Parse(Request.QueryString["aDLHeaderDetailnDateTimeID"]));
        ADLHeaderDetailnDateTime tempADLHeaderDetailnDateTime = new ADLHeaderDetailnDateTime();
        tempADLHeaderDetailnDateTime.ADLHeaderDetailnDateTimeID = aDLHeaderDetailnDateTime.ADLHeaderDetailnDateTimeID;

        tempADLHeaderDetailnDateTime.ADLDateTimeID = Int32.Parse(ddlADLDateTime.SelectedValue);
        tempADLHeaderDetailnDateTime.ADLHeaderDetailID = Int32.Parse(ddlADLHeaderDetail.SelectedValue);
        tempADLHeaderDetailnDateTime.ADLHeaderDetailID = Int32.Parse(ddlADLHeaderDetail.SelectedValue);
        tempADLHeaderDetailnDateTime.ExtraField1 = txtExtraField1.Text;
        tempADLHeaderDetailnDateTime.ExtraField2 = txtExtraField2.Text;
        tempADLHeaderDetailnDateTime.ExtraField3 = txtExtraField3.Text;
        tempADLHeaderDetailnDateTime.ExtraField4 = txtExtraField4.Text;
        tempADLHeaderDetailnDateTime.ExtraField5 = txtExtraField5.Text;
        bool result = ADLHeaderDetailnDateTimeManager.UpdateADLHeaderDetailnDateTime(tempADLHeaderDetailnDateTime);
        Response.Redirect("AdminADLHeaderDetailnDateTimeDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlADLDateTime.SelectedIndex = 0;
        ddlADLHeaderDetail.SelectedIndex = 0;
        ddlADLHeaderDetail.SelectedIndex = 0;
        txtExtraField1.Text = "";
        txtExtraField2.Text = "";
        txtExtraField3.Text = "";
        txtExtraField4.Text = "";
        txtExtraField5.Text = "";
    }
    private void showADLHeaderDetailnDateTimeData()
    {
        ADLHeaderDetailnDateTime aDLHeaderDetailnDateTime = new ADLHeaderDetailnDateTime();
        aDLHeaderDetailnDateTime = ADLHeaderDetailnDateTimeManager.GetADLHeaderDetailnDateTimeByID(Int32.Parse(Request.QueryString["aDLHeaderDetailnDateTimeID"]));

        ddlADLDateTime.SelectedValue = aDLHeaderDetailnDateTime.ADLDateTimeID.ToString();
        ddlADLHeaderDetail.SelectedValue = aDLHeaderDetailnDateTime.ADLHeaderDetailID.ToString();
        ddlADLHeaderDetail.SelectedValue = aDLHeaderDetailnDateTime.ADLHeaderDetailID.ToString();
        txtExtraField1.Text = aDLHeaderDetailnDateTime.ExtraField1;
        txtExtraField2.Text = aDLHeaderDetailnDateTime.ExtraField2;
        txtExtraField3.Text = aDLHeaderDetailnDateTime.ExtraField3;
        txtExtraField4.Text = aDLHeaderDetailnDateTime.ExtraField4;
        txtExtraField5.Text = aDLHeaderDetailnDateTime.ExtraField5;
    }
    private void loadADLDateTime()
    {
        ListItem li = new ListItem("Select ADLDateTime...", "0");
        ddlADLDateTime.Items.Add(li);

        List<ADLDateTime> aDLDateTimes = new List<ADLDateTime>();
        aDLDateTimes = ADLDateTimeManager.GetAllADLDateTimes();
        foreach (ADLDateTime aDLDateTime in aDLDateTimes)
        {
            ListItem item = new ListItem(aDLDateTime.ADLDateTimeName.ToString(), aDLDateTime.ADLDateTimeID.ToString());
            ddlADLDateTime.Items.Add(item);
        }
    }
    private void loadADLHeaderDetail()
    {
        ListItem li = new ListItem("Select ADLHeaderDetail...", "0");
        ddlADLHeaderDetail.Items.Add(li);

        List<ADLHeaderDetail> aDLHeaderDetails = new List<ADLHeaderDetail>();
        aDLHeaderDetails = ADLHeaderDetailManager.GetAllADLHeaderDetails();
        foreach (ADLHeaderDetail aDLHeaderDetail in aDLHeaderDetails)
        {
            ListItem item = new ListItem(aDLHeaderDetail.ADLHeaderDetailName.ToString(), aDLHeaderDetail.ADLHeaderDetailID.ToString());
            ddlADLHeaderDetail.Items.Add(item);
        }
    }
    private void loadADLHeaderDetail()
    {
        ListItem li = new ListItem("Select ADLHeaderDetail...", "0");
        ddlADLHeaderDetail.Items.Add(li);

        List<ADLHeaderDetail> aDLHeaderDetails = new List<ADLHeaderDetail>();
        aDLHeaderDetails = ADLHeaderDetailManager.GetAllADLHeaderDetails();
        foreach (ADLHeaderDetail aDLHeaderDetail in aDLHeaderDetails)
        {
            ListItem item = new ListItem(aDLHeaderDetail.ADLHeaderDetailName.ToString(), aDLHeaderDetail.ADLHeaderDetailID.ToString());
            ddlADLHeaderDetail.Items.Add(item);
        }
    }
}
