<%@ Page Language="C#" MasterPageFile="~/Login/AdminMaster.master" AutoEventWireup="true"
    CodeFile="AdminADLItemDisplay.aspx.cs" Inherits="AdminADLItemDisplay" Title="Display ADLItem By Admin" %>

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
        <asp:GridView ID="gvADLItem" runat="server" AutoGenerateColumns="false" CssClass="gridCss">
            <Columns>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbSelect" runat="server" CommandArgument='<%#Eval("ADLItemID") %>' OnClick="lbSelect_Click">
                            Select
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ADLItemName">
                    <ItemTemplate>
                        <asp:Label ID="lblADLItemName" runat="server" Text='<%#Eval("ADLItemName") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ADLItemDescriptionID">
                    <ItemTemplate>
                        <asp:Label ID="lblADLItemDescriptionID" runat="server" Text='<%#Eval("ADLItemDescriptionID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ADLStatusID">
                    <ItemTemplate>
                        <asp:Label ID="lblADLStatusID" runat="server" Text='<%#Eval("ADLStatusID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ResidentID">
                    <ItemTemplate>
                        <asp:Label ID="lblResidentID" runat="server" Text='<%#Eval("ResidentID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="IteamTime">
                    <ItemTemplate>
                        <asp:Label ID="lblIteamTime" runat="server" Text='<%#Eval("IteamTime") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Comment">
                    <ItemTemplate>
                        <asp:Label ID="lblComment" runat="server" Text='<%#Eval("Comment") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField1">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField1" runat="server" Text='<%#Eval("ExtraField1") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField2">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField2" runat="server" Text='<%#Eval("ExtraField2") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField3">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField3" runat="server" Text='<%#Eval("ExtraField3") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField4">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField4" runat="server" Text='<%#Eval("ExtraField4") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField5">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField5" runat="server" Text='<%#Eval("ExtraField5") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField6">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField6" runat="server" Text='<%#Eval("ExtraField6") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField7">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField7" runat="server" Text='<%#Eval("ExtraField7") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField8">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField8" runat="server" Text='<%#Eval("ExtraField8") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField9">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField9" runat="server" Text='<%#Eval("ExtraField9") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField10">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField10" runat="server" Text='<%#Eval("ExtraField10") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("ADLItemID") %>' OnClick="lbDelete_Click">
                            Delete
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
