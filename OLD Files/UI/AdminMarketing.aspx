<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default.master" CodeFile="AdminMarketing.aspx.cs"
    Inherits="AdminMarketing" Title="Marketing Insert/Update By Admin" %>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="ContentPlaceHolder1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="content-box">
        <div class="header">
            <h3>
                Insert /UpdateMarketing</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblCustomerID" runat="server" Text="Customer: ">
    </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCustomerID" runat="server">
                        </asp:DropDownList>
                    </td>
                    <tr>
                        <td>
                            <asp:Label ID="lblMarketingAgentID" runat="server" Text="Marketing Agent: ">
    </asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMarketingAgentID" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblMarketingCloserID" runat="server" Text="Marketing Closer: ">
    </asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMarketingCloserID" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblMarketingVanueID" runat="server" Text="Marketing Vanue: ">
    </asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMarketingVanueID" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblLeadSourceID" runat="server" Text="Lead Source: ">
    </asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlLeadSourceID" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblGiftID" runat="server" Text="Gift: ">
    </asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlGiftID" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblDepositAmount" runat="server" Text="Deposit Amount: ">
    </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDepositAmount" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblRefundable" runat="server" Text="Refundable: ">
    </asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="radRefundable" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>True</asp:ListItem>
                                <asp:ListItem>False</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblNotes" runat="server" Text="Notes: ">
    </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNotes" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
                            <asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update"
                                OnClick="btnUpdate_Click" Visible="false" />
                        </td>
                    </tr>
            </table>
        </div>
    </div>
</asp:Content>
