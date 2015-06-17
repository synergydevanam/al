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

public partial class AdminADLItemInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadADLItemDescription();
            loadADLStatus();
            loadResident();
            if (Request.QueryString["aDLItemID"] != null)
            {
                int aDLItemID = Int32.Parse(Request.QueryString["aDLItemID"]);
                if (aDLItemID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showADLItemData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ADLItem aDLItem = new ADLItem();

        aDLItem.ADLItemName = txtADLItemName.Text;
        aDLItem.ADLItemDescriptionID = Int32.Parse(ddlADLItemDescription.SelectedValue);
        aDLItem.ADLStatusID = Int32.Parse(ddlADLStatus.SelectedValue);
        aDLItem.ResidentID = Int32.Parse(ddlResident.SelectedValue);
        aDLItem.IteamTime = txtIteamTime.Text;
        aDLItem.Comment = txtComment.Text;
        aDLItem.ExtraField1 = txtExtraField1.Text;
        aDLItem.ExtraField2 = txtExtraField2.Text;
        aDLItem.ExtraField3 = txtExtraField3.Text;
        aDLItem.ExtraField4 = txtExtraField4.Text;
        aDLItem.ExtraField5 = txtExtraField5.Text;
        aDLItem.ExtraField6 = txtExtraField6.Text;
        aDLItem.ExtraField7 = txtExtraField7.Text;
        aDLItem.ExtraField8 = txtExtraField8.Text;
        aDLItem.ExtraField9 = txtExtraField9.Text;
        aDLItem.ExtraField10 = txtExtraField10.Text;
        int resutl = ADLItemManager.InsertADLItem(aDLItem);
        Response.Redirect("AdminADLItemDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        ADLItem aDLItem = new ADLItem();
        aDLItem = ADLItemManager.GetADLItemByID(Int32.Parse(Request.QueryString["aDLItemID"]));
        ADLItem tempADLItem = new ADLItem();
        tempADLItem.ADLItemID = aDLItem.ADLItemID;

        tempADLItem.ADLItemName = txtADLItemName.Text;
        tempADLItem.ADLItemDescriptionID = Int32.Parse(ddlADLItemDescription.SelectedValue);
        tempADLItem.ADLStatusID = Int32.Parse(ddlADLStatus.SelectedValue);
        tempADLItem.ResidentID = Int32.Parse(ddlResident.SelectedValue);
        tempADLItem.IteamTime = txtIteamTime.Text;
        tempADLItem.Comment = txtComment.Text;
        tempADLItem.ExtraField1 = txtExtraField1.Text;
        tempADLItem.ExtraField2 = txtExtraField2.Text;
        tempADLItem.ExtraField3 = txtExtraField3.Text;
        tempADLItem.ExtraField4 = txtExtraField4.Text;
        tempADLItem.ExtraField5 = txtExtraField5.Text;
        tempADLItem.ExtraField6 = txtExtraField6.Text;
        tempADLItem.ExtraField7 = txtExtraField7.Text;
        tempADLItem.ExtraField8 = txtExtraField8.Text;
        tempADLItem.ExtraField9 = txtExtraField9.Text;
        tempADLItem.ExtraField10 = txtExtraField10.Text;
        bool result = ADLItemManager.UpdateADLItem(tempADLItem);
        Response.Redirect("AdminADLItemDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtADLItemName.Text = "";
        ddlADLItemDescription.SelectedIndex = 0;
        ddlADLStatus.SelectedIndex = 0;
        ddlResident.SelectedIndex = 0;
        txtIteamTime.Text = "";
        txtComment.Text = "";
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
    private void showADLItemData()
    {
        ADLItem aDLItem = new ADLItem();
        aDLItem = ADLItemManager.GetADLItemByID(Int32.Parse(Request.QueryString["aDLItemID"]));

        txtADLItemName.Text = aDLItem.ADLItemName;
        ddlADLItemDescription.SelectedValue = aDLItem.ADLItemDescriptionID.ToString();
        ddlADLStatus.SelectedValue = aDLItem.ADLStatusID.ToString();
        ddlResident.SelectedValue = aDLItem.ResidentID.ToString();
        txtIteamTime.Text = aDLItem.IteamTime;
        txtComment.Text = aDLItem.Comment;
        txtExtraField1.Text = aDLItem.ExtraField1;
        txtExtraField2.Text = aDLItem.ExtraField2;
        txtExtraField3.Text = aDLItem.ExtraField3;
        txtExtraField4.Text = aDLItem.ExtraField4;
        txtExtraField5.Text = aDLItem.ExtraField5;
        txtExtraField6.Text = aDLItem.ExtraField6;
        txtExtraField7.Text = aDLItem.ExtraField7;
        txtExtraField8.Text = aDLItem.ExtraField8;
        txtExtraField9.Text = aDLItem.ExtraField9;
        txtExtraField10.Text = aDLItem.ExtraField10;
    }
    private void loadADLItemDescription()
    {
        ListItem li = new ListItem("Select ADLItemDescription...", "0");
        ddlADLItemDescription.Items.Add(li);

        List<ADLItemDescription> aDLItemDescriptions = new List<ADLItemDescription>();
        aDLItemDescriptions = ADLItemDescriptionManager.GetAllADLItemDescriptions();
        foreach (ADLItemDescription aDLItemDescription in aDLItemDescriptions)
        {
            ListItem item = new ListItem(aDLItemDescription.ADLItemDescriptionName.ToString(), aDLItemDescription.ADLItemDescriptionID.ToString());
            ddlADLItemDescription.Items.Add(item);
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
    private void loadResident()
    {
        ListItem li = new ListItem("Select Resident...", "0");
        ddlResident.Items.Add(li);

        List<Resident> residents = new List<Resident>();
        residents = ResidentManager.GetAllResidents();
        foreach (Resident resident in residents)
        {
            ListItem item = new ListItem(resident.Name.ToString(), resident.ResidentID.ToString());
            ddlResident.Items.Add(item);
        }
    }
}
