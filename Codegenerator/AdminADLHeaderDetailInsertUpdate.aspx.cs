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

public partial class AdminADLHeaderDetailInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadADLDetail();
            loadADLHeader();
            loadResident();
            if (Request.QueryString["aDLHeaderDetailID"] != null)
            {
                int aDLHeaderDetailID = Int32.Parse(Request.QueryString["aDLHeaderDetailID"]);
                if (aDLHeaderDetailID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showADLHeaderDetailData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ADLHeaderDetail aDLHeaderDetail = new ADLHeaderDetail();

        aDLHeaderDetail.ADLDetailID = Int32.Parse(ddlADLDetail.SelectedValue);
        aDLHeaderDetail.ADLHeaderID = Int32.Parse(ddlADLHeader.SelectedValue);
        aDLHeaderDetail.ResidentID = Int32.Parse(ddlResident.SelectedValue);
        aDLHeaderDetail.ExtraField1 = txtExtraField1.Text;
        aDLHeaderDetail.ExtraField2 = txtExtraField2.Text;
        aDLHeaderDetail.ExtraField3 = txtExtraField3.Text;
        aDLHeaderDetail.ExtraField4 = txtExtraField4.Text;
        aDLHeaderDetail.ExtraField5 = txtExtraField5.Text;
        int resutl = ADLHeaderDetailManager.InsertADLHeaderDetail(aDLHeaderDetail);
        Response.Redirect("AdminADLHeaderDetailDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        ADLHeaderDetail aDLHeaderDetail = new ADLHeaderDetail();
        aDLHeaderDetail = ADLHeaderDetailManager.GetADLHeaderDetailByID(Int32.Parse(Request.QueryString["aDLHeaderDetailID"]));
        ADLHeaderDetail tempADLHeaderDetail = new ADLHeaderDetail();
        tempADLHeaderDetail.ADLHeaderDetailID = aDLHeaderDetail.ADLHeaderDetailID;

        tempADLHeaderDetail.ADLDetailID = Int32.Parse(ddlADLDetail.SelectedValue);
        tempADLHeaderDetail.ADLHeaderID = Int32.Parse(ddlADLHeader.SelectedValue);
        tempADLHeaderDetail.ResidentID = Int32.Parse(ddlResident.SelectedValue);
        tempADLHeaderDetail.ExtraField1 = txtExtraField1.Text;
        tempADLHeaderDetail.ExtraField2 = txtExtraField2.Text;
        tempADLHeaderDetail.ExtraField3 = txtExtraField3.Text;
        tempADLHeaderDetail.ExtraField4 = txtExtraField4.Text;
        tempADLHeaderDetail.ExtraField5 = txtExtraField5.Text;
        bool result = ADLHeaderDetailManager.UpdateADLHeaderDetail(tempADLHeaderDetail);
        Response.Redirect("AdminADLHeaderDetailDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlADLDetail.SelectedIndex = 0;
        ddlADLHeader.SelectedIndex = 0;
        ddlResident.SelectedIndex = 0;
        txtExtraField1.Text = "";
        txtExtraField2.Text = "";
        txtExtraField3.Text = "";
        txtExtraField4.Text = "";
        txtExtraField5.Text = "";
    }
    private void showADLHeaderDetailData()
    {
        ADLHeaderDetail aDLHeaderDetail = new ADLHeaderDetail();
        aDLHeaderDetail = ADLHeaderDetailManager.GetADLHeaderDetailByID(Int32.Parse(Request.QueryString["aDLHeaderDetailID"]));

        ddlADLDetail.SelectedValue = aDLHeaderDetail.ADLDetailID.ToString();
        ddlADLHeader.SelectedValue = aDLHeaderDetail.ADLHeaderID.ToString();
        ddlResident.SelectedValue = aDLHeaderDetail.ResidentID.ToString();
        txtExtraField1.Text = aDLHeaderDetail.ExtraField1;
        txtExtraField2.Text = aDLHeaderDetail.ExtraField2;
        txtExtraField3.Text = aDLHeaderDetail.ExtraField3;
        txtExtraField4.Text = aDLHeaderDetail.ExtraField4;
        txtExtraField5.Text = aDLHeaderDetail.ExtraField5;
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
    private void loadADLHeader()
    {
        ListItem li = new ListItem("Select ADLHeader...", "0");
        ddlADLHeader.Items.Add(li);

        List<ADLHeader> aDLHeaders = new List<ADLHeader>();
        aDLHeaders = ADLHeaderManager.GetAllADLHeaders();
        foreach (ADLHeader aDLHeader in aDLHeaders)
        {
            ListItem item = new ListItem(aDLHeader.ADLHeaderName.ToString(), aDLHeader.ADLHeaderID.ToString());
            ddlADLHeader.Items.Add(item);
        }
    }
    private void loadResident()
    {
        ListItem li = new ListItem("Select Resident...", "0");
        ddlResident.Items.Add(li);

        List<Resident> residents = new List<Resident>();
        residents = ResidentManager.GetAllResidents();
        foreach (Resident resident in residents)
        {
            ListItem item = new ListItem(resident.ResidentName.ToString(), resident.ResidentID.ToString());
            ddlResident.Items.Add(item);
        }
    }
}
