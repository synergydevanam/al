<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DataEntryControlResidentInfo.ascx.cs" Inherits="control_PrintingControlResidentInfo" %>

<table width="100%" cellspacing="10" border="0" cellpadding="0">
                            <tr>
                                <td style="font-weight: bold;">
                                    RESIDENT NAME
                                </td>
                                <td style="border-bottom: 1px solid #8E8F8F; width: 406px;">
                                    <asp:Label ID="lblResidentName" runat="server" Text=""></asp:Label>
                                </td>
                                <td style="width: 60px; font-weight: bold;">
                                    PHYSICIAN
                                </td>
                                <td style="border-bottom: 1px solid #8E8F8F; width: 300px;">
                                    <asp:Label ID="lblPhysicianName" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold;">
                                    ADMITTED FROM
                                </td>
                                <td colspan="3" style="border-bottom: 1px solid #8E8F8F">
                                    <asp:Label ID="lblAdmittedFrom" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold;">
                                    Compnay
                                </td>
                                <td style="border-bottom: 1px solid #8E8F8F; width: 406px;">
                                    <asp:Label ID="lblCompnayName" runat="server" Text=""></asp:Label>
                                </td>
                                <td style="width: 60px; font-weight: bold;">
                                    Pharmacy
                                </td>
                                <td style="border-bottom: 1px solid #8E8F8F; width: 300px;">
                                    <asp:Label ID="lblPharmacyPreference" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold;">
                                    PROPERTY
                                </td>
                                <td colspan="3" style="border-bottom: 1px solid #8E8F8F">
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