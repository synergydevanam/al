<%@ Page Title="" Language="C#" MasterPageFile="~/WithoutLeftMenuPrint.master" AutoEventWireup="true"
    CodeFile="Medication_DischargeMedicaitonLealeaseRecordPrint.aspx.cs" Inherits="Resident_ADLRecord" %>

<%@ Register Src="../control/PrintingControlResidentInfo.ascx" TagName="PrintingControlResidentInfo"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="single_colom">
        <div style="padding: 20px;">
            <uc1:PrintingControlResidentInfo ID="PrintingControlResidentInfo1" runat="server" />
            <table width="100%">
                <tr>
                    <td>
                        <br />
                        <br />
                        <b>Resident Record No.</b>_______________ <b>Room No.</b>________ <b>Date of Discharge</b>__________________
                        <br />
                        <br />
                        <b>Medications were given to: Responsible Party</b>_____________________ <b>Resident</b>__________________________
                        <b>Other</b>______________________
                        <br />
                        <br />
                    </td>
                </tr>
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
                                        <%--<asp:TemplateField HeaderText="Added By">
                                            <ItemTemplate>
                                                <%#Eval("AddedByUser")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Update By">
                                            <ItemTemplate>
                                                <%#Eval("UpdateByUser")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Comment">
                                            <ItemTemplate>
                                                <%#Eval("UpdateByUser")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellspacing="10" border="0" cellpadding="0">
                            <tr>
                                <td style="font-weight: bold;">
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; text-align: center;">
                                    Responsible party was given instructions regarding (Check all that apply)
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; text-align: left;">
                                    <br />
                                    ________________Directions for use
                                    <br />
                                    <br />
                                    ________________Instructions for storage (Including keeping away from children)
                                    <br />
                                    <br />
                                    ________________Person to contact in event of problems with medication
                                    <br />
                                    <br />
                                    ________________Other (Specify)_____________________________
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; text-align: justify;">
                                    <br />
                                    I have been instructed in the proper use of the medication(s) given to me including
                                    how much and how often to give the medication, and for what it is used. I accept
                                    responsibility for the proper storage and use of the medication(s). If the medication(s)
                                    have been dispensed in containers that are not child proof at my request, my signature
                                    below signifies such request.
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; text-align: justify;">
                                    <table width="100%">
                                        <tr>
                                            <td style="text-align: left;" align="left">
                                                ____________________________________________
                                            </td>
                                            <td style="text-align: center; width: 150px;" align="right">
                                                ___________________
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left;" align="left">
                                                Signature of Responsible Party Receiving Medication
                                            </td>
                                            <td style="text-align: center; width: 150px;" align="right">
                                                Date
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; text-align: justify;">
                                    <br />
                                    __________________ Medications were destroyed at facility or returned to Pharmacy
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; text-align: justify;">
                                    <table width="100%">
                                        <tr>
                                            <td style="text-align: left;" align="left">
                                                ____________________________________________
                                            </td>
                                            <td style="text-align: center; width: 150px;" align="right">
                                                ___________________
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left;" align="left">
                                                Signature of Nurse Releasing/Disposing of Medication
                                            </td>
                                            <td style="text-align: center; width: 150px;" align="right">
                                                Date
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%" cellpadding="0" cellspacing="0" border="1">
                                        <tr>
                                            <td valign="top" style="padding:5px;">
                                            Original Date:
                                            <br />
                                            <br />
                                            </td>
                                            <td valign="top" style="padding:5px;">
                                            Revision Date:
                                            </td>
                                            <td valign="top" style="padding:5px;">
                                            Discharge Medication Release Record
                                            </td>
                                            <td valign="top" style="padding:5px;">
                                            Page
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
