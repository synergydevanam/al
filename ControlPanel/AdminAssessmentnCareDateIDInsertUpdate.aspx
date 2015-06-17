<%@ Page Language="C#" MasterPageFile="~/Login/AdminMaster.master" AutoEventWireup="true" 
CodeFile="AdminAssessmentnCareDateIDInsertUpdate.aspx.cs" Inherits="AdminAssessmentnCareDateIDInsertUpdate" Title="AssessmentnCareDateID Insert/Update By Admin" %>

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
                    <asp:Label ID="lblAssessmentnCareDate" runat="server" Text="AssessmentnCareDate: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAssessmentnCareDate" runat="server" Text="">
                    </asp:TextBox>
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
