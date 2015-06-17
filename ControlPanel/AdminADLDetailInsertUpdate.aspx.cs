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

public partial class AdminADLDetailInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["aDLDetailID"] != null)
            {
                int aDLDetailID = Int32.Parse(Request.QueryString["aDLDetailID"]);
                if (aDLDetailID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showADLDetailData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ADLDetail aDLDetail = new ADLDetail();

        aDLDetail.ADLDetailName = txtADLDetailName.Text;
        aDLDetail.ExtraField1 = txtExtraField1.Text;
        aDLDetail.ExtraField2 = txtExtraField2.Text;
        aDLDetail.ExtraField3 = txtExtraField3.Text;
        aDLDetail.ExtraField4 = txtExtraField4.Text;
        aDLDetail.ExtraField5 = txtExtraField5.Text;
        int resutl = ADLDetailManager.InsertADLDetail(aDLDetail);
        Response.Redirect("AdminADLDetailDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        ADLDetail aDLDetail = new ADLDetail();
        aDLDetail = ADLDetailManager.GetADLDetailByID(Int32.Parse(Request.QueryString["aDLDetailID"]));
        ADLDetail tempADLDetail = new ADLDetail();
        tempADLDetail.ADLDetailID = aDLDetail.ADLDetailID;

        tempADLDetail.ADLDetailName = txtADLDetailName.Text;
        tempADLDetail.ExtraField1 = txtExtraField1.Text;
        tempADLDetail.ExtraField2 = txtExtraField2.Text;
        tempADLDetail.ExtraField3 = txtExtraField3.Text;
        tempADLDetail.ExtraField4 = txtExtraField4.Text;
        tempADLDetail.ExtraField5 = txtExtraField5.Text;
        bool result = ADLDetailManager.UpdateADLDetail(tempADLDetail);
        Response.Redirect("AdminADLDetailDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtADLDetailName.Text = "";
        txtExtraField1.Text = "";
        txtExtraField2.Text = "";
        txtExtraField3.Text = "";
        txtExtraField4.Text = "";
        txtExtraField5.Text = "";
    }
    private void showADLDetailData()
    {
        ADLDetail aDLDetail = new ADLDetail();
        aDLDetail = ADLDetailManager.GetADLDetailByID(Int32.Parse(Request.QueryString["aDLDetailID"]));

        txtADLDetailName.Text = aDLDetail.ADLDetailName;
        txtExtraField1.Text = aDLDetail.ExtraField1;
        txtExtraField2.Text = aDLDetail.ExtraField2;
        txtExtraField3.Text = aDLDetail.ExtraField3;
        txtExtraField4.Text = aDLDetail.ExtraField4;
        txtExtraField5.Text = aDLDetail.ExtraField5;
    }
}
