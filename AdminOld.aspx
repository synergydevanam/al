<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default.master" CodeFile="AdminOld.aspx.cs"
    Inherits="Admin" Title="Welcome to Assisted Living" %>


<asp:Content ID="ContentPlaceHolder1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div id="container" class="minHeight">
        <div id="sidebar">
            <div class="sidebar_menu_title">
                <h5>
                    Customer</h5>
                <ul>
                    <li><a href="CustomerInsert.aspx">Add Customer</a></li>
                    <li><a href="DisplayCustomer.aspx">Display Customer</a> </li>
                    <li><a href="Admin/AdminDisplayClient.aspx">Appoinments</a> </li>
                </ul>
            </div>
            <div class="sidebar_menu_title">
                <h5>
                    Other</h5>
                <ul>
                    <li>
                        <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/UI/AdminDisplayGift.aspx"
                            Text="Display Gift"></asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/UI/AdminDisplayIncome.aspx"
                            Text="Display Income"></asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/UI/AdminDisplayLeadSource.aspx"
                            Text="Display LeadSource"></asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/UI/AdminDisplayMarketing.aspx"
                            Text="Display Marketing"></asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/UI/AdminDisplayMarketingAgent.aspx"
                            Text="Display Marketing Agent"></asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/UI/AdminDisplayMarketingVanue.aspx"
                            Text="Display Marketing Vanue"></asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/UI/AdminDisplayRelationship.aspx"
                            Text="Display Relationship"></asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/UI/AdminDisplaySalesCenter.aspx"
                            Text="Display Sales Center"></asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/UI/AdminDisplayTourStatus.aspx"
                            Text="Display Tour Status"></asp:HyperLink></li>
                </ul>
                
            </div>
            <div class="sidebar_menu_title" runat="server"  id="dvUserManagement">
                <h5>
                    Manage Users</h5>
                <ul>
                    <li>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin/AdminUserCreate.aspx"
                            Text="Add User"></asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Admin/AdminDisplayFormRights.aspx"
                            Text="Setup Permissions"></asp:HyperLink></li>
                </ul>
            </div>

            
        </div>
    </div>
    
</asp:Content>
