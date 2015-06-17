<%@ Page Title="Welcome to Assisted Living" Language="C#" MasterPageFile="~/Default.master"
    AutoEventWireup="true" CodeFile="AdminUserCreate.aspx.cs" Inherits="Admin_AdminUserCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="sidePanelContainer">
        <div class="formPanelHeader">
            <div class="sidePanelContainer">
                Create User
            </div>
            <div class="formPanelContent">
                <table cellspacing="0" id="contentAreaPlaceHolder_formView" class="formView">
                    <tbody>
                        <tr>
                            <td colspan="2">
                                <asp:Label runat="server" ID="lblMessage"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <table >
                <tbody>
                    <tr class="detailsViewRow">
                        <td class="detailsViewFieldHeader">
                            First Name
                        </td>
                        <td>
                            <asp:TextBox ID="txtFirstName" class="txt large-input" Width="200px" runat="server"
                                Text="">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr class="detailsViewRow">
                        <td class="detailsViewFieldHeader">
                            Last Name
                        </td>
                        <td>
                            <asp:TextBox ID="txtLastName" class="txt large-input" Width="200px" runat="server"
                                Text="">
                            </asp:TextBox>
                            <span style="display: none;" class="error" id="contentAreaPlaceHolder_formView_ctl02">
                                Required</span>
                        </td>
                    </tr>
                    <tr class="detailsViewRow">
                        <td class="detailsViewFieldHeader">
                            User Name
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserName" class="txt medium-input" Width="200px" runat="server"
                                Text="">
                            </asp:TextBox>
                            <span style="display: none;" class="error" id="Span2">Required</span>
                        </td>
                    </tr>
                    <tr class="detailsViewRow">
                        <td class="detailsViewFieldHeader">
                            Password
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassword" class="txt large-input" Width="200px" runat="server"
                                Text="">
                            </asp:TextBox>
                            <span style="display: none;" class="error" id="Span1">Required</span>
                        </td>
                    </tr>
                    <tr class="detailsViewRow">
                        <td class="detailsViewFieldHeader">
                            Email
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" class="txt large-input" Width="200px" runat="server" Text="">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr class="detailsViewRow">
                        <td class="detailsViewFieldHeader">
                            Address
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddress" class="txt large-input" Width="200px" runat="server"
                                Text="">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr class="detailsViewRow">
                        <td class="detailsViewFieldHeader">
                            City
                        </td>
                        <td>
                            <asp:TextBox ID="txtCity" runat="server" Width="200px" class="txt large-input"></asp:TextBox>
                        </td>
                    </tr>
                    <tr class="detailsViewRow">
                        <td class="detailsViewFieldHeader">
                            State
                        </td>
                        <td>
                            <asp:TextBox runat="server" class="txt large-input" Width="200px" ID="txtState"></asp:TextBox>
                        </td>
                    </tr>
                    <tr class="detailsViewRow">
                        <td class="detailsViewFieldHeader">
                            Zipcode
                        </td>
                        <td>
                            <asp:TextBox ID="txtZipcode" class="txt large-input" Width="200px" runat="server"></asp:TextBox>
                            &nbsp;
                        </td>
                    </tr>
                    <tr class="detailsViewRow">
                        <td class="detailsViewFieldHeader">
                            Sex
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSex" runat="server">
                                <asp:ListItem Value="m">Male</asp:ListItem>
                                <asp:ListItem Value="f">Female</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr class="detailsViewRow">
                        <td class="detailsViewFieldHeader">
                            <div style="width:200px">Assign Permission To User</div>
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="chckCopyPermission" Text="Copy User Permission"
                                AutoPostBack="True" OnCheckedChanged="chckCopyPermission_CheckedChanged" />
                            <asp:DropDownList runat="server" ID="ddlUserList" Visible="false">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr class="detailsViewRow">
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Button ID="btnSave" class="button button-blue" Height="14px" Width="150px" runat="server"
                                Text="Create" OnClick="btnUpdate_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>

           
        </div>
    </div>
</asp:Content>

