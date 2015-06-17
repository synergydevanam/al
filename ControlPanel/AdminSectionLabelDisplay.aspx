<%@ Page Language="C#" MasterPageFile="~/Login/AdminMaster.master" AutoEventWireup="true"
    CodeFile="AdminSectionLabelDisplay.aspx.cs" Inherits="AdminSectionLabelDisplay"
    Title="Display SectionLabel By Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .gridCss
        {
            
            padding: 20px 10px 10px 10px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="tableCss" align="center">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblSectionNo" runat="server" Text="Section No: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSectionNo" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblLabelText" runat="server" Text="Label Text: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtLabelText" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField1" runat="server" Text="Order: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField1" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr style="display:none;">
                <td>
                    <asp:Label ID="lblExtraField2" runat="server" Text="ExtraField2: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField2" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr style="display:none;">
                <td>
                    <asp:Label ID="lblExtraField3" runat="server" Text="ExtraField3: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField3" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr style="display:none;">
                <td>
                    <asp:Label ID="lblExtraField4" runat="server" Text="ExtraField4: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField4" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr style="display:none;">
                <td>
                    <asp:Label ID="lblExtraField5" runat="server" Text="ExtraField5: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField5" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                <asp:Button ID="btnCleanData" runat="server" Text="Clear" 
                        onclick="btnCleanData_Click"  />
                </td>
                <td>
                    <asp:Button ID="btnUpdate" runat="server" Text="Save" OnClick="btnUpdate_Click" />
                    
                    <asp:HiddenField ID="hfID" runat="server" Value="0"/>
                </td>
            </tr>
        </table>
    </div>
    <div align="center">
        <asp:GridView ID="gvSectionLabel" runat="server"  AutoGenerateColumns="false" CssClass="gridCss">
            <Columns>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbSelect" runat="server" CommandArgument='<%#Eval("SectionLabelID") %>'
                            OnClick="lbSelect_Click">
                            Edit
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Section No">
                    <ItemTemplate>
                        <asp:Label ID="lblSectionNo" runat="server" Text='<%#Eval("SectionNo") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Label Text">
                    <ItemTemplate>
                        <asp:Label ID="lblLabelText" runat="server" Text='<%#Eval("LabelText") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Order">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField1" runat="server" Text='<%#Eval("ExtraField1") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:TemplateField HeaderText="ExtraField2">
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
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("SectionLabelID") %>'
                            OnClick="lbDelete_Click">
                            Delete
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
