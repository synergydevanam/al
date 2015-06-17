<%@ Page Title="" Language="C#" MasterPageFile="~/WithoutLeftMenu.master" AutoEventWireup="true"
    CodeFile="ADLRecord.aspx.cs" Inherits="Resident_ADLRecord" %>

<%@ Register Src="../control/DataEntryControlResidentInfo.ascx" TagName="DataEntryControlResidentInfo"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <link href="../css/jquery-ui-1.8.20.custom.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery.ui.timepicker.js" type="text/javascript"></script>
    <script src="../js/jquery-ui-1.8.20.custom.min.js" type="text/javascript"></script>
    <link href="../css/jquery.ui.timepicker.css" rel="stylesheet" type="text/css" />
    <%--<script type="text/javascript">
        jQuery(document).ready(function ($) {

            var datess = $('#<%= txtTakingTime.ClientID %>').timepicker({
                showPeriod: true,
                showLeadingZero: true
            });
        });
       
    </script>--%>
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
                        ADL Record
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc1:DataEntryControlResidentInfo ID="DataEntryControlResidentInfo1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <div class="tableMedicinAdd">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td align="center">
                                                <span style="font-size: 20px;">Setup ADL</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td valign="middle">
                                                            <b>Header</b> 
                                                        </td>
                                                        <td valign="middle">
                                                            <asp:DropDownList ID="ddlADLHeader" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlADLHeader_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td valign="middle">
                                                            &nbsp;&nbsp;
                                                            <asp:ImageButton ID="btnSaveNewADL" OnClick="btnSaveNewADL_Click" runat="server" ImageUrl="../App_Themes/Default/images/save.png" />
                                                        </td>
                                                        <td valign="middle">
                                                            <asp:Label ID="lblNewADLSaveMessage" runat="server" Text="Saved Successfully" ForeColor="Green"
                                                                Visible="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                               
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DataList ID="dlADLDetail" runat="server" RepeatColumns="5" RepeatDirection="Horizontal">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSelect" runat="server" Text='<%#Eval("ADLDetailName") %>' ValidationGroup='<%#Eval("ADLDetailID") %>' />
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <span style="font-size: 20px; text-align: left;">Manage Daily ADL</span>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
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
                                            <asp:Label ID="lblMsg" runat="server" Text="Saved Successfully" ForeColor="Green"
                                                Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:DropDownList ID="ddlADLStatus" runat="server" Visible="false">
                        </asp:DropDownList>
                        <asp:RadioButtonList ID="rbtnlADLStatus" runat="server" Visible="false">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <a id="a_Report" runat="server" style="text-decoration: underline; color: Blue;">Monthly
                            ADL Report</a>
                    </td>
                </tr>
                <tr>
                    <td class='tableCss' align="center">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gvHeader" runat="server" AutoGenerateColumns="false" ShowHeader="true">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ADL Record">
                                            <ItemTemplate>
                                                <table>
                                                    <tr>
                                                        <td colspan="2" align="left" style="padding-top: 10px;">
                                                            <b>
                                                                <%#Eval("ADLHeaderName")%></b>
                                                            <asp:HiddenField ID="hfADLHeaderID" runat="server" Value='<%#Eval("ADLHeaderID")%>' />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 20px">
                                                        </td>
                                                        <td>
                                                            <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="false" ShowHeader="true">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="ADL" ItemStyle-Width="150px">
                                                                        <ItemTemplate>
                                                                            <div style="display: none;">
                                                                                <asp:CheckBox ID="chkSelect" runat="server" Text='<%#Eval("ADLDetailName")%>' ValidationGroup='<%#Eval("ExtraField1")%>' /></div>
                                                                            <%#Eval("ADLDetailName")%>
                                                                            <asp:HiddenField ID="hfADLHeaderDetialID" runat="server" Value='<%#Eval("ExtraField1")%>' />
                                                                            <asp:HiddenField ID="hfADLDetailID" runat="server" Value='<%#Eval("ADLDetailID")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Status">
                                                                        <ItemTemplate>
                                                                            <table>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:RadioButtonList ID="rbtnlADLStatusInGrid" runat="server" RepeatDirection="Horizontal"
                                                                                            RepeatColumns="5">
                                                                                        </asp:RadioButtonList>
                                                                                        <asp:DropDownList ID="ddlADLStatusInGrid" runat="server" Visible="false">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td valign="bottom" style="display: none;">
                                                                                        <asp:TextBox ID="txtNewStatus" runat="server"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remark">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Height="22px"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Saved By">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSavedBy" runat="server" Text=""></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
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
