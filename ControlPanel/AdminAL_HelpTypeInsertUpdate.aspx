<%@ Page Language="C#" MasterPageFile="~/login/AdminMaster.master" AutoEventWireup="true" 
CodeFile="AdminAL_HelpTypeInsertUpdate.aspx.cs" Inherits="AdminAL_HelpTypeInsertUpdate" Title="AL_HelpType Insert/Update By Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .tableCss
        {
        	text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="tableCss">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblHelpTypeName" runat="server" Text="Help Type: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtHelpTypeName" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" 
                        OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnClear" runat="server" Text="Clear" Visible="false" OnClick="btnClear_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
