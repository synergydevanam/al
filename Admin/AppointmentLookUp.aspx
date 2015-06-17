<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="AppointmentLookUp.aspx.cs" Inherits="Admin_AppointmentLookUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        jQuery(document).ready(function ($) {
            var dates = $("#ctl00_ContentPlaceHolder1_txtDateFrom , #ctl00_ContentPlaceHolder1_txtDateTo").datepicker({
                defaultDate: "+1w",
                changeMonth: true,
                numberOfMonths: 1
            });



        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3>
       
    <div id="divSearch">
        
        <asp:Label runat="server" ID="lblDateForm" Text="Date From"></asp:Label>
        <asp:TextBox runat="server" ID="txtDateFrom"></asp:TextBox>
        To
        <asp:Label runat="server" ID="lblDateTo"></asp:Label>
        <asp:TextBox runat="server" ID="txtDateTo"></asp:TextBox>
        <br />
        <asp:Button runat="server" ID="btnSearch" Text="Search" OnClick="btnSearch_Click" />
    </div>
    <br />
    <asp:GridView ID="gvAppointmnet" runat="server" AutoGenerateColumns="false" AlternatingRowStyle-CssClass="even"
        HeaderStyle-CssClass="grid_head_css" CssClass="grid">
        <Columns>
            <asp:TemplateField HeaderText="FirstName">
                <ItemTemplate>
                    <asp:Label ID="lblFirstName" runat="server" Text='<%#Eval("FirstName") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="LastName">
                <ItemTemplate>
                    <asp:Label ID="lblLastName" runat="server" Text='<%#Eval("LastName") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PrimaryPhone">
                <ItemTemplate>
                    <asp:Label ID="lblPrimaryPhone" runat="server" Text='<%#Eval("PrimaryPhone") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
           
            <asp:TemplateField HeaderText="Appt Date">
                <ItemTemplate>
                    <asp:Label ID="lblDate" runat="server" Text='<%# Eval("Date", "{0:MM/dd/yyyy}")  %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Appt Time">
                <ItemTemplate>
                    <asp:Label ID="lblTime" runat="server" Text='<%#Eval("Time") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Create By">
                <ItemTemplate>
                    <asp:Label ID="lblCreateBy" runat="server" Text='<%#Eval("CreateBy") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Stastus">
                <ItemTemplate>
                    <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
