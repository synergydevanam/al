<%@ Page Language="C#" MasterPageFile="~/WithoutLeftMenu.master" AutoEventWireup="true"
    CodeFile="AdminPropertyDisplay.aspx.cs" Inherits="AdminPropertyDisplay" Title="Display Property By Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .gridCss
        {
            width: 100%;
            padding: 20px 10px 10px 10px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <div class="single_colom"><div style="padding:20px;">
    <p>Property List</p>
    <asp:HiddenField ID="hfHasSearchCompleted" Value="0" runat="server" />
        <asp:GridView ID="gvProperty" runat="server" AutoGenerateColumns="false"  HeaderStyle-CssClass="grid_head_css"  CssClass="grid">
                <HeaderStyle BackColor="#DFEAF5" />
            <Columns>
                
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="lblPropertyName" runat="server" Text='<%#Eval("ExtraField4") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address">
                    <ItemTemplate>
                        <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="City">
                    <ItemTemplate>
                        <asp:Label ID="lblCity" runat="server" Text='<%#Eval("ExtraField1") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="State">
                    <ItemTemplate>
                        <asp:Label ID="lblState" runat="server" Text='<%#Eval("ExtraField3") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Zip">
                    <ItemTemplate>
                        <asp:Label ID="lblZip" runat="server" Text='<%#Eval("ExtraField2") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Company">
                    <ItemTemplate>
                        <asp:Label ID="lblCompany" runat="server" Text='<%#Eval("ExtraField6") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:TemplateField HeaderText="ExtraField1">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField1" runat="server" Text='<%#Eval("ExtraField1") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField2">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField2" runat="server" Text='<%#Eval("ExtraField2") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField3">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField3" runat="server" Text='<%#Eval("ExtraField3") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField4">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField4" runat="server" Text='<%#Eval("ExtraField4") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField5">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField5" runat="server" Text='<%#Eval("ExtraField5") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField6">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField6" runat="server" Text='<%#Eval("ExtraField6") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField7">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField7" runat="server" Text='<%#Eval("ExtraField7") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Contact no">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField8" runat="server" Text='<%#Eval("ExtraField8") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Contact Person">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField9" runat="server" Text='<%#Eval("ExtraField9") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:TemplateField HeaderText="ExtraField10">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField10" runat="server" Text='<%#Eval("ExtraField10") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("PropertyID") %>' OnClick="lbDelete_Click">
                            Delete
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                    <asp:ImageButton runat="server" ID="lbSelect"  CommandArgument='<%#Eval("PropertyID") %>' AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png"/>
 	                <%--<asp:ImageButton runat="server" ID="lbDelete"  CommandArgument='<%#Eval("ResidentID") %>' OnClick="lbDelete_Click"  AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png"/>--%>
                        
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
             <EmptyDataTemplate>
                <h3>No Resident matches the search criteria please change</h3>
            </EmptyDataTemplate>
        </asp:GridView>
    </div> </div>
</asp:Content>
