<%@ Page Title="" Language="C#" MasterPageFile="~/WithoutLeftMenu.master" AutoEventWireup="true"
    CodeFile="AssessmentnCare.aspx.cs" Inherits="Resident_ADLRecord" %>
    <%@ Register src="../control/DataEntryControlResidentInfo.ascx" tagname="DataEntryControlResidentInfo" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="single_colom">
        <div style="padding: 20px;">
            <table width="100%">
                <tr>
                    <td align="center" style="text-align: center; font-size: 20px; font-weight: bold;">
                        COMPREHENSIVE ASSESSMENT
                        
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc1:DataEntryControlResidentInfo ID="DataEntryControlResidentInfo1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <table>
                                    <tr>
                                        <td valign="middle">
                                            <b>Existing Record</b> &nbsp;&nbsp;
                                        </td>
                                        <td valign="middle">
                                            <asp:DropDownList ID="ddlExistingRecord" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlExistingRecord_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td valign="middle">
                                            &nbsp;&nbsp;
                                            <asp:ImageButton ID="btnSave" OnClick="btnSave_Click" runat="server" ImageUrl="../App_Themes/Default/images/save.png" />
                                        </td>
                                        <td valign="middle">
                        &nbsp;<a id="a_Print" visible="false" runat="server" ><img src="../App_Themes/Default/images/Print_plain.png" /></a>&nbsp;
                                            <asp:Label ID="lblMsg" runat="server" Text="Saved Successfully" ForeColor="Green"
                                                Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                        <%--<b>Existing Record</b>
                        &nbsp;&nbsp;
                        <asp:DropDownList ID="ddlExistingRecord" runat="server" AutoPostBack="true"
                            onselectedindexchanged="ddlExistingRecord_SelectedIndexChanged"></asp:DropDownList>
                        &nbsp;&nbsp;
                        <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
                        <asp:Label ID="lblMsg" runat="server" Text="..Successful.." ForeColor="Green" Visible="false"></asp:Label>
                   --%> </td>
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
