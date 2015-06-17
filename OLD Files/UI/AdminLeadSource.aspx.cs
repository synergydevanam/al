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
 public partial class AdminLeadSource : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadLeadSourceData();
         
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showLeadSourceData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	LeadSource leadSource = new LeadSource ();
//	leadSource.LeadSourceID=  int.Parse(ddlLeadSourceID.SelectedValue);
	leadSource.LeadSourceName=  txtLeadSourceName.Text;
	int resutl =LeadSourceManager.InsertLeadSource(leadSource);
	Response.Redirect("AdminDisplayLeadSource.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	LeadSource leadSource = new LeadSource ();
	leadSource.LeadSourceID=  int.Parse(Request.QueryString["ID"].ToString());
	leadSource.LeadSourceName=  txtLeadSourceName.Text;
	bool  resutl =LeadSourceManager.UpdateLeadSource(leadSource);
	Response.Redirect("AdminDisplayLeadSource.aspx");
	}
	private void showLeadSourceData()
	{
	 	LeadSource leadSource  = new LeadSource ();
	 	leadSource = LeadSourceManager.GetLeadSourceByLeadSourceID(Int32.Parse(Request.QueryString["ID"]));
	 	txtLeadSourceName.Text =leadSource.LeadSourceName.ToString();
	}
	
}

