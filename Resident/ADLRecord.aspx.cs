using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Resident_ADLRecord : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadDataInitially();
        }
    }

    private void loadDataInitially()
    {
        loadADLDetail();
        loadADLHeader();
        loadADLDetailStatus();
        if (Request.QueryString["ResidentID"] != null)
        {
            a_Report.HRef = "ADLRecord_MonthlyPrint.aspx?Title=Monthly ADL Report&ResidentID=" + Request.QueryString["ResidentID"];
                
            laodResitentInfo();
            loadMedicineTimenDateDate();
        }

        loadGrid();
    }

    private void loadADLDetail()
    {
        List<ADLDetail> aDLDetails = new List<ADLDetail>();
        aDLDetails = ADLDetailManager.GetAllADLDetails();
        dlADLDetail.DataSource = aDLDetails;
        dlADLDetail.DataBind();
    }
    private void loadADLHeader()
    {
        ListItem li = new ListItem("Select >>", "0");
        ddlADLHeader.Items.Add(li);

        List<ADLHeader> aDLHeaders = new List<ADLHeader>();
        aDLHeaders = ADLHeaderManager.GetAllADLHeaders();
        foreach (ADLHeader aDLHeader in aDLHeaders)
        {
            ListItem item = new ListItem(aDLHeader.ADLHeaderName.ToString(), aDLHeader.ADLHeaderID.ToString());
            ddlADLHeader.Items.Add(item);
        }
    }
    private void loadADLDetailStatus()
    {
        ddlADLStatus.Items.Clear();
        ListItem li = new ListItem("New Status", "0");
        ddlADLStatus.Items.Add(li);

        List<ADLDetailnStatus> aDLDetailStatuss = new List<ADLDetailnStatus>();
        aDLDetailStatuss = ADLDetailnStatusManager.GetAllADLDetailnStatuss();
        foreach (ADLDetailnStatus aDLDetailStatus in aDLDetailStatuss)
        {
            ListItem item = new ListItem(aDLDetailStatus.ADLStatusName.ToString(), aDLDetailStatus.ADLDetailID.ToString());
            ddlADLStatus.Items.Add(item);
            rbtnlADLStatus.Items.Add(item);
        }
    }


    

    private void loadMedicineTimenDateDate()
    {
        ddlExistingRecord.Items.Clear();

        ListItem li = new ListItem("New Record", "0");
        ddlExistingRecord.Items.Add(li);

        DataSet ds =  ADLHeaderDetailnDateTimeManager.GetAllADLHeaderDetailnDateTimeByResidentID(int.Parse(Request.QueryString["ResidentID"]));
        foreach (DataRow assessmentnCareDate in ds.Tables[0].Rows)
        {
            ListItem item = new ListItem(DateTime.Parse(assessmentnCareDate["ADLDateTime"].ToString()).ToString("yyyy-MM-dd hh:mm tt"), assessmentnCareDate["ADLDateTimeID"].ToString());
            ddlExistingRecord.Items.Add(item);
        }

        ddlExistingRecord_SelectedIndexChanged(this, new EventArgs());
    }

    private void laodResitentInfo()
    {
        try
        {
            
        }
        catch (Exception ex)
        { }
    }

    private void loadGrid()
    {
        showHeaderDetailByResidentID();
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        lblMsg.Visible = true;
        int ADLDateTimeID = 0;
        if (ddlExistingRecord.SelectedValue == "0")
        {
            ADLDateTime aDLDateTime = new ADLDateTime();

            aDLDateTime.ADLDateTimeValue = DateTime.Now;
            ADLDateTimeID = ADLDateTimeManager.InsertADLDateTime(aDLDateTime);
        }
        else
        {
            ADLDateTimeID = int.Parse(ddlExistingRecord.SelectedValue);
            ADLHeaderDetailnDateTimeManager.DeleteADLHeaderDetailnDateTimeByADLDateTimeID(ADLDateTimeID);
        }

        foreach (GridViewRow gvr in gvHeader.Rows)
        {
            HiddenField hfADLHeaderID = (HiddenField)gvr.FindControl("hfADLHeaderID");
            GridView gvDetail = (GridView)gvr.FindControl("gvDetail");

            foreach (GridViewRow gvrDetail in gvDetail.Rows)
            {
                HiddenField hfADLHeaderDetialID = (HiddenField)gvrDetail.FindControl("hfADLHeaderDetialID");
                TextBox txtNewStatus = (TextBox)gvrDetail.FindControl("txtNewStatus");
                TextBox txtRemark = (TextBox)gvrDetail.FindControl("txtRemark");
                DropDownList ddlADLStatusInGrid = (DropDownList)gvrDetail.FindControl("ddlADLStatusInGrid");
                RadioButtonList rbtnlADLStatusInGrid = (RadioButtonList)gvrDetail.FindControl("rbtnlADLStatusInGrid");

                //if (txtNewStatus.Text != "" || ddlADLStatusInGrid.SelectedValue != "0")
                try
                {
                    ADLHeaderDetailnDateTime aDLHeaderDetailnDateTime = new ADLHeaderDetailnDateTime();

                    aDLHeaderDetailnDateTime.ADLDateTimeID = ADLDateTimeID;
                    aDLHeaderDetailnDateTime.ADLHeaderDetailID = Int32.Parse(hfADLHeaderDetialID.Value);
                    aDLHeaderDetailnDateTime.ExtraField1 = (txtNewStatus.Text == "" ? rbtnlADLStatusInGrid.SelectedValue : txtNewStatus.Text);
                    aDLHeaderDetailnDateTime.ExtraField2 = getLogin().ExtraField4;
                    aDLHeaderDetailnDateTime.ExtraField3 = txtRemark.Text;
                    aDLHeaderDetailnDateTime.ExtraField4 = getLogin().LoginID.ToString();
                    aDLHeaderDetailnDateTime.ExtraField5 = "";
                    int resutl = ADLHeaderDetailnDateTimeManager.InsertADLHeaderDetailnDateTime(aDLHeaderDetailnDateTime);
                }
                catch (Exception ex)
                { }
            }
        }

        
        loadMedicineTimenDateDate();

        foreach (GridViewRow gvr in gvHeader.Rows)
        {
            HiddenField hfADLHeaderID = (HiddenField)gvr.FindControl("hfADLHeaderID");
            GridView gvDetail = (GridView)gvr.FindControl("gvDetail");

            foreach (GridViewRow gvrDetail in gvDetail.Rows)
            {
                HiddenField hfADLHeaderDetialID = (HiddenField)gvrDetail.FindControl("hfADLHeaderDetialID");
                TextBox txtNewStatus = (TextBox)gvrDetail.FindControl("txtNewStatus");
                TextBox txtRemark = (TextBox)gvrDetail.FindControl("txtRemark");
                DropDownList ddlADLStatusInGrid = (DropDownList)gvrDetail.FindControl("ddlADLStatusInGrid");
                RadioButtonList rbtnlADLStatusInGrid = (RadioButtonList)gvrDetail.FindControl("rbtnlADLStatusInGrid");
                txtRemark.Text = "";
                rbtnlADLStatusInGrid.SelectedIndex = -1;
            }
        }
    }

    private string getChiledIds()
    {
       return "";
    }

    private string getCommentsByParentIDs()
    {
        string CommentsByParentIDs = "";
        
        return CommentsByParentIDs;
    }
    protected void ddlExistingRecord_SelectedIndexChanged(object sender, EventArgs e)
    {
        showHeaderDetailByResidentID();
        loadSelectData();
        if (ddlExistingRecord.SelectedIndex != 0)
        {
            btnSave.Visible = ButtonManager.GetAllButtonsByPageURLnUserIDnButtonName("btnSave", HttpContext.Current.Request.Url.AbsoluteUri, getLogin().LoginID.ToString());
        }
        else
        {
            btnSave.Visible = true;
        }
    }

    private void loadSelectData()
    {
        if (ddlExistingRecord.SelectedIndex != 0)
        {
            DataSet ds = ADLHeaderDetailnDateTimeManager.GetAllADLHeaderDetailnDateTimeByADLDateTimeID(int.Parse(ddlExistingRecord.SelectedValue));
            foreach (GridViewRow gvr in gvHeader.Rows)
            {
                HiddenField hfADLHeaderID = (HiddenField)gvr.FindControl("hfADLHeaderID");
                GridView gvDetail = (GridView)gvr.FindControl("gvDetail");

                foreach (GridViewRow gvrDetail in gvDetail.Rows)
                {
                    HiddenField hfADLHeaderDetialID = (HiddenField)gvrDetail.FindControl("hfADLHeaderDetialID");
                    TextBox txtNewStatus = (TextBox)gvrDetail.FindControl("txtNewStatus");
                    TextBox txtRemark = (TextBox)gvrDetail.FindControl("txtRemark");
                    DropDownList ddlADLStatusInGrid = (DropDownList)gvrDetail.FindControl("ddlADLStatusInGrid");
                    RadioButtonList rbtnlADLStatusInGrid = (RadioButtonList)gvrDetail.FindControl("rbtnlADLStatusInGrid");
                    Label lblSavedBy = (Label)gvrDetail.FindControl("lblSavedBy");
                    
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (dr["ADLHeaderDetailID"].ToString() == hfADLHeaderDetialID.Value)
                        {
                            bool isExitInDdl = false;
                            foreach (ListItem item in ddlADLStatusInGrid.Items)
                            {
                                if (item.Value == dr["ExtraField1"].ToString())
                                {
                                    isExitInDdl = true;
                                    rbtnlADLStatusInGrid.SelectedValue = dr["ExtraField1"].ToString();
                                    break;
                                }
                            }

                            if (!isExitInDdl)
                            {
                                rbtnlADLStatusInGrid.SelectedIndex = -1;
                                txtNewStatus.Text = dr["ExtraField1"].ToString();
                            }

                            txtRemark.Text = dr["ExtraField3"].ToString();
                            if (dr["ExtraField1"].ToString() == "")
                            {
                                lblSavedBy.Text = "";
                            }
                            else
                            {
                                lblSavedBy.Text = dr["ExtraField2"].ToString();
                            }
                            break;
                        }
                    }
                }
            }
        }
        else
        {
            foreach (GridViewRow gvr in gvHeader.Rows)
            {
                HiddenField hfADLHeaderID = (HiddenField)gvr.FindControl("hfADLHeaderID");
                GridView gvDetail = (GridView)gvr.FindControl("gvDetail");

                foreach (GridViewRow gvrDetail in gvDetail.Rows)
                {
                    HiddenField hfADLHeaderDetialID = (HiddenField)gvrDetail.FindControl("hfADLHeaderDetialID");
                    TextBox txtNewStatus = (TextBox)gvrDetail.FindControl("txtNewStatus");
                    DropDownList ddlADLStatusInGrid = (DropDownList)gvrDetail.FindControl("ddlADLStatusInGrid");
                    txtNewStatus.Text = "";
                    ddlADLStatusInGrid.SelectedIndex = 0;
                }
            }
        }
        
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        loadGrid();
    }
    
    protected void btnSaveNewADL_Click(object sender, EventArgs e)
    {
        foreach (DataListItem item in dlADLDetail.Items)
        {
            CheckBox chkSelect = (CheckBox)item.FindControl("chkSelect");
            if (chkSelect.Checked && chkSelect.ToolTip == "0") //newly selected
            {
                ADLHeaderDetail aDLHeaderDetail = new ADLHeaderDetail();

                aDLHeaderDetail.ADLDetailID = Int32.Parse(chkSelect.ValidationGroup);
                aDLHeaderDetail.ADLHeaderID = Int32.Parse(ddlADLHeader.SelectedValue);
                aDLHeaderDetail.ResidentID = Int32.Parse(Request.QueryString["ResidentID"]);
                aDLHeaderDetail.ExtraField1 = "";
                aDLHeaderDetail.ExtraField2 = "";
                aDLHeaderDetail.ExtraField3 = "";
                aDLHeaderDetail.ExtraField4 = "";
                aDLHeaderDetail.ExtraField5 = "";
                int resutl = ADLHeaderDetailManager.InsertADLHeaderDetail(aDLHeaderDetail);
            }
            else
                if (!chkSelect.Checked && chkSelect.ToolTip != "0") //Need to delete
                {
                    ADLHeaderDetailManager.DeleteADLHeaderDetail(int.Parse(chkSelect.ToolTip));
                }
        }

        lblNewADLSaveMessage.Visible = true;
        lblNewADLSaveMessage.ForeColor = System.Drawing.Color.Green;

        loadADLDetailStatus();
        loadGrid();
        ddlADLHeader_SelectedIndexChanged(this,new EventArgs());
    }
    protected void ddlADLHeader_SelectedIndexChanged(object sender, EventArgs e)
    {
        showHeaderDetail();
    }

    private void showHeaderDetail()
    {
        foreach (DataListItem item in dlADLDetail.Items)
        {
            CheckBox chkSelect = (CheckBox)item.FindControl("chkSelect");
            chkSelect.Checked = false;
            chkSelect.ToolTip = "0";
        }

        foreach (GridViewRow gvr in gvHeader.Rows)
        {
            HiddenField hfADLHeaderID = (HiddenField)gvr.FindControl("hfADLHeaderID");
            GridView gvDetail = (GridView)gvr.FindControl("gvDetail");

            if (hfADLHeaderID.Value == ddlADLHeader.SelectedValue)
            {
                foreach (DataListItem item in dlADLDetail.Items)
                {
                    CheckBox chkSelect = (CheckBox)item.FindControl("chkSelect");
                    chkSelect.Checked = false;
                    chkSelect.ToolTip = "0";
                    foreach (GridViewRow gvrDetail in gvDetail.Rows)
                    {
                        HiddenField hfADLDetailID = (HiddenField)gvrDetail.FindControl("hfADLDetailID");
                        if (hfADLDetailID.Value == chkSelect.ValidationGroup)
                        {
                            chkSelect.Checked = true;
                            chkSelect.ToolTip = ((CheckBox)gvrDetail.FindControl("chkSelect")).ValidationGroup;
                            break;
                        }
                    }
                }
            }
        }
    }

    private void showHeaderDetailByResidentID()
    {
        List<ADLHeaderDetail> aDLHeaderDetailByResident=  ADLHeaderDetailManager.GetAllADLHeaderDetailsByResidentID(int.Parse(Request.QueryString["ResidentID"]));
        if (aDLHeaderDetailByResident.Count == 0)
        {
            aDLHeaderDetailByResident = ADLHeaderDetailManager.GetDefaultAfterInsertADLHeaderDetails(int.Parse(Request.QueryString["ResidentID"]));
        }
        List<ADLHeader> aDLHeaderbyResident = new List<ADLHeader>();

        foreach (ADLHeaderDetail item in aDLHeaderDetailByResident)
        {
            bool needToAdd = true;
            if (aDLHeaderbyResident.Count != 0)
            {
                foreach (ADLHeader itm in aDLHeaderbyResident)
                {
                    if (itm.ADLHeaderID == item.ADLHeaderID)
                    {
                        needToAdd = false;
                        break;
                    }
                }
            }

            if (needToAdd)
            {
                ADLHeader newADLHeader = new ADLHeader();
                newADLHeader.ADLHeaderID = item.ADLHeaderID;
                newADLHeader.ADLHeaderName = item.ExtraField1;

                aDLHeaderbyResident.Add(newADLHeader);
            }
        }

        gvHeader.DataSource = aDLHeaderbyResident;
        gvHeader.DataBind();

        foreach (GridViewRow gvr in gvHeader.Rows)
        {
            HiddenField hfADLHeaderID = (HiddenField)gvr.FindControl("hfADLHeaderID");
            GridView gvDetail = (GridView)gvr.FindControl("gvDetail");

            List<ADLDetail> aDLDetailbyResident = new List<ADLDetail>();

            foreach (ADLHeaderDetail item in aDLHeaderDetailByResident)
            {
                if (item.ADLHeaderID.ToString() == hfADLHeaderID.Value)
                {
                    bool needToAdd = true;
                    if (aDLDetailbyResident.Count != 0)
                    {
                        foreach (ADLDetail itm in aDLDetailbyResident)
                        {
                            if (itm.ADLDetailID == item.ADLDetailID)
                            {
                                needToAdd = false;
                                break;
                            }
                        }
                    }

                    if (needToAdd)
                    {
                        ADLDetail newADLDetail = new ADLDetail();
                        newADLDetail.ADLDetailID = item.ADLDetailID;
                        newADLDetail.ADLDetailName = item.ExtraField2;
                        newADLDetail.ExtraField1 = item.ADLHeaderDetailID.ToString();
                        aDLDetailbyResident.Add(newADLDetail);
                    }
                }
            }

            gvDetail.DataSource = aDLDetailbyResident;
            gvDetail.DataBind();

            foreach (GridViewRow gvrDetail in gvDetail.Rows)
            {
                DropDownList ddlADLStatusInGrid = (DropDownList)gvrDetail.FindControl("ddlADLStatusInGrid");
                HiddenField hfADLDetailID=(HiddenField)gvrDetail.FindControl("hfADLDetailID");
                RadioButtonList rbtnlADLStatusInGrid = (RadioButtonList)gvrDetail.FindControl("rbtnlADLStatusInGrid");

                ddlADLStatusInGrid.Items.Clear();
                ListItem li = new ListItem("Select >>", "-1");
                ddlADLStatusInGrid.Items.Add(li);
                
                foreach (ListItem item in ddlADLStatus.Items)
                {
                    if (item.Value == hfADLDetailID.Value)
                    {
                        ddlADLStatusInGrid.Items.Add(new ListItem(item.Text, item.Text));
                        rbtnlADLStatusInGrid.Items.Add(new ListItem(item.Text, item.Text));
                    }
                }

                //li = new ListItem("Other", "0");
                //ddlADLStatusInGrid.Items.Add(li);
                //rbtnlADLStatusInGrid.Items.Add(li);
                //rbtnlADLStatusInGrid.SelectedIndex = 0;
            }
        }       
    }
}