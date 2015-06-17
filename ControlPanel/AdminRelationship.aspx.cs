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
 public partial class AdminRelationship : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadRelationshipData();
         
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showRelationshipData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	Relationship relationship = new Relationship ();
//	relationship.RelationshipID=  int.Parse(ddlRelationshipID.SelectedValue);
	relationship.RelationshipName=  txtRelationshipName.Text;
	int resutl =RelationshipManager.InsertRelationship(relationship);
	Response.Redirect("AdminDisplayRelationship.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	Relationship relationship = new Relationship ();
	relationship.RelationshipID=  int.Parse(Request.QueryString["ID"].ToString());
	relationship.RelationshipName=  txtRelationshipName.Text;
	bool  resutl =RelationshipManager.UpdateRelationship(relationship);
	Response.Redirect("AdminDisplayRelationship.aspx");
	}
	private void showRelationshipData()
	{
	 	Relationship relationship  = new Relationship ();
	 	relationship = RelationshipManager.GetRelationshipByRelationshipID(Int32.Parse(Request.QueryString["ID"]));
	 	txtRelationshipName.Text =relationship.RelationshipName.ToString();
	}
	
}

