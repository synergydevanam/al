<%@ Page Title="" Language="C#" MasterPageFile="~/WithoutLeftMenuPrint.master" AutoEventWireup="true"
    CodeFile="DoctorsOrderPrint.aspx.cs" Inherits="Resident_ADLRecord" %>
    
<%@ Register Src="../control/PrintingControlResidentInfo.ascx" TagName="PrintingControlResidentInfo"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <link href="../css/jquery-ui-1.8.20.custom.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery.ui.timepicker.js" type="text/javascript"></script>
    <script src="../js/jquery-ui-1.8.20.custom.min.js" type="text/javascript"></script>
    <link href="../css/jquery.ui.timepicker.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        jQuery(document).ready(function ($) {
            var dates = $('#<%= txtOrderDate.ClientID %>').datepicker({
                defaultDate: "+1w",
                changeMonth: true,
                numberOfMonths: 1,
                onSelect: function (selectedDate) {
                    var option = this.id == "from" ? "minDate" : "maxDate",
					instance = $(this).data("datepicker"),
					date = $.datepicker.parseDate(
						instance.settings.dateFormat ||
						$.datepicker._defaults.dateFormat,
						selectedDate, instance.settings);
                    dates.not(this).datepicker("option", option, date);
                }
            });

        });
       
    </script>
    <style type="text/css">
        .tableMedicinAdd
        {
            width: 100%;
            padding: 30px;
            font-weight: bold;
        }
        .tableCss
        {
            width: 100%;
        }
        .tableCss td
        {
            padding: 5xp;
        }
        .tableCss th
        {
            padding: 5xp;
            background-color: #A6DBF4;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="single_colom">
        <div style="padding: 20px;">
            <uc1:PrintingControlResidentInfo ID="PrintingControlResidentInfo1" runat="server" />
            
            <table width="100%">
                <tr style="display:none;">
                    <td align="center" style="text-align: center; font-size: 20px; font-weight: bold;">
                        Doctor's Order
                    </td>
                </tr>
                <tr style="display:none;">
                    <td>
                         <table width="100%" cellspacing="10" border="0" cellpadding="0">
                            <tr>
                                <td style="font-weight:bold;">RESIDENT NAME</td>
                                <td style="border-bottom:1px solid #8E8F8F;width:406px;">
                                    <asp:Label ID="lblResidentName" runat="server" Text=""></asp:Label>
                                </td>
                                <td style="width:60px;font-weight:bold;">PHYSICIAN</td>
                                <td style="border-bottom:1px solid #8E8F8F;width:300px;">
                                    <asp:Label ID="lblPhysicianName" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight:bold;">ADMITTED FROM</td>
                                <td colspan="3" style="border-bottom:1px solid #8E8F8F">
                                    <asp:Label ID="lblAdmittedFrom" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight:bold;">Compnay</td>
                                <td style="border-bottom:1px solid #8E8F8F;width:406px;">
                                    <asp:Label ID="lblCompnayName" runat="server" Text=""></asp:Label>
                                </td>
                                <td style="width:60px;font-weight:bold;">LANGUAGE</td>
                                <td style="border-bottom:1px solid #8E8F8F;width:300px;">
                                    <asp:Label ID="lblPrimaryLanguage" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight:bold;">PROPERTY</td>
                                <td colspan="3" style="border-bottom:1px solid #8E8F8F">
                                    <asp:Label ID="lblProperty" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr style="display:none;">
                    <td align="center">
                         <b>Existing Record</b>
                        &nbsp;&nbsp;
                        <asp:DropDownList ID="ddlExistingRecord" runat="server" AutoPostBack="true"
                            onselectedindexchanged="ddlExistingRecord_SelectedIndexChanged"></asp:DropDownList>
                        &nbsp;&nbsp;
                        <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
                        &nbsp;<a id="a_Print" visible="false" runat="server" ><img src="../App_Themes/Default/images/Print_plain.gif" /></a>&nbsp;
                        <asp:Label ID="lblMsg" runat="server" Text="..Successful.." ForeColor="Green" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="tableMedicinAdd">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblTakingTime" runat="server" Text="Date: ">
                                        </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtOrderDate" runat="server" Text="">
                                        </asp:TextBox>
                                        <asp:Label ID="Label4" runat="server" Text="MR #: ">
                                        </asp:Label>
                                        <asp:TextBox ID="txtMRno" runat="server" Text="">
                                        </asp:TextBox>
                                        <asp:Label ID="lblMedicineID" runat="server" Text="Physician">
                                        </asp:Label>
                                        <asp:TextBox ID="txtPhysician" runat="server" Text="">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="lblQuality" runat="server" Text="Clinical Findings: ">
                                        </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtClinicalFindings" runat="server" Width="100%" TextMode="MultiLine">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="Label1" runat="server" Text="Order: ">
                                        </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtOrder" runat="server" Width="100%" TextMode="MultiLine">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="Label2" runat="server" Text="Staff notified: ">
                                        </asp:Label>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkSN" runat="server" Text="SN"/>
                                        <asp:CheckBox ID="chkHHA" runat="server" Text="HHA"/>
                                        <asp:CheckBox ID="chkPT" runat="server" Text="PT"/>
                                        <asp:CheckBox ID="chkMSW" runat="server" Text="MSW"/>
                                        <asp:CheckBox ID="chkPATIENT" runat="server" Text="PATIENT"/>
                                        <br />
                                        <asp:CheckBox ID="chkOthers" runat="server" Text="OTHER:"/>
                                        <asp:TextBox ID="txtStaffNotifiedOthers" runat="server" Width="70%" >
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                    </td>
                                    <td>
                                        <asp:Button ID="btnAdd" runat="server" Text="Save" OnClick="btnSave_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class='tableCss'>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gvDoctorsOrder" runat="server" Width="100%" AutoGenerateColumns="false"
                                    ShowHeader="true">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Date">
                                            <ItemTemplate>
                                                <%#Eval("OrderDate","{0:dd MMM yyyy}")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Physician">
                                            <ItemTemplate>
                                                <%#Eval("ExtraField1")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="MR#">
                                            <ItemTemplate>
                                                <%#Eval("ExtraField2")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Clinical Findings">
                                            <ItemTemplate>
                                                <%#Eval("ClinicalFindings")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Order">
                                            <ItemTemplate>
                                                <%#Eval("Orders")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Staff Notified">
                                            <ItemTemplate>
                                                <%#Eval("ExtraField3")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
