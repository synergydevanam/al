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

public partial class AdminADLHeaderInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["aDLHeaderID"] != null)
            {
                int aDLHeaderID = Int32.Parse(Request.QueryString["aDLHeaderID"]);
                if (aDLHeaderID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showADLHeaderData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ADLHeader aDLHeader = new ADLHeader();

        aDLHeader.ADLHeaderName = txtADLHeaderName.Text;
        aDLHeader.ExtraField1 = txtExtraField1.Text;
        aDLHeader.ExtraField2 = txtExtraField2.Text;
        aDLHeader.ExtraField3 = txtExtraField3.Text;
        aDLHeader.ExtraField4 = txtExtraField4.Text;
        aDLHeader.ExtraField5 = txtExtraField5.Text;
        int resutl = ADLHeaderManager.InsertADLHeader(aDLHeader);
        Response.Redirect("AdminADLHeaderDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        ADLHeader aDLHeader = new ADLHeader();
        aDLHeader = ADLHeaderManager.GetADLHeaderByID(Int32.Parse(Request.QueryString["aDLHeaderID"]));
        ADLHeader tempADLHeader = new ADLHeader();
        tempADLHeader.ADLHeaderID = aDLHeader.ADLHeaderID;

        tempADLHeader.ADLHeaderName = txtADLHeaderName.Text;
        tempADLHeader.ExtraField1 = txtExtraField1.Text;
        tempADLHeader.ExtraField2 = txtExtraField2.Text;
        tempADLHeader.ExtraField3 = txtExtraField3.Text;
        tempADLHeader.ExtraField4 = txtExtraField4.Text;
        tempADLHeader.ExtraField5 = txtExtraField5.Text;
        bool result = ADLHeaderManager.UpdateADLHeader(tempADLHeader);
        Response.Redirect("AdminADLHeaderDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtADLHeaderName.Text = "";
        txtExtraField1.Text = "";
        txtExtraField2.Text = "";
        txtExtraField3.Text = "";
        txtExtraField4.Text = "";
        txtExtraField5.Text = "";
    }
    private void showADLHeaderData()
    {
        ADLHeader aDLHeader = new ADLHeader();
        aDLHeader = ADLHeaderManager.GetADLHeaderByID(Int32.Parse(Request.QueryString["aDLHeaderID"]));

        txtADLHeaderName.Text = aDLHeader.ADLHeaderName;
        txtExtraField1.Text = aDLHeader.ExtraField1;
        txtExtraField2.Text = aDLHeader.ExtraField2;
        txtExtraField3.Text = aDLHeader.ExtraField3;
        txtExtraField4.Text = aDLHeader.ExtraField4;
        txtExtraField5.Text = aDLHeader.ExtraField5;
    }
}
