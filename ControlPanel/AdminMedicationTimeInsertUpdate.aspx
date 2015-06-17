<%@ Page Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" 
CodeFile="AdminMedicationTimeInsertUpdate.aspx.cs" Inherits="AdminMedicationTimeInsertUpdate" Title="MedicationTime Insert/Update By Admin" %>

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
                    <asp:Label ID="lblTakingTime" runat="server" Text="TakingTime: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTakingTime" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMedicineID" runat="server" Text="MedicineID: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlMedicine" runat="server">
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
                    <asp:Label ID="lblQuantity" runat="server" Text="Quantity: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtQuantity" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblQuality" runat="server" Text="Quality: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtQuality" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblFrequency" runat="server" Text="Frequency: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFrequency" runat="server" Text="">
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
                    <asp:Label ID="lblUpdateBy" runat="server" Text="UpdateBy: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUpdateBy" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblUpdateDate" runat="server" Text="UpdateDate: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUpdateDate" runat="server" Text="">
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
