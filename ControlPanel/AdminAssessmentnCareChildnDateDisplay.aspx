<%@ Page Language="C#" MasterPageFile="~/Login/AdminMaster.master" AutoEventWireup="true"
    CodeFile="AdminAssessmentnCareChildnDateDisplay.aspx.cs" Inherits="AdminAssessmentnCareChildnDateDisplay" Title="Display AssessmentnCareChildnDate By Admin" %>

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
        <asp:GridView ID="gvAssessmentnCareChildnDate" runat="server" AutoGenerateColumns="false" CssClass="gridCss">
            <Columns>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbSelect" runat="server" CommandArgument='<%#Eval("AssessmentnCareChildnDateID") %>' OnClick="lbSelect_Click">
                            Select
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AssessmentnCareChildID">
                    <ItemTemplate>
                        <asp:Label ID="lblAssessmentnCareChildID" runat="server" Text='<%#Eval("AssessmentnCareChildID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AssessmentnCareDateID">
                    <ItemTemplate>
                        <asp:Label ID="lblAssessmentnCareDateID" runat="server" Text='<%#Eval("AssessmentnCareDateID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("AssessmentnCareChildnDateID") %>' OnClick="lbDelete_Click">
                            Delete
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
