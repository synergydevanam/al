<%@ Page Title="" Language="C#" MasterPageFile="~/WithoutLeftMenuPrint.master" AutoEventWireup="true"
    CodeFile="Medication_AdmissionMedicaitonProfilePrint.aspx.cs" Inherits="Resident_ADLRecord" %>

<%@ Register Src="../control/PrintingControlResidentInfo.ascx" TagName="PrintingControlResidentInfo"
    TagPrefix="uc1" %>
    <%@ Register Src="../control/PrintFooter.ascx" TagName="PrintFooter"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="single_colom">
        <div style="padding: 20px;">
            <uc1:PrintingControlResidentInfo ID="PrintingControlResidentInfo1" runat="server" />
            <table width="100%">
                <tr>
                    <td class='tableCss'>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gvMedicaiton" runat="server" Width="100%" AutoGenerateColumns="false"
                                    ShowHeader="true">
                                    <Columns>
                                        <asp:TemplateField HeaderText="DATE ISSUED">
                                            <ItemTemplate>
                                                <%#Eval("AddedDate","{0:MM/dd/yyyy}")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="RX#">
                                            <ItemTemplate>
                                                <%#Eval("ExtraField1")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PHARMACY NAME">
                                            <ItemTemplate>
                                                <%#Eval("ExtraField4")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="MEDICATION NAME">
                                            <ItemTemplate>
                                                <%#Eval("MedicineName")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="STRENGTH">
                                            <ItemTemplate>
                                                <%#Eval("Quality")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="DOSAGE">
                                            <ItemTemplate>
                                                <%#Eval("Frequency")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="DIRECTION FOR USE">
                                            <ItemTemplate>
                                                <%#Eval("Quantity")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ROUTE OF ADMINISTRATION">
                                            <ItemTemplate>
                                                <%#Eval("ExtraField2")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc2:PrintFooter ID="PrintingControlResidentInfo2" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
