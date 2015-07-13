﻿<%@ Page Title="" Language="C#" MasterPageFile="~/WithoutLeftMenu.master" AutoEventWireup="true"
    CodeFile="DoctorsOrder.aspx.cs" Inherits="Resident_ADLRecord" %>
    <%@ Register src="../control/DataEntryControlResidentInfo.ascx" tagname="DataEntryControlResidentInfo" tagprefix="uc1" %>

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
            <table width="100%">
                <tr>
                    <td align="center" style="text-align: center; font-size: 20px; font-weight: bold;">
                        Doctor's Order
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc1:DataEntryControlResidentInfo ID="DataEntryControlResidentInfo1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                          <table>
                                    <tr>
                                        <td valign="middle">
                                            <b>Existing Record</b> &nbsp;&nbsp;
                                        </td>
                                        <td valign="middle">
                                            <asp:DropDownList ID="ddlExistingRecord" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlExistingRecord_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td valign="middle">
                                            &nbsp;&nbsp;
                                            <asp:ImageButton ID="btnSave" OnClick="btnSave_Click" runat="server" ImageUrl="../App_Themes/Default/images/save.png" />
                                        </td>
                                        <td valign="middle">
                        &nbsp;<a id="a_Print" visible="false" runat="server" ><img src="../App_Themes/Default/images/Print_plain.png" /></a>&nbsp;
                                            <asp:Label ID="lblMsg" runat="server" Text="Saved Successfully" ForeColor="Green"
                                                Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
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
                                        <%--<asp:Button ID="btnAdd" runat="server" Text="Save" OnClick="btnSave_Click" />--%>
                                    <asp:ImageButton ID="btnAdd" OnClick="btnSave_Click" runat="server" ImageUrl="../App_Themes/Default/images/save.png" />
                                        </td>
                                </tr>
                            </table>
                            <div class="sub_form" id="fileUpload" runat="server">
            <table width="100%">
                <tr>
                    <td>
                        <p>
                            Document Upload</p>
                    </td>
                    <td style="float: right; padding-right: 8px;">
                        <p>
                            <asp:Label ID="Label3" runat="server" ForeColor="Green" Text="Upload Successfully"
                                Visible="false"></asp:Label>
                            <asp:Button ID="Button1" runat="server" Text="Add" OnClick="btnUpload_Click" class="add_btn" />
                            <%--<asp:Button ID="Button2" runat="server" Text="Update" class="add_btn" Visible="false"
                                OnClick="btnUpload_Click" />--%>
                            <%--<asp:Button ID="Button4" runat="server" Text="Clear" class="add_btn" Visible="false"
                                OnClick="btnClear_Click" />--%>
                        </p>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <ul>
                            <li class="text_box">Select File </li>
                            <li class="text_input1">
                                <asp:FileUpload ID="uplFile" runat="server" onchange="checkFileExtension(this);" />
                            </li>
                            </ul>
                            </td>
                            </tr>
                <tr>
                    <td> <ul>
                            <li class="text_box">File Description </li>
                            <li class="text_input1">
                                <asp:TextBox ID="txDocumentDetails" runat="server" Text=""></asp:TextBox>
                            </li>
                        </ul>
                    </td>
                </tr>
                <tr>
                    <td>
            <asp:GridView ID="gvDocument" runat="server" AutoGenerateColumns="false"  HeaderStyle-CssClass="grid_head_css"  CssClass="grid">
                <HeaderStyle BackColor="#DFEAF5" />
                <Columns>
                    <%--<asp:TemplateField HeaderText="No">
                        <ItemTemplate>
                            <asp:Label ID="lblDocumentID" runat="server" Text='<%#Eval("DocumentID") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Description">
                        <ItemTemplate>
                            <asp:Label ID="lblDetails" runat="server" Text='<%#Eval("Details") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Document">
                        <ItemTemplate>
                            <span>
                                <a  style="color:Blue;text-decoration:underline;" href='<%#Eval("FileName") %>' target="_blank">View</a>
                            <%--<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#Eval("FileName") %>'
                                Target="_blank" Text="View"></asp:HyperLink>--%></span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                             <asp:LinkButton ID="lbSelect" runat="server" ToolTip='<%#Eval("FileName") %>' CommandArgument='<%#Eval("DocumentID") %>' OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="lbSelect_Click">
                            Delete
                        </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </td>
                </tr>
            </table>
        </div>
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
