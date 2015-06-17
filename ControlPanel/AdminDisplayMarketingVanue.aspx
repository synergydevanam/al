<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Default.master"  CodeFile="AdminDisplayMarketingVanue.aspx.cs" Inherits="AdminDisplayMarketingVanue" Title="MarketingVanue Insert/Update By Admin" %>
 <asp:Content ID="head" runat="server" ContentPlaceHolderID="head">
 </asp:Content>
 <asp:Content ID="ContentPlaceHolder1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<div class="content-box">
<div class="header">
<h3>View Data MarketingVanue || <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/UI/AdminMarketingVanue.aspx" >
<asp:Image runat="server" ID="addImage" ImageUrl="~/App_Themes/CoffeyGreen/images/add.png" />Insert Gift</asp:HyperLink></h3>
</div>
<div class="inner-content">
	 	<asp:GridView ID="gvMarketingVanue" class="gridCss" runat="server" AutoGenerateColumns="false"  AlternatingRowStyle-CssClass="even"    HeaderStyle-CssClass="grid_head_css"  CssClass="grid" >
	 	 	<Columns>
<asp:TemplateField HeaderText="Marketing Vanue">
 	 <ItemTemplate>
 	 <asp:Label ID="lblMarketingVanueID" runat="server" Text='<%#Eval("MarketingVanueID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Marketing Vanue Name">
 	 <ItemTemplate>
 	 <asp:Label ID="lblMarketingVanueName" runat="server" Text='<%#Eval("MarketingVanueName") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Delete">
 	 <ItemTemplate>
 	 <asp:ImageButton runat="server" ID="lbSelect"  CommandArgument='<%#Eval("MarketingVanueID") %>' AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png"
 	 />
 	 <asp:ImageButton runat="server" ID="lbDelete"  CommandArgument='<%#Eval("MarketingVanueID") %>' OnClick="lbDelete_Click"  AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png"
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

