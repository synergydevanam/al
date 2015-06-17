<%@ Page Language="C#" MasterPageFile="~/Login/AdminMaster.master" AutoEventWireup="true"
    CodeFile="AdminAL_HelpTypeDisplay.aspx.cs" Inherits="AdminAL_HelpTypeDisplay"
    Title="Display AL_HelpType By Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .gridCss
        {
            padding: 20px 10px 10px 10px;
            text-align: left;
        }
        #container div div
        {
            overflow: hidden;
        }
        .helpTypeName{color:blue;text-decoration:underline;}
        .helpTypeName:hover{color:blue;text-decoration:underline;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h1>
            How do I?</h1>
            <div style="padding:10px 0px;">
               <p style="padding:0px 10px;"> We have categorized most common questions you may have and their answers with a screen shot. If you still can not find the answer you are looking for email us to <a style="text-decoration:unerline;color:Blue;" href="mailto:support@caregivermax.com">support@caregivermax.com</a></p>
            </div>
        <asp:GridView ID="gvAL_HelpType" runat="server" AutoGenerateColumns="false" ShowHeader="false"
            CssClass="gridCss">
            <Columns>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbSelect" runat="server" CommandArgument='<%#Eval("AL_HelpTypeID") %>'
                            OnClick="lbSelect_Click">
                            <%# Container.DataItemIndex +1 %>
                            &nbsp.&nbsp
                            <asp:Label ID="lblHelpTypeName"  CssClass="helpTypeName"  runat="server" Text='<%#Eval("HelpTypeName") %>'>
                            </asp:Label>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <hr />
        <asp:Label ID="lblSelectedType" runat="server"></asp:Label>
        <asp:GridView ID="gvAL_Help" runat="server" AutoGenerateColumns="false" ShowHeader="false"
            CssClass="gridCss">
            <Columns>
                <asp:TemplateField HeaderText="Question">
                    <ItemTemplate>
                        Q:
                        <asp:Label ID="lblQuestion" runat="server" Text='<%#Eval("Question") %>'>
                        </asp:Label>
                        <hr />
                        A:
                        <asp:Label ID="lblAnswer" runat="server" Text='<%#Eval("Answer") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
