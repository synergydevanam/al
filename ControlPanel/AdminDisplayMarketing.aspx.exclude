<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Default.master"  CodeFile="AdminDisplayMarketing.aspx.cs" Inherits="AdminDisplayMarketing" Title="Marketing Insert/Update By Admin" %>
 <asp:Content ID="head" runat="server" ContentPlaceHolderID="head">
 </asp:Content>
 <asp:Content ID="ContentPlaceHolder1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<div class="content-box">
<div class="header">
<h3>View Data Marketing || <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/UI/AdminMarketing.aspx" >
<asp:Image runat="server" ID="addImage" ImageUrl="~/App_Themes/CoffeyGreen/images/add.png" />Insert Gift</asp:HyperLink></h3>
</div>
<div class="inner-content">
	 	<asp:GridView ID="gvMarketing" class="gridCss" runat="server" AutoGenerateColumns="false"  AlternatingRowStyle-CssClass="even"    HeaderStyle-CssClass="grid_head_css"  CssClass="grid" >
	 	 	<Columns>
<asp:TemplateField HeaderText="Marketing">
 	 <ItemTemplate>
 	 <asp:Label ID="lblMarketingID" runat="server" Text='<%#Eval("MarketingID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Customer">
 	 <ItemTemplate>
 	 <asp:Label ID="lblCustomerID" runat="server" Text='<%#Eval("CustomerID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Marketing Agent">
 	 <ItemTemplate>
 	 <asp:Label ID="lblMarketingAgentID" runat="server" Text='<%#Eval("MarketingAgentID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Marketing Closer">
 	 <ItemTemplate>
 	 <asp:Label ID="lblMarketingCloserID" runat="server" Text='<%#Eval("MarketingCloserID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Marketing Vanue">
 	 <ItemTemplate>
 	 <asp:Label ID="lblMarketingVanueID" runat="server" Text='<%#Eval("MarketingVanueID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Lead Source">
 	 <ItemTemplate>
 	 <asp:Label ID="lblLeadSourceID" runat="server" Text='<%#Eval("LeadSourceID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Gift">
 	 <ItemTemplate>
 	 <asp:Label ID="lblGiftID" runat="server" Text='<%#Eval("GiftID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Deposit Amount">
 	 <ItemTemplate>
 	 <asp:Label ID="lblDepositAmount" runat="server" Text='<%#Eval("DepositAmount") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Refundable">
 	 <ItemTemplate>
 	 <asp:Label ID="lblRefundable" runat="server" Text='<%#Eval("Refundable") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Notes">
 	 <ItemTemplate>
 	 <asp:Label ID="lblNotes" runat="server" Text='<%#Eval("Notes") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Delete">
 	 <ItemTemplate>
 	 <asp:ImageButton runat="server" ID="lbSelect"  CommandArgument='<%#Eval("MarketingID") %>' AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png"
 	 />
 	 <asp:ImageButton runat="server" ID="lbDelete"  CommandArgument='<%#Eval("MarketingID") %>' OnClick="lbDelete_Click"  AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png"
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

