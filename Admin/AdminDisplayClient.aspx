<%@ Page Title="" Language="C#" MasterPageFile="~/WithoutLeftMenu.master" AutoEventWireup="true" CodeFile="AdminDisplayClient.aspx.cs" Inherits="Admin_AdminDisplayClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <link href="../css/jquery-ui-1.8.20.custom.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery.ui.timepicker.js" type="text/javascript"></script>
    <script src="../js/jquery-ui-1.8.20.custom.min.js" type="text/javascript"></script>
    <link href="../css/jquery.ui.timepicker.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        jQuery(document).ready(function ($) {
            var dates = $("#ctl00_ContentPlaceHolder1_txtDateFrom,#ctl00_ContentPlaceHolder1_txtDateTo").datepicker({
                defaultDate: "+1w",
                changeMonth: true,
                numberOfMonths: 1
            });


        });
        function Validatedate() {

            if ($("#ctl00_ContentPlaceHolder1_txtDateFrom").val() != "") {

                if ($("#ctl00_ContentPlaceHolder1_txtDateTo").val() != "") {

                    var FromDate = new Date(Date.parse($("#ctl00_ContentPlaceHolder1_txtDateFrom").val(), "MM/dd/yyyy"));
                    var ToDate = new Date(Date.parse($("#ctl00_ContentPlaceHolder1_txtDateTo").val(), "MM/dd/yyyy"));

                    if (FromDate > ToDate) {


                        alert("Appt From date cant be smaller than Appt To date")
                        return false;
                    }
                    else {
                        return true;
                    }

                } else { return true; }
            }
            else { return true; }

        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <div class="content-box">
        <table cellspacing="10px;">
            <tr>
                
                <td>
                    <asp:Label runat="server" ID="lblDateForm" Text="Appt Date From"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDateFrom" Width="80px" runat="server" Text="">  </asp:TextBox>
                </td>
                <td>
                    <asp:Label runat="server" ID="lblDateTo" Text="Appt Date To"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDateTo" Width="80px" runat="server" Text="">
                    </asp:TextBox>
                </td>
                <td>
                    <asp:Button runat="server" ID="btnSearch" Text="Search" OnClientClick="return Validatedate();"
                        OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>
        <div class="header">
            <div class="formPanelHeader">
                <div class="sidePanelContainer">
                    <h3>
                        Customer Appoinment Information</h3>
                    <h4>
                        <asp:Label runat="server" ID="lbltotalRecord"></asp:Label></h4>
                </div>
            </div>
        </div>
        <div class="inner-content_Manifest">
            <asp:GridView ID="gvClient" runat="server" AutoGenerateColumns="false" AlternatingRowStyle-CssClass="even"
                HeaderStyle-CssClass="grid_head_css"  CssClass="grid"
                OnRowDataBound="gvClient_RowDataBound">
                <HeaderStyle BackColor="#DFEAF5" />
                <Columns>
                   
                   
                    <asp:TemplateField HeaderText="First Name">
                        <HeaderStyle Width="80px" />
                        <ItemTemplate>
                            <asp:Label ID="lblFirstName" runat="server" Text='<%#Eval("FirstName") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Last Name">
                        <HeaderStyle Width="80px" />
                        <ItemTemplate>
                            <asp:Label ID="lblLastName" runat="server" Text='<%#Eval("LastName") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Age">
                        <ItemTemplate>
                            <asp:Label ID="lblAge" runat="server" Text='<%#Eval("Age") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Primary Phone">
                        <HeaderStyle Width="110px" />
                        <ItemStyle VerticalAlign="Top" />
                        <ItemTemplate>
                            <asp:Label ID="lblPrimaryPhone" runat="server" Text='<%#Eval("PrimaryPhone") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Address 1">
                        <HeaderStyle Width="80px" />
                        <ItemStyle VerticalAlign="Top" />
                        <ItemTemplate>
                            <asp:Label ID="lblAddress1" runat="server" Text='<%#Eval("Address1") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Appt Date">
                        <HeaderStyle Width="80px" />
                        <ItemTemplate>
                            <asp:Label ID="lblApptDate" runat="server" Text='<%# Eval("MaxTime", "{0:MM-dd-yyyy}") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Appt Time">
                        <HeaderStyle Width="80px" />
                        <ItemTemplate>
                            <asp:Label ID="lblApptTime" runat="server" Text='<%# Eval("MaxTime", "{0:t}") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status">
                        <HeaderStyle Width="40px" />
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="lblAppStatus" runat="server" Text='<%#Eval("StastusID") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                  
                    <asp:TemplateField HeaderText="Operation">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lbSelect"><a href="../Customer/CustomerInsert.aspx?ID=<%#Eval("CustomerID") %>" ><img src="../App_Themes/CoffeyGreen/images/icon-pencil.png" /> </a></asp:Label>
                            <%-- 	 <asp:ImageButton runat="server" ID="lbDelete"  CommandArgument='<%#Eval("ClientID") %>' OnClick="lbDelete_Click"  AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png"
 	  />--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div class="paging">
                <div class="viewpageinfo">
                    <%--View 1 -10 of 13--%>
                    Show
                    <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageSize_Changed">
                        <asp:ListItem Text="10" Value="10" />
                        <asp:ListItem Text="25" Selected="True" Value="25" />
                        <asp:ListItem Text="50" Value="50" />
                    </asp:DropDownList>
                </div>
                <div id="pagination">
                    <asp:Repeater ID="rptPager" runat="server">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
