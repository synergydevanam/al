<%@ Page Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true"
    CodeFile="AdminMedicationTimeDisplay.aspx.cs" Inherits="AdminMedicationTimeDisplay" Title="Display MedicationTime By Admin" %>

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
        <asp:GridView ID="gvMedicationTime" runat="server" AutoGenerateColumns="false" CssClass="gridCss">
            <Columns>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbSelect" runat="server" CommandArgument='<%#Eval("MedicationTimeID") %>' OnClick="lbSelect_Click">
                            Select
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TakingTime">
                    <ItemTemplate>
                        <asp:Label ID="lblTakingTime" runat="server" Text='<%#Eval("TakingTime") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MedicineID">
                    <ItemTemplate>
                        <asp:Label ID="lblMedicineID" runat="server" Text='<%#Eval("MedicineID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ResidentID">
                    <ItemTemplate>
                        <asp:Label ID="lblResidentID" runat="server" Text='<%#Eval("ResidentID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("Quantity") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quality">
                    <ItemTemplate>
                        <asp:Label ID="lblQuality" runat="server" Text='<%#Eval("Quality") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Frequency">
                    <ItemTemplate>
                        <asp:Label ID="lblFrequency" runat="server" Text='<%#Eval("Frequency") %>'>
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
                <asp:TemplateField HeaderText="UpdateBy">
                    <ItemTemplate>
                        <asp:Label ID="lblUpdateBy" runat="server" Text='<%#Eval("UpdateBy") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UpdateDate">
                    <ItemTemplate>
                        <asp:Label ID="lblUpdateDate" runat="server" Text='<%#Eval("UpdateDate") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("MedicationTimeID") %>' OnClick="lbDelete_Click">
                            Delete
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
