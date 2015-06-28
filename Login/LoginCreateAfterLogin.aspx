<%@ Page Language="C#" MasterPageFile="AdminMaster.master" AutoEventWireup="true"
    CodeFile="LoginCreateAfterLogin.aspx.cs" Inherits="AdminLoginInsertUpdate" Title="Login Insert/Update By Admin" %>

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
        <h1>
            Add / Update User</h1>
        <table>
            <tr>
                <td valign="top">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblFirstName" runat="server" Text="FirstName: ">
                    </asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFirstName" runat="server" Text="">
                    </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblMiddleName" runat="server" Text="MiddleName: ">
                    </asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMiddleName" runat="server" Text="">
                    </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblLastName" runat="server" Text="LastName: ">
                    </asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtLastName" runat="server" Text="">
                    </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Initial: ">
                    </asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtInitial" runat="server" Text="">
                    </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblLoginName" runat="server" Text="LoginName: ">
                    </asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtLoginName" runat="server" Text="">
                    </asp:TextBox>
                                <asp:HiddenField ID="hfLoginName" runat="server" />
                            </td>
                        </tr>
                        <tr id="trPasswordEmptyMessage" runat="server">
                            <td colspan="2">
                                <p>
                                    If you dont want to change password
                                    <br />
                                    then keep Password fields Empty</p>
                            </td>
                        </tr>
                        <tr id="trOldPassword" runat="server">
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Old Password: ">
                    </asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtOldPassword" runat="server" Text="" TextMode="Password">
                    </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblPassword" runat="server" Text="Password: ">
                    </asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPassword" runat="server" Text="" TextMode="Password">
                    </asp:TextBox>
                                <asp:HiddenField ID="hfPassword" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label1" runat="server" Text="Confirm Password: ">
                    </asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPasswordConfirm" TextMode="Password" runat="server" Text="">
                    </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="lblEmail" runat="server" Text="Email: ">
                    </asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server" Text="">
                    </asp:TextBox>
                            </td>
                        </tr>
                        
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Address: ">
                    </asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDetails" runat="server" Text="">
                    </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCellPhone" runat="server" Text="CellPhone: ">
                    </asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCellPhone" runat="server" Text="">
                    </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblHomePhone" runat="server" Text="HomePhone: ">
                    </asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtHomePhone" runat="server" Text="">
                    </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblWorkPhone" runat="server" Text="WorkPhone: ">
                    </asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtWorkPhone" runat="server" Text="">
                    </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblRowStatusID" runat="server" Text="RowStatusID: ">
                    </asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlRowStatus" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Defaul Page: ">
                    </asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlMenuID" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        
                    </table>
                    <table ID="tbluserType" runat="server" visible="false">
                        <tr>
                            <td>Type</td>
                            <td>
                                <asp:RadioButtonList ID="rbtnUserType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rbtnUserType_SelectedIndexChanged" RepeatDirection="Horizontal" >
                                    <asp:ListItem Value="MainUser">Main User</asp:ListItem>
                                    <asp:ListItem Value="OtherUser" Selected="True">Other User</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            </tr>
                        <tr  ID="trMainUser" runat="server" visible="false">
                            <td></td>
                            <td>
                                <asp:DropDownList ID="ddlLogin" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <table ID="tblMainUser" runat="server"  visible="false">
                        <tr>
                    <td>No. of Resident(s)
                       </td>
                
                    <td>
                        <asp:TextBox ID="txtResidentNumber"  onkeyup="calculation()" runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Registration Fee
                       </td>
                
                    <td><asp:TextBox ID="txtRegistrationFee" runat="server" Enabled="false" Text="$199"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td>Discount(If TORCH Member)
                       </td>
                    <td><asp:TextBox ID="txtDiscount" runat="server" Enabled="false" Text="$100"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td>Total Amount
                       </td>
                    <td><asp:TextBox ID="txtTotalAmount" runat="server" Enabled="false" Width="100%" Font-Bold="true"></asp:TextBox>
                        </td>
                </tr>
                <tr style="display:none;">
                    <td>Card Type
                       </td>
                    <td>
                        <asp:DropDownList ID="ddlCardType" runat="server">
                            <asp:ListItem Value="MasterCard">MasterCard</asp:ListItem>
                            <asp:ListItem Value="Visa">Visa</asp:ListItem>
                            <asp:ListItem Value="Discover">Discover</asp:ListItem>
                            <asp:ListItem Value="American Express">American Express</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                </tr>
                <tr style="display:none;">
                    <td>Name on Card
                       </td>
                   <td>
                        <asp:TextBox ID="txtCardHolderName"   runat="server"></asp:TextBox>
                        </td>
                </tr>
                <tr style="display:none;">
                    <td>Card No.
                       </td>
                    <td>
                        <asp:TextBox ID="txtCardNO"  runat="server"  ></asp:TextBox>
                        </td>
                </tr>
                <tr style="display:none;">
                    <td>Expire Date</td>
                    <td>
                        <asp:TextBox ID="txtExpireDate"  runat="server" placeholder="MM/yyyy" ></asp:TextBox>
                        </td>
                </tr>
                <tr style="display:none;">
                    <td>Security Code
                   
                       </td>
                    <td>
                        <asp:TextBox ID="txtCSC"  runat="server"  ></asp:TextBox>
                        </td>
                </tr>

                    </table>
                    <table>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" ValidationGroup="CreateUserWizard1" />
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="CreateUserWizard1"
                                    OnClick="btnUpdate_Click" />
                                <asp:Button ID="btnClear" runat="server" Text="Clear" Visible="false" OnClick="btnClear_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td valign="top">
                    <table>
                        <%--<tr>
                            <td>
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                                <br />
                            </td>
                        </tr>--%>
                        <tr>
                            <td>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ValidationGroup="CreateUserWizard1"
                                    Style="width: 100%; text-align: center;" ErrorMessage="Password and Confrim Password Does not match"
                                    ControlToCompare="txtPassword" ControlToValidate="txtPasswordConfirm"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Style="width: 100%;
                                    text-align: center;" runat="server" ControlToValidate="txtEmail" ErrorMessage="Not a Valid Email Address"
                                    SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    ValidationGroup="CreateUserWizard1"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table border="0" cellpadding="10" cellspacing="5">
                                <tr>
                                    <td>
                                        Role
                                    </td>
                                </tr>
                                    <tr>
                                        <td valign="top">
                                            <asp:DataList ID="dlRole" runat="server">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSelect" runat="server" Text='<%#Eval("RoleName") %>' ToolTip='<%#Eval("RoleID") %>' />
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </td>
                                    </tr>
                                    <tr>
                                    <td>
                                        Property
                                    </td>
                                </tr>
                                    <tr>
                                        <td valign="top">
                                            <asp:DataList ID="dlProperty" runat="server">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSelect" runat="server" Text='<%#Eval("Address") %>'
                                                                ToolTip='<%#Eval("PropertyID") %>' />
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
