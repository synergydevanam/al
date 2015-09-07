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

public class SectionLabel
{
    public SectionLabel()
    {
    }

    public SectionLabel
        (
        int sectionLabelID, 
        int sectionNo, 
        string labelText, 
        string extraField1, 
        string extraField2, 
        string extraField3, 
        string extraField4, 
        string extraField5
        )
    {
        this.SectionLabelID = sectionLabelID;
        this.SectionNo = sectionNo;
        this.LabelText = labelText;
        this.ExtraField1 = extraField1;
        this.ExtraField2 = extraField2;
        this.ExtraField3 = extraField3;
        this.ExtraField4 = extraField4;
        this.ExtraField5 = extraField5;
    }


    private int _sectionLabelID;
    public int SectionLabelID
    {
        get { return _sectionLabelID; }
        set { _sectionLabelID = value; }
    }

    private int _sectionNo;
    public int SectionNo
    {
        get { return _sectionNo; }
        set { _sectionNo = value; }
    }

    private string _labelText;
    public string LabelText
    {
        get { return _labelText; }
        set { _labelText = value; }
    }

    private string _extraField1;
    /// <summary>
    /// order
    /// </summary>
    public string ExtraField1
    {
        get { return _extraField1; }
        set { _extraField1 = value; }
    }

    private string _extraField2;
    public string ExtraField2
    {
        get { return _extraField2; }
        set { _extraField2 = value; }
    }

    private string _extraField3;
    public string ExtraField3
    {
        get { return _extraField3; }
        set { _extraField3 = value; }
    }

    private string _extraField4;
    public string ExtraField4
    {
        get { return _extraField4; }
        set { _extraField4 = value; }
    }

    private string _extraField5;
    public string ExtraField5
    {
        get { return _extraField5; }
        set { _extraField5 = value; }
    }
}
