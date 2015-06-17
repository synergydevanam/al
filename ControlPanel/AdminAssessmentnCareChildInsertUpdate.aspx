<%@ Page Language="C#" MasterPageFile="~/Login/AdminMaster.master" AutoEventWireup="true" 
CodeFile="AdminAssessmentnCareChildInsertUpdate.aspx.cs" Inherits="AdminAssessmentnCareChildInsertUpdate" Title="AssessmentnCareChild Insert/Update By Admin" %>

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
                    <asp:Label ID="lblAssessmentnCareParentID" runat="server" Text="Header: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlAssessmentnCareParent" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblAssessmentnCareChildName" runat="server" Text="Detail: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAssessmentnCareChildName" runat="server" Text="">
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
               
                    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
