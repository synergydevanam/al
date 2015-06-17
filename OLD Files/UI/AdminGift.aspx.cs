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
 public partial class AdminGift : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadGiftData();
         
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showGiftData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	Gift gift = new Gift ();
//	gift.GiftID=  int.Parse(ddlGiftID.SelectedValue);
	gift.GiftName=  txtGiftName.Text;
	int resutl =GiftManager.InsertGift(gift);
	Response.Redirect("AdminDisplayGift.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	Gift gift = new Gift ();
	gift.GiftID=  int.Parse(Request.QueryString["ID"].ToString());
	gift.GiftName=  txtGiftName.Text;
	bool  resutl =GiftManager.UpdateGift(gift);
	Response.Redirect("AdminDisplayGift.aspx");
	}
	private void showGiftData()
	{
	 	Gift gift  = new Gift ();
	 	gift = GiftManager.GetGiftByGiftID(Int32.Parse(Request.QueryString["ID"]));
	 	txtGiftName.Text =gift.GiftName.ToString();
	}
	
}

