<%@ Page Title="" Language="C#" MasterPageFile="~/WithoutLeftMenu.master" AutoEventWireup="true"
    CodeFile="AssessmentnCare.aspx.cs" Inherits="Resident_ADLRecord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
                    <td>
                        <table width="100%" cellspacing="10" border="0" cellpadding="0">
                            <tr>
                                <td style="font-weight:bold;">RESIDENT NAME</td>
                                <td style="border-bottom:1px solid #8E8F8F;width:406px;">
                                    <asp:Label ID="lblResidentName" runat="server" Text=""></asp:Label>
                                </td>
                                <td style="width:60px;font-weight:bold;">PHYSICIAN</td>
                                <td style="border-bottom:1px solid #8E8F8F;width:300px;">
                                    <asp:Label ID="lblPhysicianName" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight:bold;">ADMITTED FROM</td>
                                <td colspan="3" style="border-bottom:1px solid #8E8F8F">
                                    <asp:Label ID="lblAdmittedFrom" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight:bold;">PRIMARY LANGUAGE</td>
                                <td colspan="3" style="border-bottom:1px solid #8E8F8F">
                                    <asp:Label ID="lblPrimaryLanguage" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight:bold;">PROPERTY</td>
                                <td colspan="3" style="border-bottom:1px solid #8E8F8F">
                                    <asp:Label ID="lblProperty" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <b>Existing Record</b>
                        &nbsp;&nbsp;
                        <asp:DropDownList ID="ddlExistingRecord" runat="server" AutoPostBack="true"
                            onselectedindexchanged="ddlExistingRecord_SelectedIndexChanged"></asp:DropDownList>
                        &nbsp;&nbsp;
                        <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
                        <asp:Label ID="lblMsg" runat="server" Text="..Successful.." ForeColor="Green" Visible="false"></asp:Label>
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
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id='trAssessmentnCareChild'>
                                                    <asp:DataList ID="dlAssessmentnCareChild" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" Width="100%" ItemStyle-Width="50%">
                                                        <ItemTemplate>
                                                                <asp:CheckBox ID="chkSelect" runat="server" Text='<%#Eval("AssessmentnCareChildName") %>' ToolTip='<%#Eval("AssessmentnCareChildID") %>'/>                                   
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td style="font-size:15px;font-weight:bold;">Comments
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Width="875px" Height="20px" style="Border:1px solid #8E8F8F;font-family:Arial,Verdana;"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
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
