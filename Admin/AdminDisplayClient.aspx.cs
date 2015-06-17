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
 

public partial class Admin_AdminDisplayClient : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var search_val = "";
            string serachString = "";
            SetPermission();
           
            if (Request.QueryString["search"] != null)
            {
                search_val = Request.QueryString["search"].ToString();

                ClientManager.LoadCallLogPage(search_val, gvClient, rptPager, 1, ddlPageSize, lbltotalRecord, 0, Convert.ToDateTime("1/1/1900 12:00:00 Pm"), Convert.ToDateTime("1/1/3000 12:00:00 Pm"), "0", "0");
                //ClientManager.LoadCallLogPage(search_val, gvClient, rptPager, 1, ddlPageSize, lbltotalRecord, 0, Convert.ToDateTime("1/1/1900 12:00:00 Pm"), Convert.ToDateTime("1/1/3000 12:00:00 Pm"),);
            }
            else
            {
                serachString = "";
                txtDateFrom.Text = String.Format("{0:M/d/yyyy}", DateTime.Now);
                txtDateTo.Text = String.Format("{0:M/d/yyyy}", DateTime.Now);

                SearchClient();
            }


            //ClientManager.LoadClientPage(search_val, gvClient, rptPager, 1, ddlPageSize, lbltotalRecord, 0, Convert.ToDateTime("1/1/1900 12:00:00 Pm"), Convert.ToDateTime("1/1/3000 12:00:00 Pm"));

        }
        SetPermission();

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SearchClient();


    }
    public void SearchClient()
    {
       
        int LocationID = 0;
        string searchText = "";
       
        DateTime fromDate = Convert.ToDateTime("1/1/1900 12:00:00 Pm");
        DateTime ToDate = Convert.ToDateTime("1/1/3000 12:00:00 Pm");

        if (!string.IsNullOrEmpty(txtDateFrom.Text.Trim()))
        {
            if (DateTime.TryParse(txtDateFrom.Text.Trim() + " 00:00:00", out fromDate))
            {

            }
        }
        if (!string.IsNullOrEmpty(txtDateTo.Text.Trim()))
        {
            if (DateTime.TryParse(txtDateTo.Text.Trim() + " 23:59:59", out ToDate))
            {

            }
        }
        ClientManager.LoadCallLogPage("", gvClient, rptPager, 1, ddlPageSize, lbltotalRecord, 0, fromDate, ToDate, "0", "0");
       
    }
    public FormRights fright;
    public void SetPermission()
    {


        MembershipUser currentUser;
        currentUser = Membership.GetUser();
        if (currentUser == null)
            Response.Redirect("~/login.aspx");

        var clientID = currentUser.ProviderUserKey.ToString();
        string pageName = "AdminDisplayClient";
        fright = FormRightsManager.GetFormRightsByUserIDFormID(pageName, clientID);


    }
    protected void PageSize_Changed(object sender, EventArgs e)
    {
        var search_val = "";
        SearchClient();
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        var search_val = "";
        if (Request.QueryString["search"] != null)
        {
            search_val = Request.QueryString["search"].ToString();

        }

        if (Request.QueryString["search"] != null)
        {
            search_val = Request.QueryString["search"].ToString();

            ClientManager.LoadClientPage(search_val, gvClient, rptPager, 1, ddlPageSize, lbltotalRecord, 0, Convert.ToDateTime("1/1/1900 12:00:00 Pm"), Convert.ToDateTime("1/1/3000 12:00:00 Pm"));
        }
        else
        {

            
            int LocationID = 0;
            string searchText = "";
           
            DateTime fromDate = Convert.ToDateTime("1/1/1900 12:00:00 Pm");
            DateTime ToDate = Convert.ToDateTime("1/1/3000 12:00:00 Pm");

            if (!string.IsNullOrEmpty(txtDateFrom.Text.Trim()))
            {
                if (DateTime.TryParse(txtDateFrom.Text.Trim() + " 00:00:00", out fromDate))
                {

                }
            }
            if (!string.IsNullOrEmpty(txtDateTo.Text.Trim()))
            {
                if (DateTime.TryParse(txtDateTo.Text.Trim() + " 23:59:59", out ToDate))
                {

                }
            }

            ClientManager.LoadCallLogPage("", gvClient, rptPager, 1, ddlPageSize, lbltotalRecord, 0, fromDate, ToDate, "0", "0");
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ClientInsert.aspx?ID=0");
    }
    protected void lbSelect_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;


        GridViewRow row = (GridViewRow)linkButton.NamingContainer;


        int id;
        id = Convert.ToInt32(gvClient.DataKeys[row.RowIndex].Value);
        id -= 1;
        Response.Redirect("~/ClientView.aspx?ID=" + id);
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        var search_val = "";
        if (Request.QueryString["search"] != null)
        {
            search_val = Request.QueryString["search"].ToString();

        }
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        bool result = ClientManager.DeleteClient(Convert.ToInt32(linkButton.CommandArgument));

       
        int LocationID = 0;
        string searchText = "";
        

        DateTime fromDate = Convert.ToDateTime("1/1/1900 12:00:00 Pm");
        DateTime ToDate = Convert.ToDateTime("1/1/3000 12:00:00 Pm");

        if (!string.IsNullOrEmpty(txtDateFrom.Text.Trim()))
        {
            if (DateTime.TryParse(txtDateFrom.Text.Trim() + " 00:00:00", out fromDate))
            {

            }
        }
        if (!string.IsNullOrEmpty(txtDateTo.Text.Trim()))
        {
            if (DateTime.TryParse(txtDateTo.Text.Trim() + " 23:59:59", out ToDate))
            {

            }
        }

        ClientManager.LoadCallLogPage("", gvClient, rptPager, 1, ddlPageSize, lbltotalRecord, 0, fromDate, ToDate, "0", "0");

    }


    string mertoname = "";
    int RowsProcessed = 0;
    protected void gvClient_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                RowsProcessed += 1;


                Label lblMetroLocationName = (Label)e.Row.FindControl("lblMetroLocationName");
                Label lblClientID = (Label)e.Row.FindControl("lblClientID");
                Label lblApptTime = (Label)e.Row.FindControl("lblApptTime");
                Label lblApptDate = (Label)e.Row.FindControl("lblApptDate");
                Label lblAppStatus = (Label)e.Row.FindControl("lblAppStatus");

                if (lblAppStatus.Text == "5")
                {

                    e.Row.Cells[9].BackColor = System.Drawing.Color.Green;
                    lblAppStatus.Text = "SU";
                }
                else if (lblAppStatus.Text == "3")
                {

                    e.Row.Cells[9].BackColor = System.Drawing.Color.LightSkyBlue;
                    lblAppStatus.Text = "CF";
                }
                else if (lblAppStatus.Text == "2")
                {

                    lblAppStatus.Text = "SC";
                    e.Row.Cells[9].BackColor = System.Drawing.Color.LightBlue;

                }
                else if (lblAppStatus.Text == "1")
                {

                    lblAppStatus.Text = "S";
                }
                else if (lblAppStatus.Text == "16")
                {

                    lblAppStatus.Text = "NS";
                }
                else if (lblAppStatus.Text == "17")
                {

                    lblAppStatus.Text = "LM";
                }
                else if (lblAppStatus.Text == "18")
                {

                    lblAppStatus.Text = "NA";
                }



                if (lblApptDate.Text == "01-01-1900")
                {
                    lblApptDate.Text = "";
                    lblApptTime.Text = "";
                }


                //string maxApptDate = ClientManager.GetClientByMaxApptDate(Convert.ToInt32(lblClientID.Text));
                //DateTime now = new DateTime();
                //if (DateTime.TryParse(maxApptDate, out now))
                //{
                //    lblApptDate.Text = String.Format("{0:M/d/yyyy}", now);
                //    lblApptTime.Text = String.Format("{0:t}", now);
                //}


                if (e.Row.RowIndex == 0)
                {

                    mertoname = lblMetroLocationName.Text;
                    GridViewRow g = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal);
                    TableCell tCell = new TableCell();
                    tCell.Text = "<center> <b>" + mertoname + "</b> </center>";
                    tCell.ColumnSpan = 20;

                    g.Cells.Add(tCell);

                    g.BackColor = System.Drawing.Color.LightGray;

                    Table tbl = e.Row.Parent as Table;


                    tbl.Rows.AddAt(1, g);
                    RowsProcessed += 1;
                }
                else
                {
                    if (mertoname != lblMetroLocationName.Text)
                    {
                        mertoname = lblMetroLocationName.Text;
                        GridViewRow g = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal);

                        TableCell tCell = new TableCell();
                        tCell.Text = "<center> <b>" + mertoname + "</b> </center>";
                        tCell.ColumnSpan = 20;
                        //Add Cells
                        g.Cells.Add(tCell);

                        g.BackColor = System.Drawing.Color.LightGray;
                        //}
                        Table tbl = e.Row.Parent as Table;
                        //add rows

                        tbl.Rows.AddAt(RowsProcessed, g);
                        RowsProcessed += 1;
                    }
                }
                Label lbSelect = (Label)e.Row.FindControl("lbSelect");

                if (lbSelect != null)
                    lbSelect.Visible = fright.SelectRight == true ? true : false;



            }
        }
        catch { }

    }
}

