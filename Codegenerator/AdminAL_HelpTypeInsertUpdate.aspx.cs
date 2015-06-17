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

public partial class AdminAL_HelpTypeInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["aL_HelpTypeID"] != null)
            {
                int aL_HelpTypeID = Int32.Parse(Request.QueryString["aL_HelpTypeID"]);
                if (aL_HelpTypeID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showAL_HelpTypeData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        AL_HelpType aL_HelpType = new AL_HelpType();

        aL_HelpType.HelpTypeName = txtHelpTypeName.Text;
        int resutl = AL_HelpTypeManager.InsertAL_HelpType(aL_HelpType);
        Response.Redirect("AdminAL_HelpTypeDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        AL_HelpType aL_HelpType = new AL_HelpType();
        aL_HelpType = AL_HelpTypeManager.GetAL_HelpTypeByID(Int32.Parse(Request.QueryString["aL_HelpTypeID"]));
        AL_HelpType tempAL_HelpType = new AL_HelpType();
        tempAL_HelpType.AL_HelpTypeID = aL_HelpType.AL_HelpTypeID;

        tempAL_HelpType.HelpTypeName = txtHelpTypeName.Text;
        bool result = AL_HelpTypeManager.UpdateAL_HelpType(tempAL_HelpType);
        Response.Redirect("AdminAL_HelpTypeDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtHelpTypeName.Text = "";
    }
    private void showAL_HelpTypeData()
    {
        AL_HelpType aL_HelpType = new AL_HelpType();
        aL_HelpType = AL_HelpTypeManager.GetAL_HelpTypeByID(Int32.Parse(Request.QueryString["aL_HelpTypeID"]));

        txtHelpTypeName.Text = aL_HelpType.HelpTypeName;
    }
}
