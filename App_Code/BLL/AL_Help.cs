using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public class AL_Help
{
    public AL_Help()
    {
    }

    public AL_Help
        (
        int aL_HelpID, 
        int helpTypeID, 
        string question, 
        string answer
        )
    {
        this.AL_HelpID = aL_HelpID;
        this.HelpTypeID = helpTypeID;
        this.Question = question;
        this.Answer = answer;
    }


    private int _aL_HelpID;
    public int AL_HelpID
    {
        get { return _aL_HelpID; }
        set { _aL_HelpID = value; }
    }

    private int _helpTypeID;
    public int HelpTypeID
    {
        get { return _helpTypeID; }
        set { _helpTypeID = value; }
    }

    private string _helpTypeName;
    public string HelpTypeName
    {
        get { return _helpTypeName; }
        set { _helpTypeName = value; }
    }

    private string _question;
    public string Question
    {
        get { return _question; }
        set { _question = value; }
    }

    private string _answer;
    public string Answer
    {
        get { return _answer; }
        set { _answer = value; }
    }
}
