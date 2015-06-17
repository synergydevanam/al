<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default.master" CodeFile="DisplayCustomer.aspx.cs"
    Inherits="DisplayCustomer" Title="Customer Insert/Update By Admin" %>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="ContentPlaceHolder1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="content-box">
        <div class="header">
            <h3>
                View Data Customer</h3>
        </div>
        <div class="inner-content">
            <asp:GridView ID="gvCustomer" AlternatingRowStyle-CssClass="even" HeaderStyle-CssClass="grid_head_css"
                CssClass="grid" runat="server" AutoGenerateColumns="false" 
                onrowdatabound="gvCustomer_RowDataBound">
                <HeaderStyle BackColor="#DFEAF5" />
                
                <Columns>
                   <asp:TemplateField HeaderText="First Name">
                       <HeaderStyle Width="120px" />
                       <ItemStyle VerticalAlign="Top" />
                        <ItemTemplate>
                            <asp:Label ID="lblFirstName" runat="server" Text='<%#Eval("FirstName") %>'> </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Last Name">
                        <HeaderStyle Width="100px" />
                        <ItemStyle VerticalAlign="Top" />
                        <ItemTemplate>
                            <asp:Label ID="lblLastName" runat="server" Text='<%#Eval("LastName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Age">
                        <HeaderStyle Width="40px" />
                        <ItemStyle VerticalAlign="Top" />
                        <ItemTemplate>
                            <asp:Label ID="lblAge" runat="server" Text='<%#Eval("Age") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Guest Name">
                        <HeaderStyle Width="120px" />
                        <ItemStyle VerticalAlign="Top" />
                        <ItemTemplate>
                            <asp:Label ID="lblGuestName" runat="server" Text='<%#Eval("GuestName") %>'></asp:Label>
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
                   
         
                    <asp:TemplateField HeaderText="Business">
                        <ItemStyle VerticalAlign="Top" />
                        <ItemTemplate>
                            <asp:Label ID="lblBusiness" runat="server" Text='<%#Eval("Business") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email">
                        <ItemStyle VerticalAlign="Top" />
                        <ItemTemplate>
                            <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tour Status">
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle Width="80px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="lblTourStatusName" runat="server" Text='<%#Eval("TourStatusName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Operation">
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle Width="80px" VerticalAlign="Top" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("CustomerID") %>'
                                AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />&nbsp;&nbsp;
                            <asp:ImageButton runat="server" ID="lbDelete" CommandArgument='<%#Eval("CustomerID") %>'
                                OnClick="lbDelete_Click" AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
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
                        <asp:ListItem Text="25" Value="25" />
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
