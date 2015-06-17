<%@ Page Title="" Language="C#" MasterPageFile="~/WithoutLeftMenuPrint.master" AutoEventWireup="true"
    CodeFile="AssessmentnCarePrint.aspx.cs" Inherits="Resident_ADLRecord" %>

<%@ Register src="../control/PrintingControlResidentInfo.ascx" tagname="PrintingControlResidentInfo" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="single_colom">
        <div style="padding: 20px;">
                <uc1:PrintingControlResidentInfo ID="PrintingControlResidentInfo1" 
                            runat="server" />
                <table width="100%">
                <tr style="display:none;">
                    <td align="center">
                        <b>
                        
                        Existing Record</b>
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
                <tr>
                    <td>
                        <table  cellspacing="10" border="0" cellpadding="0">
                            <tr>
                                <td style="font-weight:bold;" colspan="2"><br /><br /><br /></td>
                               
                            </tr>
                              <tr>
                                <td style="font-weight:bold;">ASSESSOR’S SIGNATURE</td>
                                <td  style="border-bottom:1px solid #8E8F8F;width:300px;text-align:left;">
                                </td>
                                <td style="font-weight:bold;">Date</td>
                                <td  style="border-bottom:1px solid #8E8F8F;width:100px;text-align:left;">
                                </td>
                            </tr>      
                              <tr>
                                <td style="font-weight:bold;">RESPONSIBLE PARTY SIGNATURE</td>
                                <td  style="border-bottom:1px solid #8E8F8F;width:300px;text-align:left;">
                                </td>
                                <td style="font-weight:bold;">Date</td>
                                <td  style="border-bottom:1px solid #8E8F8F;width:100px;text-align:left;">
                                </td>
                            </tr> 
                              <tr>
                                <td style="font-weight:bold;">RESIDENT SIGNATURE</td>
                                <td  style="border-bottom:1px solid #8E8F8F;width:300px;text-align:left;">
                                </td>
                                <td style="font-weight:bold;">Date</td>
                                <td  style="border-bottom:1px solid #8E8F8F;width:100px;text-align:left;">
                                </td>
                            </tr>                    
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
