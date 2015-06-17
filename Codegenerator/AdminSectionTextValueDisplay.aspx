<%@ Page Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true"
    CodeFile="AdminSectionTextValueDisplay.aspx.cs" Inherits="AdminSectionTextValueDisplay" Title="Display SectionTextValue By Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .gridCss
        {
            width: 100%;
            padding: 20px 10px 10px 10px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
        <asp:GridView ID="gvSectionTextValue" runat="server" AutoGenerateColumns="false" CssClass="gridCss">
            <Columns>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbSelect" runat="server" CommandArgument='<%#Eval("SectionTextValueID") %>' OnClick="lbSelect_Click">
                            Select
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CarePlanDateTimeID">
                    <ItemTemplate>
                        <asp:Label ID="lblCarePlanDateTimeID" runat="server" Text='<%#Eval("CarePlanDateTimeID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Section_2">
                    <ItemTemplate>
                        <asp:Label ID="lblSection_2" runat="server" Text='<%#Eval("Section_2") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Section_3">
                    <ItemTemplate>
                        <asp:Label ID="lblSection_3" runat="server" Text='<%#Eval("Section_3") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Section_6">
                    <ItemTemplate>
                        <asp:Label ID="lblSection_6" runat="server" Text='<%#Eval("Section_6") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Section_7">
                    <ItemTemplate>
                        <asp:Label ID="lblSection_7" runat="server" Text='<%#Eval("Section_7") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AddedBy">
                    <ItemTemplate>
                        <asp:Label ID="lblAddedBy" runat="server" Text='<%#Eval("AddedBy") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AddedDate">
                    <ItemTemplate>
                        <asp:Label ID="lblAddedDate" runat="server" Text='<%#Eval("AddedDate") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UpdatedBy">
                    <ItemTemplate>
                        <asp:Label ID="lblUpdatedBy" runat="server" Text='<%#Eval("UpdatedBy") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UpdatedDate">
                    <ItemTemplate>
                        <asp:Label ID="lblUpdatedDate" runat="server" Text='<%#Eval("UpdatedDate") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("SectionTextValueID") %>' OnClick="lbDelete_Click">
                            Delete
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
