<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" 
CodeFile="AdminPropertyInsertUpdate.aspx.cs" Inherits="AdminPropertyInsertUpdate" Title="Property Insert/Update By Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .tableCss
        {
        	text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
   <div id="main_form">
   <table width="100%">
    <tr>
        <td><p>Property</p></td>
        <td style="float:right;padding-right:8px;"><p>
        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click"  class="add_btn"/>
         <asp:Button ID="btnUpdate" runat="server" Text="Update"  class="add_btn" Visible="false"
                        OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnClear" runat="server" Text="Clear" class="add_btn" Visible="false" OnClick="btnClear_Click" />
        </p></td>
    </tr>
   </table>
    
    
    <ul>
    <li class="text_box">
                    <asp:Label ID="Label4" runat="server" Text="Status: ">
                    </asp:Label>
                </li>
    <li>
                    <asp:DropDownList ID="ddlStatus" runat="server">
                    <asp:ListItem Value="Active">Active</asp:ListItem>
                    <asp:ListItem Value="InActive">InActive</asp:ListItem>
                    </asp:DropDownList>
                </li>
    <li class="text_box">
                    <asp:Label ID="Label3" runat="server" Text="Company: ">
                    </asp:Label>
                </li>
    <li>
                    <asp:DropDownList ID="ddlCompnay" runat="server">
                    </asp:DropDownList>
                </li>
    <li class="text_box" style="display:none;">
                    <asp:Label ID="lblPropertyName" runat="server" Text="PropertyName: ">
                    </asp:Label>
                 </li>
    <li class="text_input1" style="display:none;">
                    <asp:TextBox ID="txtPropertyName" runat="server" Text="">
                    </asp:TextBox>
               </li>
    <li class="text_box">
                    <asp:Label ID="lblAddress" runat="server" Text="Address: ">
                    </asp:Label>
               </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtAddress" runat="server" Text="">
                    </asp:TextBox>
                </li>
                <li class="text_box">
                    <asp:Label ID="Label2" runat="server" Text="City: ">
                    </asp:Label>
                </li>
                <li class="text_input1">
                    <asp:TextBox ID="txtExtraField1" runat="server" Text="">
                    </asp:TextBox>
                </li>
                <li class="text_box">
                    <asp:Label ID="lblStateID" runat="server" Text="State: ">
                    </asp:Label>
                </li>
    <li>
                    <asp:DropDownList ID="ddlState" runat="server">
                    </asp:DropDownList>
                </li>
                <li><div class="clear"></div></li>
                <li class="text_box">
                    <asp:Label ID="Label1" runat="server" Text="Zip: ">
                    </asp:Label>
               </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtExtraField2" runat="server" Text="">
                    </asp:TextBox>
                </li>
    <li class="text_box" style="display:none;">
                    <asp:Label ID="lblCountryID" runat="server" Text="CountryID: ">
                    </asp:Label>
               </li>
    <li  style="display:none;">
                    <asp:DropDownList ID="ddlCountry" runat="server">
                    </asp:DropDownList>
               </li>
               <li><div class="clear"></div></li>
    
    <li class="text_box" style="display:none;">
                    <asp:Label ID="lblCityID" runat="server" Text="CityID: ">
                    </asp:Label>
                </li>
    <li style="display:none;">
                    <asp:DropDownList ID="ddlCity" runat="server">
                    </asp:DropDownList>
                </li>
                <li ><div class="clear"></div></li>
    <li class="text_box" style="display:none;">
                    <asp:Label ID="lblExtraField1" runat="server" Text="ExtraField1: ">
                    </asp:Label>
                </li>
    <li class="text_input1" style="display:none;">
                    
                </li>
    <li class="text_box" style="display:none;">
                    <asp:Label ID="lblExtraField2" runat="server" Text="ExtraField2: ">
                    </asp:Label>
                </li>
    <li class="text_input1" style="display:none;">
                    
                </li>
    <li class="text_box" style="display:none;">
                    <asp:Label ID="lblExtraField3" runat="server" Text="ExtraField3: ">
                    </asp:Label>
               </li>
    <li class="text_input1" style="display:none;">
                    <asp:TextBox ID="txtExtraField3" runat="server" Text="">
                    </asp:TextBox>
                </li>
    <li class="text_box" style="display:none;">
                    <asp:Label ID="lblExtraField4" runat="server" Text="ExtraField4: ">
                    </asp:Label>
               </li>
    <li class="text_input1" style="display:none;">
                    <asp:TextBox ID="txtExtraField4" runat="server" Text="">
                    </asp:TextBox>
                </li>
    <li class="text_box" style="display:none;">
                    <asp:Label ID="lblExtraField5" runat="server" Text="ExtraField5: ">
                    </asp:Label>
                </li>
    <li class="text_input1" style="display:none;">
                    <asp:TextBox ID="txtExtraField5" runat="server" Text="">
                    </asp:TextBox>
                </li>
    <li class="text_box" style="display:none;">
                    <asp:Label ID="lblExtraField6" runat="server" Text="ExtraField6: ">
                    </asp:Label>
                </li>
    <li class="text_input1" style="display:none;">
                    <asp:TextBox ID="txtExtraField6" runat="server" Text="">
                    </asp:TextBox>
                </li>
    <li class="text_box" style="display:none;">
                    <asp:Label ID="lblExtraField7" runat="server" Text="ExtraField7: ">
                    </asp:Label>
                </li>
    <li class="text_input1" style="display:none;">
                    <asp:TextBox ID="txtExtraField7" runat="server" Text="">
                    </asp:TextBox>
                </li>
    <li class="text_box" >
                    <asp:Label ID="lblExtraField8" runat="server" Text="Contact No: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtExtraField8" runat="server" Text="">
                    </asp:TextBox>
                </li>
    <li class="text_box" >
                    <asp:Label ID="lblExtraField9" runat="server" Text="Contact person: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtExtraField9" runat="server" Text="">
                    </asp:TextBox>
               </li>
    <li class="text_box" style="display:none;">
                    <asp:Label ID="lblExtraField10" runat="server" Text="ExtraField10: ">
                    </asp:Label>
               </li>
    <li class="text_input1" style="display:none;">
                    <asp:TextBox ID="txtExtraField10" runat="server" Text="">
                    </asp:TextBox>
                </li>
    
   </ul>
             </div>
    
</asp:Content>
