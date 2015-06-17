<%@ Page Language="C#" MasterPageFile="~/Login/AdminMaster.master" AutoEventWireup="true"
    CodeFile="ADLDetailnStatus.aspx.cs" Inherits="AdminADLDetailnStatusInsertUpdate"
    Title="ADLDetailnStatus Insert/Update By Admin" %>

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
                    <asp:Label ID="lblADLDetailID" runat="server" Text="ADL Detail: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlADLDetail" runat="server" AutoPostBack="true" 
                        onselectedindexchanged="ddlADLDetail_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblADLStatusID" runat="server" Text="ADL Status: " >
                    </asp:Label>
                </td>
                <td>
                    <asp:DataList ID="dlStatus" runat="server"  RepeatColumns="5" RepeatDirection="Horizontal">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" Text='<%#Eval("ADLStatusName") %>' ValidationGroup='<%#Eval("ADLStatusID") %>'/>
                        </ItemTemplate>
                    </asp:DataList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text="Add"  Visible="false"/>
                </td>
                <td>
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click"  Visible="false"/>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
