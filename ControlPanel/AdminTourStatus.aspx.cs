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
 public partial class AdminTourStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadTourStatusData();
         
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showTourStatusData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	TourStatus tourStatus = new TourStatus ();
//	tourStatus.TourStatusID=  int.Parse(ddlTourStatusID.SelectedValue);
	tourStatus.TourStatusName=  txtTourStatusName.Text;
	int resutl =TourStatusManager.InsertTourStatus(tourStatus);
	Response.Redirect("AdminDisplayTourStatus.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	TourStatus tourStatus = new TourStatus ();
	tourStatus.TourStatusID=  int.Parse(Request.QueryString["ID"].ToString());
	tourStatus.TourStatusName=  txtTourStatusName.Text;
	bool  resutl =TourStatusManager.UpdateTourStatus(tourStatus);
	Response.Redirect("AdminDisplayTourStatus.aspx");
	}
	private void showTourStatusData()
	{
	 	TourStatus tourStatus  = new TourStatus ();
	 	tourStatus = TourStatusManager.GetTourStatusByTourStatusID(Int32.Parse(Request.QueryString["ID"]));
	 	txtTourStatusName.Text =tourStatus.TourStatusName.ToString();
	}
	
}

