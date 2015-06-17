<%@ Page Language="C#" MasterPageFile="~/Login/AdminMaster.master" AutoEventWireup="true" 
CodeFile="AdminADLHeaderDetailInsertUpdate.aspx.cs" Inherits="AdminADLHeaderDetailInsertUpdate" Title="ADLHeaderDetail Insert/Update By Admin" %>

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
                    <asp:Label ID="lblADLDetailID" runat="server" Text="ADLDetailID: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlADLDetail" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblADLHeaderID" runat="server" Text="ADLHeaderID: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlADLHeader" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblResidentID" runat="server" Text="ResidentID: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlResident" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField1" runat="server" Text="ExtraField1: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField1" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField2" runat="server" Text="ExtraField2: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField2" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField3" runat="server" Text="ExtraField3: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField3" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField4" runat="server" Text="ExtraField4: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField4" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
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
