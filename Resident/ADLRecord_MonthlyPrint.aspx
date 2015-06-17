<%@ Page Title="" Language="C#" MasterPageFile="~/WithoutLeftMenuPrint.master" AutoEventWireup="true"
    CodeFile="ADLRecord_MonthlyPrint.aspx.cs" Inherits="Resident_ADLRecord" %>

<%@ Register Src="../control/PrintingControlResidentInfo.ascx" TagName="PrintingControlResidentInfo"
    TagPrefix="uc1" %>
    
    <%@ Register Src="../control/PrintFooter.ascx" TagName="PrintFooter"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<style type="text/css">
.reportTable td,.reportTable{border:1px solid black;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="single_colom">
        <div style="padding: 20px;">
            <table width="100%">
                <tr align="center">
                    <td align="center">
                        <uc1:PrintingControlResidentInfo ID="PrintingControlResidentInfo1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                        
                        <asp:DropDownList ID="ddlMonths" runat="server" AutoPostBack="true"
                            onselectedindexchanged="ddlMonths_SelectedIndexChanged">
                            </asp:DropDownList>                           
                            &nbsp;&nbsp;
                             <asp:DropDownList ID="ddlYears" runat="server"  AutoPostBack="true"
                            onselectedindexchanged="ddlYears_SelectedIndexChanged">
                            </asp:DropDownList>
                    <br />
                        <asp:Label ID="lblMonthlyPrint" runat="server" Text=""></asp:Label>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                   <td align="center">
                        <uc2:PrintFooter ID="PrintingControlResidentInfo2" runat="server" />
                   </td> 
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
