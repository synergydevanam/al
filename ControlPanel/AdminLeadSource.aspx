<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default.master" CodeFile="AdminLeadSource.aspx.cs"
    Inherits="AdminLeadSource" Title="LeadSource Insert/Update By Admin" %>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="ContentPlaceHolder1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="content-box">
        <div class="header">
            <h3>
                Insert /UpdateLeadSource</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblLeadSourceName" runat="server" Text="Lead Source Name: ">
            </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLeadSourceName" class="txt large-input" runat="server" Text="">
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
