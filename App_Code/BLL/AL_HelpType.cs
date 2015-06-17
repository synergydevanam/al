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

public class AL_HelpType
{
    public AL_HelpType()
    {
    }

    public AL_HelpType
        (
        int aL_HelpTypeID, 
        string helpTypeName
        )
    {
        this.AL_HelpTypeID = aL_HelpTypeID;
        this.HelpTypeName = helpTypeName;
    }


    private int _aL_HelpTypeID;
    public int AL_HelpTypeID
    {
        get { return _aL_HelpTypeID; }
        set { _aL_HelpTypeID = value; }
    }

    private string _helpTypeName;
    public string HelpTypeName
    {
        get { return _helpTypeName; }
        set { _helpTypeName = value; }
    }
}
