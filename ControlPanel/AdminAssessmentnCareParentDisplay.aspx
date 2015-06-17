<%@ Page Language="C#" MasterPageFile="~/Login/AdminMaster.master" AutoEventWireup="true"
    CodeFile="AdminAssessmentnCareParentDisplay.aspx.cs" Inherits="AdminAssessmentnCareParentDisplay" Title="Display AssessmentnCareParent By Admin" %>

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
        <asp:GridView ID="gvAssessmentnCareParent" runat="server" AutoGenerateColumns="false" CssClass="gridCss">
            <Columns>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbSelect" runat="server" CommandArgument='<%#Eval("AssessmentnCareParentID") %>' OnClick="lbSelect_Click">
                            Select
                        </asp:LinkButton>&nbsp;|&nbsp;
                        <a href='AdminAssessmentnCareChildInsertUpdate.aspx?assessmentnCareChildID=0&AssessmentnCareParentID=<%#Eval("AssessmentnCareParentID") %>' target="_blank">
                            Add Child
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AssessmentnCareParentName">
                    <ItemTemplate>
                        <asp:Label ID="lblAssessmentnCareParentName" runat="server" Text='<%#Eval("AssessmentnCareParentName") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("AssessmentnCareParentID") %>' OnClick="lbDelete_Click">
                            Delete
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
