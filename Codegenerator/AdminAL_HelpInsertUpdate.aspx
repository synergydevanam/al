<%@ Page Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" 
CodeFile="AdminAL_HelpInsertUpdate.aspx.cs" Inherits="AdminAL_HelpInsertUpdate" Title="AL_Help Insert/Update By Admin" %>

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
                    <asp:Label ID="lblHelpTypeID" runat="server" Text="HelpTypeID: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlHelpType" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblQuestion" runat="server" Text="Question: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtQuestion" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblAnswer" runat="server" Text="Answer: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAnswer" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" 
                        OnClick="btnUpdate_Click" />
                </td>
                <td>
                    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
