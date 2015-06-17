<%@ Page Title="Welcome to Assisted Living" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="AdminDisplayFormRights.aspx.cs" Inherits="Admin_AdminDisplayFormRights" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
    <div class="content-box">
        <div class="header">
            <h3>
                User Form Rights</h3>
          
        </div>
    
      
        <div class="inner-content">
            Select user: <asp:DropDownList runat="server" ID="ddlUsers" AutoPostBack="True" OnSelectedIndexChanged="ddlUsers_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:Button runat="server" ID="btnSave" CssClass="button" Height="13px" Width="100px" Text="Save" OnClick="btnSave_Click" /><br />
        <br />
            <asp:GridView ID="gvFormRights" runat="server" AutoGenerateColumns="false" ShowFooter="true" AlternatingRowStyle-CssClass="even"
                CssClass="grid">
                <HeaderStyle BackColor="#DFEAF5" />
                <Columns>
                    <asp:TemplateField HeaderText="Form Name" HeaderStyle-Width="170">
                        <ItemTemplate>
                            <asp:Label ID="lblFormID" runat="server" Text='<%#Eval("FormsID") %>'>
                            </asp:Label>
                            <asp:Label ID="lblFormPrefix" runat="server" Text='<%#Eval("FormPrefix") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Insert Right" HeaderStyle-Width="100">
                        <ItemStyle HorizontalAlign="Center" />
                        <FooterStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="chkInsertRight" Checked='<%# Convert.ToBoolean(Eval("InsertRight")) %>' />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Button runat="server" ID="btnCheckInsert" Text="All" OnClick="btnCheckInsert_Click" />&nbsp;&nbsp;
                            <asp:Button runat="server" ID="btnUnCheckInsert" Text="None" OnClick="btnUnCheckInsert_Click" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Update Right" HeaderStyle-Width="100">
                        <ItemStyle HorizontalAlign="Center" />
                        <FooterStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="chkUpdateRight" Checked='<%# Convert.ToBoolean(Eval("UpdateRight")) %>' />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Button runat="server" ID="btnUpdateRight" Text="All" OnClick="btnUpdateRight_Click" />&nbsp;&nbsp;
                            <asp:Button runat="server" ID="btnUnUpdateRight" Text="None" OnClick="btnUnUpdateRight_Click" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete Right" HeaderStyle-Width="100">
                        <ItemStyle HorizontalAlign="Center" />
                        <FooterStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="chkDeleteRight" Checked='<%# Convert.ToBoolean(Eval("DeleteRight")) %>' />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Button runat="server" ID="btnDeleteRight" Text="All" OnClick="btnDeleteRight_Click" />&nbsp;&nbsp;
                            <asp:Button runat="server" ID="btnUnDeleteRight" Text="None" OnClick="btnUnDeleteRight_Click" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Select Right" HeaderStyle-Width="100">
                        <ItemStyle HorizontalAlign="Center" />
                        <FooterStyle  HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="chkSelectRight" Checked='<%# Convert.ToBoolean(Eval("SelectRight")) %>' />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Button runat="server" ID="btnSelectRight" Text="All" OnClick="btnSelectRight_Click" />&nbsp;&nbsp;
                            <asp:Button runat="server" ID="btnUnSelectRight" Text="None" OnClick="btnUnSelectRight_Click" />
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div id="control" style="margin-left: 170px;">
                
                
                
                
            </div>
            <div class="paging">
                <div id="Div1" class="viewpageinfo" runat="server" visible="false">
                    <%--View 1 -10 of 13--%>
                    Show
                </div>
                <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageSize_Changed"
                    Visible="false">
                    <asp:ListItem Text="10" Value="10" />
                    <asp:ListItem Text="25" Value="25" />
                    <asp:ListItem Text="50" Value="50" />
                </asp:DropDownList>
                <div class="pagelist">
                    <asp:Repeater ID="rptPager" runat="server">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
    </center>
</asp:Content>

