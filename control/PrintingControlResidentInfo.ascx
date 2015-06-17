<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PrintingControlResidentInfo.ascx.cs" Inherits="control_PrintingControlResidentInfo" %>
<table width="100%">
                <tr>
                    <td align="left" valign="top">
                       <asp:Label ID="lblCompnayName" runat="server" Text=""  style="text-align: left; font-size: 20px; font-weight: bold;"></asp:Label> 
                    </td>
                    <td align="right" style="text-align: right; font-size: 12px; ">
                       Date Printed: <asp:Label ID="lblDatePrinted" runat="server" Text=""></asp:Label> 
                       <br />
                       Printed by: <asp:Label ID="lblPrintedBy" runat="server" Text=""></asp:Label> 
                    </td>
                </tr>
                
                <tr>
                    <td align="center" colspan="2"> 
                        <asp:Label ID="lblTitle" runat="server" Text=""  style="text-align: center; font-size: 20px; font-weight: bold;"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table width="100%" cellspacing="10" border="0" cellpadding="0">
                            <tr>
                                <td style="font-weight:bold;">RESIDENT NAME</td>
                                <td style="border-bottom:1px solid #8E8F8F;width:420px;">
                                    <asp:Label ID="lblResidentName" runat="server" Text=""></asp:Label>
                                </td>
                                <td style="width:85px;font-weight:bold;">PHYSICIAN</td>
                                <td style="border-bottom:1px solid #8E8F8F;width:270px;">
                                    <asp:Label ID="lblPhysicianName" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight:bold;">ADMITTED FROM</td>
                                <td style="border-bottom:1px solid #8E8F8F;width:420px;">
                                    <asp:Label ID="lblAdmittedFrom" runat="server" Text=""></asp:Label>
                                </td>
                                <td style="width:85px;font-weight:bold;">ADMITED DATE</td>
                                <td style="border-bottom:1px solid #8E8F8F;width:270px;">
                                    <asp:Label ID="lblAdmitedDate" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>                            
                            <tr>
                                <td style="font-weight:bold;">Pharmacy</td>
                                <td colspan="3" style="border-bottom:1px solid #8E8F8F">
                                     <asp:Label ID="lblPharmacyPreference" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight:bold;">PROPERTY</td>
                                <td colspan="3" style="border-bottom:1px solid #8E8F8F">
                                    <asp:Label ID="lblProperty" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold;">
                                    Allergy
                                </td>
                                <td colspan="3" style="border-bottom: 1px solid #8E8F8F">
                                    <asp:Label ID="lblAllergy" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                </table>