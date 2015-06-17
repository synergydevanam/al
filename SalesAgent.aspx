<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="SalesAgent.aspx.cs" Inherits="SalesAgent" %>

<asp:Content ID="ContentPlaceHolder1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="container" class="minHeight">
        <div id="sidebar">
            <div class="sidebar_menu_title">
                <h5>
                    Customer</h5>
                <ul>
                    <li><a href="CustomerInsert.aspx">Add Customer</a></li>
                    <li><a href="DisplayCustomer.aspx">Display Customer</a> </li>
                    <li><a href="Admin/AdminDisplayClient.aspx">Appoinments</a> </li>
                </ul>
            </div>
            
        </div>
    </div>
</asp:Content>
