<%@ Page Language="C#" MasterPageFile="~/WithoutLeftMenu.master" AutoEventWireup="true"
    CodeFile="AdminResidentDisplay.aspx.cs" Inherits="AdminResidentDisplay" Title="Display Resident By Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .gridCss
        {
            width: 100%;
            padding: 20px 10px 10px 10px;
            text-align: center;
        }
        .col_detail
        {
            display: none;
        }
        .col_detail li
        {
            padding-bottom: 5px;
        }
    </style>
    <script type="text/javascript">
        function expandDetailsInGrid(_this) {
            var id = _this.id;
            var imgelem = document.getElementById(_this.id);
            var currowid = id.replace("A_View", "TR_Summmary") //GETTING THE ID OF SUMMARY ROW

            var rowdetelemid = currowid;
            var rowdetelem = document.getElementById(rowdetelemid);
            if (imgelem.alt == "plus") {
                imgelem.src = "../App_Themes/Default/images/minus.gif"
                imgelem.alt = "minus"
                rowdetelem.style.display = 'block';
            }
            else {
                imgelem.src = "../App_Themes/Default/images/plus.gif"
                imgelem.alt = "plus"
                rowdetelem.style.display = 'none';
            }

            return false;

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hfHasSearchDone" Value="0" runat="server" />
            <div class="single_colom">
                <div style="padding: 20px;">
                    <table width="100%">
                        <tr>
                            <td>
                                <p>
                                    Resident Search<asp:Label ID="lblCount" runat="server" Text=""></asp:Label></p>
                            </td>
                            <td style="float: left; padding-left: 20px;">
                                <p>
                                    Property:
                                    <asp:DropDownList ID="ddlPropertyID" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPropertyID_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    Status<asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPropertyID_SelectedIndexChanged">
                                        <asp:ListItem Value="All">All</asp:ListItem>
                                        <asp:ListItem Value="Active" Selected="True">Active</asp:ListItem>
                                        <asp:ListItem Value="InActive">InActive</asp:ListItem>
                                    </asp:DropDownList>
                                </p>
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="gvResident" runat="server" AutoGenerateColumns="false" HeaderStyle-CssClass="grid_head_css"
                        CssClass="grid gridResidentDisplay">
                        <HeaderStyle BackColor="#DFEAF5" />
                        <Columns>
                        <asp:TemplateField HeaderText="Property">
                                <ItemTemplate>
                                    <asp:Label ID="lblProperty" runat="server" Text='<%#Eval("ExtraField7") %>'>
                        </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Resident Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'>
                        </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Admission Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblAdmissionDate" runat="server" Text='<%#Eval("AdmissionDate","{0:MM/dd/yyyy}") %>'>
                        </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Admission From">
                                <ItemTemplate>
                                    <asp:Label ID="lblAdmissionFrom" runat="server" Text='<%#Eval("AdmissionFrom") %>'>
                        </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="UsualOccupation">
                    <ItemTemplate>
                        <asp:Label ID="lblUsualOccupation" runat="server" Text='<%#Eval("UsualOccupation") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                            <%--<asp:TemplateField HeaderText="PlaceOfBirth">
                    <ItemTemplate>
                        <asp:Label ID="lblPlaceOfBirth" runat="server" Text='<%#Eval("PlaceOfBirth") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                            <%--<asp:TemplateField HeaderText="Email">
                    <ItemTemplate>
                        <asp:Label ID="lblUsualAddress" runat="server" Text='<%#Eval("UsualAddress") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Phone">
                                <ItemTemplate>
                                    <asp:Label ID="lblTelephone" runat="server" Text='<%#Eval("Telephone") %>'>
                        </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Race">
                    <ItemTemplate>
                        <asp:Label ID="lblRace" runat="server" Text='<%#Eval("Race") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Age">
                                <ItemTemplate>
                                    <asp:Label ID="lblAge" runat="server" Text='<%#Eval("Age") %>'>
                        </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="DateOfBirth">
                    <ItemTemplate>
                        <asp:Label ID="lblDateOfBirth" runat="server" Text='<%#Eval("DateOfBirth") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Sex">
                                <ItemTemplate>
                                    <asp:Label ID="lblSex" runat="server" Text='<%#Eval("Sex") %>'>
                        </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("ResidentID") %>'
                                        AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                                    <%--<asp:ImageButton runat="server" ID="lbDelete"  CommandArgument='<%#Eval("ResidentID") %>' OnClick="lbDelete_Click"  AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png"/>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Link">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:ImageButton OnClientClick="expandDetailsInGrid(this);return false;" runat="server" 
                                                    ID="A_View" ImageUrl="../App_Themes/Default/images/plus.gif" AlternateText="plus" />
                                                <%--Tasks--%>
                                            </td>
                                            <td id="TR_Summmary" runat="server" class="col_detail">
                                                <ul>
                                                    <li runat="server" id="li_ADLRecord" visible='<%#Eval("li_ADLRecord") %>'>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:Image ID="Image1" runat="server" ImageUrl="http://www.streetdirectory.com/img/arrow/sd_white_arrow.gif" />
                                                                </td>
                                                                <td valign="top">
                                                                    <a href='ADLRecord.aspx?ResidentID=<%#Eval("ResidentID") %>' style="text-decoration: underline;
                                                                        color: Blue;">ADL Record </a>
                                                                        &nbsp;
                                                                         <a href='ADLRecord_MonthlyPrint.aspx?Title=Monthly ADL Report&ResidentID=<%#Eval("ResidentID") %>'
                                                                            style="text-decoration: underline; color: Blue;">Print Report</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </li>
                                                    <li runat="server" id="li_ComprehensiveAssessment" visible='<%#Eval("li_ComprehensiveAssessment") %>'>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:Image ID="Image7" runat="server" ImageUrl="http://www.streetdirectory.com/img/arrow/sd_white_arrow.gif" />
                                                                </td>
                                                                <td valign="top">
                                                                    <a href='AssessmentnCare.aspx?ResidentID=<%#Eval("ResidentID") %>' style="text-decoration: underline;
                                                                        color: Blue;">Comprehensive Assessment</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </li>
                                                    <li  runat="server" id="li_ServiceCareAssessment" visible='<%#Eval("li_ServiceCareAssessment") %>'>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:Image ID="Image5" runat="server" ImageUrl="http://www.streetdirectory.com/img/arrow/sd_white_arrow.gif" />
                                                                </td>
                                                                <td valign="top">
                                                                    <a href='ServiceCarePlanAssessment.aspx?ResidentID=<%#Eval("ResidentID") %>' style="text-decoration: underline;
                                                                        color: Blue;">Service Care & Assessment</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </li>
                                                    <li runat="server" id="li_Medicaiton" visible='<%#Eval("li_Medicaiton") %>'>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:Image ID="Image2" runat="server" ImageUrl="http://www.streetdirectory.com/img/arrow/sd_white_arrow.gif" />
                                                                </td>
                                                                <td valign="top">
                                                                    <a href='Medicaiton_MonthlyMedicaionAdministrationRecord.aspx?residentID=<%#Eval("ResidentID") %>'
                                                                        style="text-decoration: underline; color: Blue;">Medicaiton</a> &nbsp; <a href='Medication_MonthlyPrint.aspx?Title=Monthly medication Report&ResidentID=<%#Eval("ResidentID") %>'
                                                                            style="text-decoration: underline; color: Blue;">Print Report</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </li>
                                                    <li runat="server" id="li_ObservationLog" visible='<%#Eval("li_ObservationLog") %>'>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:Image ID="Image3" runat="server" ImageUrl="http://www.streetdirectory.com/img/arrow/sd_white_arrow.gif" />
                                                                </td>
                                                                <td valign="top">
                                                                    <a href='ObservationNote.aspx?residentID=<%#Eval("ResidentID") %>' style="text-decoration: underline;
                                                                        color: Blue;">Observation Log</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </li>
                                                    <li runat="server" id="li_DoctorsOrder" visible='<%#Eval("li_DoctorsOrder") %>'>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:Image ID="Image4" runat="server" ImageUrl="http://www.streetdirectory.com/img/arrow/sd_white_arrow.gif" />
                                                                </td>
                                                                <td valign="top">
                                                                    <a href='DoctorsOrder.aspx?residentID=<%#Eval("ResidentID") %>' style="text-decoration: underline;
                                                                        color: Blue;">Doctor's Order</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </li>
                                                </ul>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <h3>
                                No Resident matches the search criteria please change</h3>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
