<%@ Page Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" 
CodeFile="AdminMedicineTimenDateInsertUpdate.aspx.cs" Inherits="AdminMedicineTimenDateInsertUpdate" Title="MedicineTimenDate Insert/Update By Admin" %>

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
                    <asp:Label ID="lblMedicationTimeID" runat="server" Text="MedicationTimeID: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlMedicationTime" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMedicineDate" runat="server" Text="MedicineDate: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMedicineDate" runat="server" Text="">
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
