<%@ Page Title="" Language="C#" MasterPageFile="~/WithoutLeftMenuPrint.master" AutoEventWireup="true"
    CodeFile="Medication_MonthlyPrint.aspx.cs" Inherits="Resident_ADLRecord" %>

<%@ Register Src="../control/PrintingControlResidentInfo.ascx" TagName="PrintingControlResidentInfo"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .reportTable td, .reportTable
        {
            border: 1px solid black;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="single_colom">
        <div style="padding: 20px;">
            <table width="100%">
                <tr align="center">
                    <td align="center">
                        <uc1:PrintingControlResidentInfo ID="PrintingControlResidentInfo1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlMonths" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMonths_SelectedIndexChanged">
                                </asp:DropDownList>
                                &nbsp;&nbsp;
                                <asp:DropDownList ID="ddlYears" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlYears_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlMedicationList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlYears_SelectedIndexChanged">
                                    <asp:ListItem Value="All">All Medicaiton</asp:ListItem>
                                    <asp:ListItem Value="PRN">PRN only</asp:ListItem>
                                    <asp:ListItem Value="Scheduled">Scheduled only</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlShowStaus" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlShowStaus_SelectedIndexChanged">
                                    <asp:ListItem Value="Active" Text="Active only"></asp:ListItem>
                                    <asp:ListItem Value="Inactive" Text="Inactive only"></asp:ListItem>
                                    <asp:ListItem Value="All" Text="All"></asp:ListItem>
                                </asp:DropDownList>
                                <br />
                                <asp:Label ID="lblMonthlyPrint" runat="server" Text=""></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <table cellspacing="10" border="0" cellpadding="0">
                            <tr>
                                <td style="font-weight: bold;" colspan="4">
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; text-align: right;">
                                    Caregiver(s)
                                </td>
                                <td colspan="3" style="border-bottom: 1px solid #8E8F8F; width: 700px; text-align: left;">
                                    <asp:Label ID="lblCareGiver" runat="server" Text=""></asp:Label>
                                </td>
                                
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; text-align: right;">
                                    Nurse’s Signature
                                </td>
                                <td style="border-bottom: 1px solid #8E8F8F; width: 300px; text-align: left;">
                                </td>
                                <td style="font-weight: bold; text-align: right;">
                                    Date & Time
                                </td>
                                <td style="border-bottom: 1px solid #8E8F8F; width: 300px; text-align: left;">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
