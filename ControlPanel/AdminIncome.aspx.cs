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
 public partial class AdminIncome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadIncomeData();
         
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showIncomeData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	Income income = new Income ();
//	income.IncomeID=  int.Parse(ddlIncomeID.SelectedValue);
	income.IncomeName=  txtIncomeName.Text;
	int resutl =IncomeManager.InsertIncome(income);
	Response.Redirect("AdminDisplayIncome.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	Income income = new Income ();
	income.IncomeID=  int.Parse(Request.QueryString["ID"].ToString());
	income.IncomeName=  txtIncomeName.Text;
	bool  resutl =IncomeManager.UpdateIncome(income);
	Response.Redirect("AdminDisplayIncome.aspx");
	}
	private void showIncomeData()
	{
	 	Income income  = new Income ();
	 	income = IncomeManager.GetIncomeByIncomeID(Int32.Parse(Request.QueryString["ID"]));
	 	txtIncomeName.Text =income.IncomeName.ToString();
	}
	
}

