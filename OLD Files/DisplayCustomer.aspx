<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Default.master"  CodeFile="DisplayCustomer.aspx.cs" Inherits="DisplayCustomer" Title="Customer Insert/Update By Admin" %>
 <asp:Content ID="head" runat="server" ContentPlaceHolderID="head">
 </asp:Content>
 <asp:Content ID="ContentPlaceHolder1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
     <div class="content-box">
<div class="header">
<h3>View Data Customer</h3>
</div>
<div class="inner-content">
	 	<asp:GridView ID="gvCustomer"  AlternatingRowStyle-CssClass="even"    HeaderStyle-CssClass="grid_head_css"  CssClass="grid"  runat="server" AutoGenerateColumns="false">
	 	 	<Columns>
<asp:TemplateField HeaderText="Customer">
 	 <ItemTemplate>
 	 <asp:Label ID="lblCustomerID" runat="server" Text='<%#Eval("CustomerID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="First Name">
 	 <ItemTemplate>
 	 <asp:Label ID="lblFirstName" runat="server" Text='<%#Eval("FirstName") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Last Name">
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
<asp:TemplateField HeaderText="Guest Name">
 	 <ItemTemplate>
 	 <asp:Label ID="lblGuestName" runat="server" Text='<%#Eval("GuestName") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Guest Age">
 	 <ItemTemplate>
 	 <asp:Label ID="lblGuestAge" runat="server" Text='<%#Eval("GuestAge") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<%--<asp:TemplateField HeaderText="Relationship">
 	 <ItemTemplate>
 	 <asp:Label ID="lblRelationshipID" runat="server" Text='<%#Eval("RelationshipID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Income">
 	 <ItemTemplate>
 	 <asp:Label ID="lblIncomeID" runat="server" Text='<%#Eval("IncomeID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>--%>
<asp:TemplateField HeaderText="Primary Phone">
 	 <ItemTemplate>
 	 <asp:Label ID="lblPrimaryPhone" runat="server" Text='<%#Eval("PrimaryPhone") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Secondary Phone">
 	 <ItemTemplate>
 	 <asp:Label ID="lblSecondaryPhone" runat="server" Text='<%#Eval("SecondaryPhone") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Address 1">
 	 <ItemTemplate>
 	 <asp:Label ID="lblAddress1" runat="server" Text='<%#Eval("Address1") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Address 2">
 	 <ItemTemplate>
 	 <asp:Label ID="lblAddress2" runat="server" Text='<%#Eval("Address2") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="City">
 	 <ItemTemplate>
 	 <asp:Label ID="lblCity" runat="server" Text='<%#Eval("City") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="State">
 	 <ItemTemplate>
 	 <asp:Label ID="lblState" runat="server" Text='<%#Eval("State") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Country">
 	 <ItemTemplate>
 	 <asp:Label ID="lblCountry" runat="server" Text='<%#Eval("Country") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Business">
 	 <ItemTemplate>
 	 <asp:Label ID="lblBusiness" runat="server" Text='<%#Eval("Business") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Email">
 	 <ItemTemplate>
 	 <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Delete">
 	 <ItemTemplate>
 	 <asp:ImageButton runat="server" ID="lbSelect"  CommandArgument='<%#Eval("CustomerID") %>' AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png"
 	 />
 	 <asp:ImageButton runat="server" ID="lbDelete"  CommandArgument='<%#Eval("CustomerID") %>' OnClick="lbDelete_Click"  AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png"
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

