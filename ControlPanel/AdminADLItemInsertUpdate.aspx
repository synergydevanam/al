<%@ Page Language="C#" MasterPageFile="~/Login/AdminMaster.master" AutoEventWireup="true" 
CodeFile="AdminADLItemInsertUpdate.aspx.cs" Inherits="AdminADLItemInsertUpdate" Title="ADLItem Insert/Update By Admin" %>

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
                    <asp:Label ID="lblADLItemName" runat="server" Text="ADLItemName: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtADLItemName" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblADLItemDescriptionID" runat="server" Text="ADLItemDescriptionID: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlADLItemDescription" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblADLStatusID" runat="server" Text="ADLStatusID: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlADLStatus" runat="server">
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
                    <asp:Label ID="lblIteamTime" runat="server" Text="IteamTime: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtIteamTime" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblComment" runat="server" Text="Comment: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtComment" runat="server" Text="">
                    </asp:TextBox>
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
                    <asp:Label ID="lblExtraField6" runat="server" Text="ExtraField6: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField6" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField7" runat="server" Text="ExtraField7: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField7" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField8" runat="server" Text="ExtraField8: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField8" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField9" runat="server" Text="ExtraField9: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField9" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField10" runat="server" Text="ExtraField10: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField10" runat="server" Text="">
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
