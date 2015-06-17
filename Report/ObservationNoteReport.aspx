<%@ Page Title="" Language="C#" MasterPageFile="~/WithoutLeftMenu.master" AutoEventWireup="true"
    CodeFile="ObservationNoteReport.aspx.cs" Inherits="Resident_ADLRecord" %>
<%@ Register src="../control/DataEntryControlResidentInfo.ascx" tagname="DataEntryControlResidentInfo" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <link href="../css/jquery-ui-1.8.20.custom.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery.ui.timepicker.js" type="text/javascript"></script>
    <script src="../js/jquery-ui-1.8.20.custom.min.js" type="text/javascript"></script>
    <link href="../css/jquery.ui.timepicker.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        jQuery(document).ready(function ($) {
            var datesFrom = $('#<%= txtDateFrom.ClientID %>').datepicker({
                defaultDate: "+1w",
                changeMonth: true,
                changeYear: true,
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
            var datesto = $('#<%= txtDateTo.ClientID %>').datepicker({
                defaultDate: "+1w",
                changeMonth: true,
                changeYear: true,
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
            padding: 5px;
        }
        .tableCss th
        {
            padding: 5px;
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
                        Observation Log Report
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <div class="tableMedicinAdd">
                            <table>
                                <tr>
                                    <td>
                                         Date:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDateFrom" runat="server" Text="" Width="100px">
                                        </asp:TextBox>
                                        <asp:Label ID="Label4" runat="server" Text="To: ">
                                        </asp:Label>
                                        <asp:TextBox ID="txtDateTo" runat="server" Text="" Width="100px">
                                        </asp:TextBox>
                                        Format : MM/dd/yyyy
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td valign="top">
                                    </td>
                                    <td>
                                            <%--<asp:ImageButton ID="btnAdd" OnClick="btnAdd_Click" runat="server" ImageUrl="../App_Themes/Default/images/save.png" />--%>
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" onclick="btnSearch_Click" />
                                        <%--<asp:Button ID="btnAdd" runat="server" Text="Add Observation" OnClick="btnAdd_Click" />--%>
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
                                <asp:Label ID="lblPrint" runat="server" Text=""></asp:Label>
                                <%--<asp:GridView ID="gvObservationNote" runat="server" Width="100%" AutoGenerateColumns="false"
                                    ShowHeader="true">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Resident">
                                            <ItemTemplate>
                                                <%#Eval("Name")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date">
                                            <ItemTemplate>
                                                <%#Eval("AddedDate","{0:dd MMM yyyy}")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Time">
                                            <ItemTemplate>
                                                <%#Eval("AddedDate","{0:hh:mm tt}")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Made By">
                                            <ItemTemplate>
                                                <%#Eval("ExtraField1")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Type">
                                            <ItemTemplate>
                                                <%#Eval("ExtraField3")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Observation / Comment" ItemStyle-Width="500px">
                                            <ItemTemplate>
                                               <%#Eval("Note")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>--%>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
    </div>

   
</asp:Content>
