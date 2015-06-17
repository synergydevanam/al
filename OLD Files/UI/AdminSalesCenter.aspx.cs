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
 public partial class AdminSalesCenter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSalesCenterData();
         
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSalesCenterData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	SalesCenter salesCenter = new SalesCenter ();
//	salesCenter.SalesCenterId=  int.Parse(txtSalesCenterId.Text);
	salesCenter.SalesCenterName=  txtSalesCenterName.Text;
	int resutl =SalesCenterManager.InsertSalesCenter(salesCenter);
	Response.Redirect("AdminDisplaySalesCenter.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	SalesCenter salesCenter = new SalesCenter ();
	salesCenter.SalesCenterId=  int.Parse(Request.QueryString["ID"].ToString());
	salesCenter.SalesCenterName=  txtSalesCenterName.Text;
	bool  resutl =SalesCenterManager.UpdateSalesCenter(salesCenter);
	Response.Redirect("AdminDisplaySalesCenter.aspx");
	}
	private void showSalesCenterData()
	{
	 	SalesCenter salesCenter  = new SalesCenter ();
	 	salesCenter = SalesCenterManager.GetSalesCenterBySalesCenterId(Int32.Parse(Request.QueryString["ID"]));
	 	txtSalesCenterName.Text =salesCenter.SalesCenterName.ToString();
	}
	
}

