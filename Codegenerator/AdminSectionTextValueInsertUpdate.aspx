<%@ Page Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" 
CodeFile="AdminSectionTextValueInsertUpdate.aspx.cs" Inherits="AdminSectionTextValueInsertUpdate" Title="SectionTextValue Insert/Update By Admin" %>

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
                    <asp:Label ID="lblCarePlanDateTimeID" runat="server" Text="CarePlanDateTimeID: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlCarePlanDateTime" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSection_2" runat="server" Text="Section_2: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSection_2" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSection_3" runat="server" Text="Section_3: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSection_3" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSection_6" runat="server" Text="Section_6: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSection_6" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSection_7" runat="server" Text="Section_7: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSection_7" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblAddedBy" runat="server" Text="AddedBy: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAddedBy" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblUpdatedBy" runat="server" Text="UpdatedBy: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUpdatedBy" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblUpdatedDate" runat="server" Text="UpdatedDate: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUpdatedDate" runat="server" Text="">
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
