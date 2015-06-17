<%@ Page Language="C#" MasterPageFile="~/Login/AdminMaster.master" AutoEventWireup="true"
    CodeFile="AdminADLDetailInsertUpdate.aspx.cs" Inherits="AdminADLDetailInsertUpdate"
    Title="ADLDetail Insert/Update By Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .tableCss
        {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="tableCss">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblADLDetailName" runat="server" Text="ADLDetailName: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtADLDetailName" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr style="display: none;">
                <td>
                    <asp:Label ID="lblExtraField1" runat="server" Text="ExtraField1: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField1" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr style="display: none;">
                <td>
                    <asp:Label ID="lblExtraField2" runat="server" Text="ExtraField2: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField2" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr style="display: none;">
                <td>
                    <asp:Label ID="lblExtraField3" runat="server" Text="ExtraField3: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField3" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr style="display: none;">
                <td>
                    <asp:Label ID="lblExtraField4" runat="server" Text="ExtraField4: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField4" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr style="display: none;">
                <td>
                    <asp:Label ID="lblExtraField5" runat="server" Text="ExtraField5: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField5" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" Visible="false"/>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
