<%@ Page Title="" Language="C#" MasterPageFile="~/WithoutLeftMenu.master" AutoEventWireup="true"
    CodeFile="AssessmentnCare.aspx.cs" Inherits="Resident_ADLRecord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<style type="text/css">
td a{text-decoration:underline;color:Blue;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="single_colom">
        <div style="padding: 20px;">
            <table width="100%">
                <tr>
                    <td align="center" style="text-align: center; font-size: 20px; font-weight: bold;">
                        COMPREHENSIVE ASSESSMENT
                        <br />
                        AND SERVICE CARE PLAN
                    </td>
                </tr>
                <tr>
                    <td align="center" style="text-align: center; font-size: 20px; font-weight: bold;">
                        <a href="AdminAssessmentnCareParentInsertUpdate.aspx?assessmentnCareParentID=0">Add Header</a>
                    </td>
                </tr>
                <tr>
                    <td style="width:100%">
                        <asp:GridView ID="gvAssessmentnCareParent" runat="server" 
                            Width="100%"
                        AutoGenerateColumns="false" ShowHeader="false">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table width="100%" id='tblAssessmentnCareParent'style="padding:20px;">
                                            <tr>
                                                <td align="center" style='text-align:center;font-size:17px;font-weight:bold;'>
                                                    <%#Eval("AssessmentnCareParentName") %>
                                                    <asp:HiddenField ID="hfAssessmentnCareParentID" runat="server" Value='<%#Eval("AssessmentnCareParentID") %>'/>
                                                    &nbsp;|&nbsp;<a href='AdminAssessmentnCareParentInsertUpdate.aspx?assessmentnCareParentID=<%#Eval("AssessmentnCareParentID") %>'>Edit</a>
                                                    &nbsp;|&nbsp;<a href='AdminAssessmentnCareChildInsertUpdate.aspx?AssessmentnCareParentID=<%#Eval("AssessmentnCareParentID") %>'>Add Detail</a>
                                                    &nbsp;|&nbsp;<asp:LinkButton ID="lbDeleteParent" runat="server"  CommandArgument='<%#Eval("AssessmentnCareParentID") %>' OnClick="lbDeleteParent_Click">Delete</asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id='trAssessmentnCareChild'>
                                                    <asp:DataList ID="dlAssessmentnCareChild" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" Width="100%" ItemStyle-Width="50%">
                                                        <ItemTemplate>
                                                                <%#Eval("AssessmentnCareChildName") %>&nbsp;|&nbsp;<a href='AdminAssessmentnCareChildInsertUpdate.aspx?assessmentnCareChildID=<%#Eval("AssessmentnCareChildID") %>'>Edit</a>
                                                                &nbsp;|&nbsp;<asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("AssessmentnCareChildID") %>' OnClick="lbDelete_Click">Delete</asp:LinkButton>                                   
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
