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
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        foreach (DataListItem item in dlStatus.Items)
        {
            CheckBox chkSelect = (CheckBox)item.FindControl("chkSelect");
            if (chkSelect.Checked && chkSelect.ToolTip == "0") //newly selected
            {
                ADLDetailnStatus aDLDetailnStatus = new ADLDetailnStatus();

                aDLDetailnStatus.ADLDetailID = Int32.Parse(ddlADLDetail.SelectedValue);
                aDLDetailnStatus.ADLStatusID = Int32.Parse(chkSelect.ValidationGroup);
                int resutl = ADLDetailnStatusManager.InsertADLDetailnStatus(aDLDetailnStatus);
            }
            else
                if (!chkSelect.Checked && chkSelect.ToolTip != "0") //Need to delete
                {
                    ADLDetailnStatusManager.DeleteADLDetailnStatus(int.Parse(chkSelect.ToolTip));
                }
            
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlADLDetail.SelectedIndex = 0;
        ddlADLDetail_SelectedIndexChanged(this, new EventArgs());
    }
    private void showADLDetailnStatusData()
    {
        List<ADLDetailnStatus> aDLDetailnStatus = new List<ADLDetailnStatus>();
        aDLDetailnStatus = ADLDetailnStatusManager.GetAllADLDetailnStatussByADLDetailID(int.Parse(ddlADLDetail.SelectedValue));

        foreach (DataListItem item in dlStatus.Items)
        {
            CheckBox chkSelect = (CheckBox)item.FindControl("chkSelect");
            chkSelect.ToolTip = "0";
            chkSelect.Checked = false;
        }

        foreach (DataListItem item in dlStatus.Items)
        {
            CheckBox chkSelect = (CheckBox)item.FindControl("chkSelect");
            foreach (ADLDetailnStatus detailnStatus in aDLDetailnStatus)
            {
                if (chkSelect.ValidationGroup == detailnStatus.ADLStatusID.ToString())
                {
                    chkSelect.Checked = true;
                    chkSelect.ToolTip = detailnStatus.ADLDetailnStatusID.ToString();
                }
            }
        }
    }
    private void loadADLDetail()
    {
        ListItem li = new ListItem("Select >>", "0");
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
        List<ADLStatus> aDLStatuss = new List<ADLStatus>();
        aDLStatuss = ADLStatusManager.GetAllADLStatuss();
        dlStatus.DataSource = aDLStatuss;
        dlStatus.DataBind();
    }
    protected void ddlADLDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        showADLDetailnStatusData();
    }
}
