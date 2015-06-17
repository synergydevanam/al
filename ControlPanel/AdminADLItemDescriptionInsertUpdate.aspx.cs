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

public partial class AdminADLItemDescriptionInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["aDLItemDescriptionID"] != null)
            {
                int aDLItemDescriptionID = Int32.Parse(Request.QueryString["aDLItemDescriptionID"]);
                if (aDLItemDescriptionID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showADLItemDescriptionData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ADLItemDescription aDLItemDescription = new ADLItemDescription();

        aDLItemDescription.ADLItemDescriptionName = txtADLItemDescriptionName.Text;
        int resutl = ADLItemDescriptionManager.InsertADLItemDescription(aDLItemDescription);
        Response.Redirect("AdminADLItemDescriptionDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        ADLItemDescription aDLItemDescription = new ADLItemDescription();
        aDLItemDescription = ADLItemDescriptionManager.GetADLItemDescriptionByID(Int32.Parse(Request.QueryString["aDLItemDescriptionID"]));
        ADLItemDescription tempADLItemDescription = new ADLItemDescription();
        tempADLItemDescription.ADLItemDescriptionID = aDLItemDescription.ADLItemDescriptionID;

        tempADLItemDescription.ADLItemDescriptionName = txtADLItemDescriptionName.Text;
        bool result = ADLItemDescriptionManager.UpdateADLItemDescription(tempADLItemDescription);
        Response.Redirect("AdminADLItemDescriptionDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtADLItemDescriptionName.Text = "";
    }
    private void showADLItemDescriptionData()
    {
        ADLItemDescription aDLItemDescription = new ADLItemDescription();
        aDLItemDescription = ADLItemDescriptionManager.GetADLItemDescriptionByID(Int32.Parse(Request.QueryString["aDLItemDescriptionID"]));

        txtADLItemDescriptionName.Text = aDLItemDescription.ADLItemDescriptionName;
    }
}
