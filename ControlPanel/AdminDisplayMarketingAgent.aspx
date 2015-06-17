<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Default.master"  CodeFile="AdminDisplayMarketingAgent.aspx.cs" Inherits="AdminDisplayMarketingAgent" Title="MarketingAgent Insert/Update By Admin" %>
 <asp:Content ID="head" runat="server" ContentPlaceHolderID="head">
 </asp:Content>
 <asp:Content ID="ContentPlaceHolder1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<div class="content-box">
<div class="header">
<h3>View Data MarketingAgent || <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/UI/AdminMarketingAgent.aspx" >
<asp:Image runat="server" ID="addImage" ImageUrl="~/App_Themes/CoffeyGreen/images/add.png" />Insert Gift</asp:HyperLink></h3>
</div>
<div class="inner-content">
	 	<asp:GridView ID="gvMarketingAgent" class="gridCss" runat="server" AutoGenerateColumns="false"  AlternatingRowStyle-CssClass="even"    HeaderStyle-CssClass="grid_head_css"  CssClass="grid" >
	 	 	<Columns>
<asp:TemplateField HeaderText="Marketing Agent">
 	 <ItemTemplate>
 	 <asp:Label ID="lblMarketingAgentID" runat="server" Text='<%#Eval("MarketingAgentID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Marketing Agen Name">
 	 <ItemTemplate>
 	 <asp:Label ID="lblMarketingAgenName" runat="server" Text='<%#Eval("MarketingAgentName") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Delete">
 	 <ItemTemplate>
 	 <asp:ImageButton runat="server" ID="lbSelect"  CommandArgument='<%#Eval("MarketingAgentID") %>' AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png"
 	 />
 	 <asp:ImageButton runat="server" ID="lbDelete"  CommandArgument='<%#Eval("MarketingAgentID") %>' OnClick="lbDelete_Click"  AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png"
 	  />
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
	<asp:LinkButton ID="lnkPage" runat="server" Text = '<%#Eval("Text") %>' CommandArgument = '<%# Eval("Value") %>' Enabled = '<%# Eval("Enabled") %>' OnClick = "Page_Changed"></asp:LinkButton>
	</ItemTemplate>
	</asp:Repeater>
	</div>
    <div class="clear"></div>
	</div>
</div>
</div>
 </asp:Content>

