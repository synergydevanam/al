<%@ Page Title="" Language="C#" MasterPageFile="~/WithoutLeftMenuPrint.master" AutoEventWireup="true"
    CodeFile="ServiceCarePlanAssessmentPrint.aspx.cs" Inherits="Resident_ADLRecord" %>

<%@ Register Src="../control/PrintingControlResidentInfo.ascx" TagName="PrintingControlResidentInfo"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="single_colom">
        <div style="padding: 20px;">
            <table width="100%">
                <tr>
                    <td>
                        <uc1:PrintingControlResidentInfo ID="PrintingControlResidentInfo1" runat="server" />
                    </td>
                </tr>
                <tr style="display: none;">
                    <td align="center">
                        <b>Existing Record</b> &nbsp;&nbsp;
                        <asp:DropDownList ID="ddlExistingRecord" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlExistingRecord_SelectedIndexChanged">
                        </asp:DropDownList>
                        &nbsp;&nbsp;
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                        &nbsp;<a id="a_Print" visible="false" runat="server"><img src="../App_Themes/Default/images/Print_plain.png" /></a>&nbsp;
                        <asp:Label ID="lblMsg" runat="server" Text="..Successful.." ForeColor="Green" Visible="false"></asp:Label>
                        <asp:HiddenField ID="hfSectionTextValueID" runat="server" Value="0" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%">
                        <table width="100%">
                            <tr>
                                <td colspan="2" align="center">
                                    <h3 style="font-weight: bold; font-size: 20px; padding-top: 5px">
                                        (N = None, M = Minimal, T = Total)
                                    </h3>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    <h3 style="font-weight: bold; font-size: 20px; padding-top: 5px">
                                        SECTION 1 - Resident’s Needs</h3>
                                    <h3 style="font-weight: bold; font-size: 15px; padding-bottom: 5px;">
                                        (Activities of Daily Living)</h3>
                                    <asp:GridView ID="gvSection_1" runat="server" AutoGenerateColumns="false" ShowHeader="false"
                                        Width="420px">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hfSectionLabelID" runat="server" Value='<%#Eval("SectionLabelID")%>' />
                                                    <%#Eval("ExtraField1")%>&nbsp;.&nbsp;<%#Eval("LabelText")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="136px">
                                                <ItemTemplate>
                                                    <asp:RadioButtonList ID="rbtnlSection" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="N" Selected="True">N</asp:ListItem>
                                                        <asp:ListItem Value="M">M</asp:ListItem>
                                                        <asp:ListItem Value="T">T</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <h3 style="font-weight: bold; font-size: 20px; padding: 5px;">
                                        SECTION 2 – Diet</h3>
                                    <asp:TextBox ID="txtSection_2" runat="server" TextMode="MultiLine" Height="100px"
                                        Width="420px"></asp:TextBox>
                                    <h3 style="font-weight: bold; font-size: 20px; padding: 5px;">
                                        SECTION 3 - Diagnosis</h3>
                                    <asp:TextBox ID="txtSection_3" runat="server" TextMode="MultiLine" Height="100px"
                                        Width="420px"></asp:TextBox>
                                    <h3 style="font-weight: bold; font-size: 20px; padding: 5px;">
                                        SECTION 4 - Nursing Procedures</h3>
                                    <asp:GridView ID="gvSection_4" runat="server" AutoGenerateColumns="false" ShowHeader="false"
                                        Width="420px">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hfSectionLabelID" runat="server" Value='<%#Eval("SectionLabelID")%>' />
                                                    <%#Eval("ExtraField1")%>&nbsp;.&nbsp;<%#Eval("LabelText")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="136px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtValue" runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                                <td align="left" style="padding-left: 50px;" valign="top">
                                    <h3 style="font-weight: bold; font-size: 20px; padding: 5px;">
                                        SECTION 5 - Functioning</h3>
                                    <asp:GridView ID="gvSection_5" runat="server" AutoGenerateColumns="false" Width="420px"
                                        ShowHeader="false">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hfSectionLabelID" runat="server" Value='<%#Eval("SectionLabelID")%>' />
                                                    <%#Eval("ExtraField1")%>&nbsp;.&nbsp;<%#Eval("LabelText")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="136px">
                                                <ItemTemplate>
                                                    <asp:RadioButtonList ID="rbtnlSection" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="N" Selected="True">N</asp:ListItem>
                                                        <asp:ListItem Value="M">M</asp:ListItem>
                                                        <asp:ListItem Value="T">T</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <h3 style="font-weight: bold; font-size: 20px; padding: 5px;">
                                        SECTION 6- Allergies</h3>
                                    <asp:TextBox ID="txtSection_6" runat="server" TextMode="MultiLine" Height="100px"
                                        Width="420px"></asp:TextBox>
                                    <h3 style="font-weight: bold; font-size: 20px; padding-top: 5px">
                                        SECTION 7 - Medication</h3>
                                    <h3 style="font-weight: bold; font-size: 15px; padding-bottom: 5px;">
                                        (List PRN’s last)</h3>
                                    <asp:TextBox ID="txtSection_7" runat="server" TextMode="MultiLine" Height="100px"
                                        Width="420px"></asp:TextBox>
                                    <h3 style="font-weight: bold; font-size: 20px; padding: 5px;">
                                        SECTION 8 - Behavior Problems</h3>
                                    <asp:GridView ID="gvSection_8" runat="server" AutoGenerateColumns="false" Width="420px"
                                        ShowHeader="false">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hfSectionLabelID" runat="server" Value='<%#Eval("SectionLabelID")%>' />
                                                    <%#Eval("ExtraField1")%>&nbsp;.&nbsp;<%#Eval("LabelText")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="136px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtValue" runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <h3 style="font-weight: bold; font-size: 20px; padding: 5px;">
                                        SECTION 9 Mental State</h3>
                                    <asp:GridView ID="gvSection_9" runat="server" AutoGenerateColumns="false" Width="420px"
                                        ShowHeader="false">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hfSectionLabelID" runat="server" Value='<%#Eval("SectionLabelID")%>' />
                                                    <%#Eval("ExtraField1")%>&nbsp;.&nbsp;<%#Eval("LabelText")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="136px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtValue" runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr align="center">
                    <td>
                        <br />
                        <br />
                        <table cellpadding="5">
                            <tr>
                                <td>Date of Conference
                                </td>
                                <td>_____________________________
                                </td>
                            </tr>
                            <tr>
                                <td>Doctor
                                </td>
                                <td>_____________________________
                                </td>
                            </tr>
                            <tr>
                                <td>Home Representative
                                </td>
                                <td>_____________________________
                                </td>
                            </tr>
                            <tr>
                                <td>Date and Time of Admitting
                                </td>
                                <td>_____________________________
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
