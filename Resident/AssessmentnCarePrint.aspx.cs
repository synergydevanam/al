using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Resident_ADLRecord : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ResidentID"] != null)
            {
                loadAssessmentnCareDate();
            }
            loadGrid();
            ddlExistingRecord.SelectedValue = Request.QueryString["AssessmentnCareDateIDID"];
            ddlExistingRecord_SelectedIndexChanged(this, new EventArgs());
        }
    }

    private void loadAssessmentnCareDate()
    {
        ListItem li = new ListItem("New Record", "0");
        ddlExistingRecord.Items.Add(li);

        List<AssessmentnCareDate> assessmentnCareDates = new List<AssessmentnCareDate>();
        assessmentnCareDates = AssessmentnCareDateIDManager.GetAllAssessmentnCareDatesByResidentID(int.Parse(Request.QueryString["ResidentID"]));
        foreach (AssessmentnCareDate assessmentnCareDate in assessmentnCareDates)
        {
            ListItem item = new ListItem(assessmentnCareDate.AssessmentnCareDateName.ToString("yyyy-MM-dd hh:mm tt"), assessmentnCareDate.AssessmentnCareDateIDID.ToString());
            ddlExistingRecord.Items.Add(item);
        }
    }

    

    private void loadGrid()
    {
        gvAssessmentnCareParent.DataSource = AssessmentnCareParentManager.GetAllAssessmentnCareParentsByAssessmentnCareDateIDID(int.Parse(Request.QueryString["AssessmentnCareDateIDID"]));
        gvAssessmentnCareParent.DataBind();

        List<AssessmentnCareChild> assessmentCareChilds = new List<AssessmentnCareChild>();
        assessmentCareChilds = AssessmentnCareChildManager.GetAllAssessmentnCareChildsByAssessmentnCareDateIDID(int.Parse(Request.QueryString["AssessmentnCareDateIDID"]));

        foreach (GridViewRow gvr in gvAssessmentnCareParent.Rows)
        {
            HiddenField hfAssessmentnCareParentID = (HiddenField)gvr.FindControl("hfAssessmentnCareParentID");
            DataList dlAssessmentnCareChild = (DataList)gvr.FindControl("dlAssessmentnCareChild");

            List<AssessmentnCareChild> assessmentCareChildByParentID = new List<AssessmentnCareChild>();
            foreach (AssessmentnCareChild item in assessmentCareChilds)
            {
                if (item.AssessmentnCareParentID.ToString() == hfAssessmentnCareParentID.Value)
                {
                    assessmentCareChildByParentID.Add(item);
                }
            }

            dlAssessmentnCareChild.DataSource = assessmentCareChildByParentID;
            dlAssessmentnCareChild.DataBind();
        }
    }

    private Login getLogin()
    {
        Login login = new Login();
        try
        {
            if (Session["Login"] == null) { Session["PreviousPage"] = HttpContext.Current.Request.Url.AbsoluteUri; Response.Redirect("../LoginPage.aspx"); }

            login = (Login)Session["Login"];
        }
        catch (Exception ex)
        { }

        return login;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string ChiledIDs = getChiledIds();
        string CommentsByParentIDs = getCommentsByParentIDs();

        if (ChiledIDs == "" && CommentsByParentIDs == "")
        {
            return;
        }

        AssessmentnCareDate tempAssessmentnCareDateID = new AssessmentnCareDate();
        tempAssessmentnCareDateID.AssessmentnCareDateIDID = int.Parse(ddlExistingRecord.SelectedValue);
        try
        {
            tempAssessmentnCareDateID.AssessmentnCareDateName = DateTime.Parse(ddlExistingRecord.SelectedItem.Text);
        }
        catch (Exception ex)
        {
            tempAssessmentnCareDateID.AssessmentnCareDateName = DateTime.Now;
        }
       
        tempAssessmentnCareDateID.ResidentID = Int32.Parse(Request.QueryString["ResidentID"]);
        tempAssessmentnCareDateID.AddedBy = getLogin().LoginID;
        tempAssessmentnCareDateID.AddedDate = DateTime.Now;
        tempAssessmentnCareDateID.UpdatedBy = getLogin().LoginID;
        tempAssessmentnCareDateID.UpdatedDate = DateTime.Now;
        bool result = AssessmentnCareDateIDManager.ProcessAssessmentnCareDateID(tempAssessmentnCareDateID,ChiledIDs,CommentsByParentIDs);
        lblMsg.Visible = true;
        loadAssessmentnCareDate();
        ddlExistingRecord.SelectedValue = "0";
        ddlExistingRecord_SelectedIndexChanged(this, new EventArgs());
    }

    private string getChiledIds()
    {
        string ChiledIDs = "";
        
        foreach (GridViewRow gvr in gvAssessmentnCareParent.Rows)
        {
            DataList dlAssessmentnCareChild = (DataList)gvr.FindControl("dlAssessmentnCareChild");

            foreach (DataListItem item in dlAssessmentnCareChild.Items)
            {
                CheckBox chkSelect = (CheckBox)item.FindControl("chkSelect");
                if (chkSelect.Checked)
                {
                    if (ChiledIDs != "")
                    {
                        ChiledIDs += ",";
                    }
                    ChiledIDs += chkSelect.ToolTip;
                }
            }
        }

        return ChiledIDs;
    }

    private string getCommentsByParentIDs()
    {
        string CommentsByParentIDs = "";
        foreach (GridViewRow gvr in gvAssessmentnCareParent.Rows)
        {
            HiddenField hfAssessmentnCareParentID = (HiddenField)gvr.FindControl("hfAssessmentnCareParentID");
            TextBox txtComment = (TextBox)gvr.FindControl("txtComment");
            if (txtComment.Text !="")
            {
                if (CommentsByParentIDs != "")
                {
                    CommentsByParentIDs += "|";
                }
                CommentsByParentIDs += hfAssessmentnCareParentID.Value+"^"+txtComment.Text;
            }
            
        }
        return CommentsByParentIDs;
    }
    protected void ddlExistingRecord_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadSelectData();
    }

    private void loadSelectData()
    {
        if (ddlExistingRecord.SelectedValue == "0")
        {
            foreach (GridViewRow gvr in gvAssessmentnCareParent.Rows)
            {
                DataList dlAssessmentnCareChild = (DataList)gvr.FindControl("dlAssessmentnCareChild");
                ((TextBox)gvr.FindControl("txtComment")).Text="";

                foreach (DataListItem item in dlAssessmentnCareChild.Items)
                {
                    ((CheckBox)item.FindControl("chkSelect")).Checked = false;
                }
            }
        }
        else
        {
            List<AssessmentnCareChildnDate> assessmentnCareChildnDates = AssessmentnCareChildnDateManager.GetAllAssessmentnCareChildnDatesByAssessmentnCareDateID(int.Parse(ddlExistingRecord.SelectedValue));
            List<AssessmentnCareCommentnDate> assessmentnCareCommentnDates = AssessmentnCareCommentnDateManager.GetAllAssessmentnCareCommentnDatesByAssessmentnCareDateID(int.Parse(ddlExistingRecord.SelectedValue));

            foreach (GridViewRow gvr in gvAssessmentnCareParent.Rows)
            {
                HiddenField hfAssessmentnCareParentID = (HiddenField)gvr.FindControl("hfAssessmentnCareParentID");
                DataList dlAssessmentnCareChild = (DataList)gvr.FindControl("dlAssessmentnCareChild");
                TextBox txtComment = (TextBox)gvr.FindControl("txtComment");
                
                //Load Comment
                foreach (AssessmentnCareCommentnDate item in assessmentnCareCommentnDates)
                {
                    if (item.AssessmentnCareParentID.ToString() == hfAssessmentnCareParentID.Value)
                    {
                        txtComment.Text = item.Comment;
                        break;
                    }
                }

                //load Child Item
                foreach (DataListItem item in dlAssessmentnCareChild.Items)
                {
                    CheckBox chkSelect = (CheckBox)item.FindControl("chkSelect");
                    chkSelect.Checked = false;
                    foreach (AssessmentnCareChildnDate childID in assessmentnCareChildnDates)
                    {
                        if (childID.AssessmentnCareChildID.ToString() == chkSelect.ToolTip)
                        {
                            chkSelect.Checked = true;
                            break;
                        }
                    }
                }
            }
        }
    }
}