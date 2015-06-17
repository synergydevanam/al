<%@ Page Language="C#" MasterPageFile="~/Login/AdminMaster.master" AutoEventWireup="true" 
CodeFile="AdminAssessmentnCareCommentnDateInsertUpdate.aspx.cs" Inherits="AdminAssessmentnCareCommentnDateInsertUpdate" Title="AssessmentnCareCommentnDate Insert/Update By Admin" %>

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
                    <asp:Label ID="lblAssessmentnCareDateID" runat="server" Text="AssessmentnCareDateID: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlAssessmentnCareDate" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblAssessmentnCareParentID" runat="server" Text="AssessmentnCareParentID: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlAssessmentnCareParent" runat="server">
                    </asp:DropDownList>
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
