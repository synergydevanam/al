<%@ Page Language="C#" MasterPageFile="~/WithoutLeftMenu.master" AutoEventWireup="true" 
CodeFile="AdminResidentInsertUpdate.aspx.cs" Inherits="AdminResidentInsertUpdate" Title="Resident Insert/Update By Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .minHeight
        {
        	background: none repeat scroll 0 0 #EDEDED;
        	margin-top: 0px;
            padding:0px;}
    </style>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <link href="../css/jquery-ui-1.8.20.custom.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery.ui.timepicker.js" type="text/javascript"></script>
    <script src="../js/jquery-ui-1.8.20.custom.min.js" type="text/javascript"></script>
    <link href="../css/jquery.ui.timepicker.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        jQuery(document).ready(function ($) {

            var dates = $('#<%= txtAdmissionDate.ClientID %>').datepicker({
                defaultDate: "+1w",
                changeMonth: true,
                changeYear: true,
                numberOfMonths: 1,
                onSelect: function (selectedDate) {
                    var option = this.id == "from" ? "minDate" : "maxDate",
					instance = $(this).data("datepicker"),
					date = $.datepicker.parseDate(
						instance.settings.dateFormat ||
						$.datepicker._defaults.dateFormat,
						selectedDate, instance.settings);
                    dates.not(this).datepicker("option", option, date);
                }
            });



            var dates = $('#<%= txtDateOfBirth.ClientID %>').datepicker({
                defaultDate: "+1w",
                changeMonth: true,
                changeYear: true,
                numberOfMonths: 1,
                onSelect: function (selectedDate) {
                    var option = this.id == "from" ? "minDate" : "maxDate",
					instance = $(this).data("datepicker"),
					date = $.datepicker.parseDate(
						instance.settings.dateFormat ||
						$.datepicker._defaults.dateFormat,
						selectedDate, instance.settings);
                    dates.not(this).datepicker("option", option, date);
                }
            });


            var dates = $('#<%= txtDateofLastPhysicalExam.ClientID %>').datepicker({
                defaultDate: "+1w",
                changeMonth: true,
                changeYear: true,
                numberOfMonths: 1,
                onSelect: function (selectedDate) {
                    var option = this.id == "from" ? "minDate" : "maxDate",
					instance = $(this).data("datepicker"),
					date = $.datepicker.parseDate(
						instance.settings.dateFormat ||
						$.datepicker._defaults.dateFormat,
						selectedDate, instance.settings);
                    dates.not(this).datepicker("option", option, date);
                }
            });

            var dates = $('#<%= txtDischargedOrExpiredDate.ClientID %>').datepicker({
                defaultDate: "+1w",
                changeMonth: true,
                changeYear: true,
                numberOfMonths: 1,
                onSelect: function (selectedDate) {
                    var option = this.id == "from" ? "minDate" : "maxDate",
					instance = $(this).data("datepicker"),
					date = $.datepicker.parseDate(
						instance.settings.dateFormat ||
						$.datepicker._defaults.dateFormat,
						selectedDate, instance.settings);
                    dates.not(this).datepicker("option", option, date);
                }
            });


        });
       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div id="main_form">
    
    <table width="100%">
    <tr>
        <td><p>Resident info</p></td>
        <td style="float:right;padding-right:8px;"><p>
        <asp:Label ID="lblMsg1" runat="server" ForeColor="Green"   Text="Update Successfully"  Visible="false"></asp:Label>
        
            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click"  class="add_btn"/>
                    <asp:Button ID="btnUpdate" runat="server" Text="Update"  class="add_btn" Visible="false"
                        OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnClear" runat="server" Text="Clear" class="add_btn" Visible="false" OnClick="btnClear_Click" />
            
        </p></td>
    </tr>
   </table>
    <ul>
    <li class="text_box">
                    <asp:Label ID="Label3" runat="server" Text="Status: ">
                    </asp:Label>
               </li>
            <li >
                    <asp:DropDownList ID="ddlStatus" runat="server">
                    <asp:ListItem Value="Active">Active</asp:ListItem>
                    <asp:ListItem Value="InActive">InActive</asp:ListItem>
                    </asp:DropDownList>
               </li>
               <li><div class="clear"></div></li>
    <li class="text_box">
                    <asp:Label ID="lblCountryID" runat="server" Text="Property: ">
                    </asp:Label>
               </li>
    <li >
                    <asp:DropDownList ID="ddlPropertyID" runat="server">
                    </asp:DropDownList>
               </li>
               <li><div class="clear"></div></li>
    <li class="text_box">
                    <asp:Label ID="lblName" runat="server" Text="Name: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtName" runat="server" Text="">
                    </asp:TextBox>
                </li>
    <li class="text_box">
                    <asp:Label ID="lblAdmissionDate" runat="server" Text="Admission Date: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtAdmissionDate" runat="server" Text="">
                    </asp:TextBox>
                    <%--<ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="ajCal" runat="server" TargetControlID="txtAdmissionDate">
                                    </ajaxToolkit:CalendarExtender>--%>
                </li>
                <li class="text_box">
                    <asp:Label ID="Label2" runat="server" Text="Primary Language: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtExtraField8" runat="server" Text="">
                    </asp:TextBox>
                    <%--<ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="ajCal" runat="server" TargetControlID="txtAdmissionDate">
                                    </ajaxToolkit:CalendarExtender>--%>
                </li>
    <li class="text_box">
                    <asp:Label ID="lblAdmissionFrom" runat="server" Text="Admission From: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtAdmissionFrom" runat="server" Text="">
                    </asp:TextBox>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblUsualOccupation" runat="server" Text="Usual Occupation: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtUsualOccupation" runat="server" Text="">
                    </asp:TextBox>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblPlaceOfBirth" runat="server" Text="Place Of Birth: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtPlaceOfBirth" runat="server" Text="">
                    </asp:TextBox>
                </li>
    <li class="text_box">
                    <asp:Label ID="lblUsualAddress" runat="server" Text="Usual Address: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtUsualAddress" runat="server" Text="" TextMode="MultiLine">
                    </asp:TextBox>
                </li>
    <li class="text_box">
                    <asp:Label ID="lblTelephone" runat="server" Text="Telephone: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtTelephone" runat="server" Text="">
                    </asp:TextBox>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblRace" runat="server" Text="Race: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtRace" runat="server" Text="">
                    </asp:TextBox>
                 </li>
                 <li class="text_box">
                    <asp:Label ID="lblDateOfBirth" runat="server" Text="Date Of Birth: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtDateOfBirth" runat="server" Text="" AutoPostBack="true" 
                        ontextchanged="txtDateOfBirth_TextChanged">
                    </asp:TextBox>
                    <%--<ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="CalendarExtender1" runat="server" TargetControlID="txtDateOfBirth">
                                    </ajaxToolkit:CalendarExtender>--%>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblAge" runat="server" Text="Age: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtAge" runat="server" Text="0" Enabled="false">
                    </asp:TextBox>
                 </li>
    
    <li class="text_box">
                    <asp:Label ID="lblSex" runat="server" Text="Sex: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtSex" runat="server" Text="">
                    </asp:TextBox>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblMaritalStatus" runat="server" Text="Marital Status: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtMaritalStatus" runat="server" Text="">
                    </asp:TextBox>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblHeight" runat="server" Text="Height: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtHeight" runat="server" Text="">
                    </asp:TextBox>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblWeight" runat="server" Text="Weight: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtWeight" runat="server" Text="">
                    </asp:TextBox>
                </li>
    <li class="text_box">
                    <asp:Label ID="lblReligion" runat="server" Text="Religion: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtReligion" runat="server" Text="">
                    </asp:TextBox>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblClergyman" runat="server" Text="Clergyman: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtClergyman" runat="server" Text="">
                    </asp:TextBox>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblChurchSynagogue" runat="server" Text="Church Synagogue: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtChurchSynagogue" runat="server" Text="">
                    </asp:TextBox>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblChurchSynagogueTelephone" runat="server" Text="Telephone: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtChurchSynagogueTelephone" runat="server" Text="">
                    </asp:TextBox>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblAddress" runat="server" Text="Address: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtAddress" runat="server" Text="" TextMode="MultiLine">
                    </asp:TextBox>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblAddressTelephone" runat="server" Text="Telephone: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtAddressTelephone" runat="server" Text="">
                    </asp:TextBox>
                </li>
    <li class="text_box">
                    <asp:Label ID="lblSocialSecurity" runat="server" Text="Social Security: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtSocialSecurity" runat="server" Text="">
                    </asp:TextBox>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblMedicare" runat="server" Text="Medicare: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtMedicare" runat="server" Text="">
                    </asp:TextBox>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblMedicaid" runat="server" Text="Medicaid: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtMedicaid" runat="server" Text="">
                    </asp:TextBox><h4>Insurance</h4>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblInsurance" runat="server" Text="Insurance: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtInsurance" runat="server" Text="">
                    </asp:TextBox>
                </li>
    <li class="text_box">
                    <asp:Label ID="lblInsuranceAddress" runat="server" Text="Address: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtInsuranceAddress" runat="server" Text="" TextMode="MultiLine">
                    </asp:TextBox>
                </li>
    <li class="text_box">
                    <asp:Label ID="lblInsuranceAddressTelephone" runat="server" Text="Telephone: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtInsuranceAddressTelephone" runat="server" Text="">
                    </asp:TextBox>
                </li>
    <li class="text_box">
                    <asp:Label ID="lblPolicy" runat="server" Text="Policy: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtPolicy" runat="server" Text="">
                    </asp:TextBox>
                </li>
    <li class="text_box">
                    <asp:Label ID="lblInsuranceGroup" runat="server" Text="Group: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtInsuranceGroup" runat="server" Text="">
                    </asp:TextBox>
                </li>
    <li class="text_box">
                    <asp:Label ID="lblInsuranceGroupNo" runat="server" Text="Group #: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtInsuranceGroupNo" runat="server" Text="">
                    </asp:TextBox><h4>Hospital</h4>
                </li>
    <li class="text_box">
                    <asp:Label ID="lblHospitalPreference" runat="server" Text="Hospital Preference: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtHospitalPreference" runat="server" Text="">
                    </asp:TextBox>
                </li>
    <li class="text_box">
                    <asp:Label ID="lblHospitalPreferenceTelephone" runat="server" Text="Telephone: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtHospitalPreferenceTelephone" runat="server" Text="">
                    </asp:TextBox>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblHospitalPreferenceEmail" runat="server" Text="Email: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtHospitalPreferenceEmail" runat="server" Text="">
                    </asp:TextBox><h4>Funeral</h4>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblFuneralHomePreference" runat="server" Text="Funeral Home Preference: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtFuneralHomePreference" runat="server" Text="">
                    </asp:TextBox>
                </li>
    <li class="text_box">
                    <asp:Label ID="lblFuneralHomePreferenceTelephone" runat="server" Text="Telephone: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtFuneralHomePreferenceTelephone" runat="server" Text="">
                    </asp:TextBox><h4>Pharmacy</h4>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblPharmacyPreference" runat="server" Text="Pharmacy Preference: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtPharmacyPreference" runat="server" Text="">
                    </asp:TextBox>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblPharmacyPreferenceTelephone" runat="server" Text="Telephone: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtPharmacyPreferenceTelephone" runat="server" Text="">
                    </asp:TextBox><h4>Dentist</h4>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblDentist" runat="server" Text="Dentist: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtDentist" runat="server" Text="">
                    </asp:TextBox>
                </li>
    <li class="text_box">
                    <asp:Label ID="lblDentistTelephone" runat="server" Text="Telephone: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtDentistTelephone" runat="server" Text="">
                    </asp:TextBox><h4>Physician</h4>
                 </li>
                 <li class="text_box">
                    <asp:Label ID="lblAttendingPhysician" runat="server" Text="Physician Name: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtAttendingPhysician" runat="server" Text="">
                    </asp:TextBox>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblAttendingPhysicianAddress" runat="server" Text="Address: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtAttendingPhysicianAddress" runat="server" Text="" TextMode="MultiLine">
                    </asp:TextBox>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblAttendingPhysicianTelephone" runat="server" Text="Telephone: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtAttendingPhysicianTelephone" runat="server" Text="">
                    </asp:TextBox><h4>Alternate Physician</h4>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblAlternatePhysician" runat="server" Text="Physician Name: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtAlternatePhysician" runat="server" Text="">
                    </asp:TextBox>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblAlternatePhysicianAddress" runat="server" Text="Address: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtAlternatePhysicianAddress" runat="server" Text="" TextMode="MultiLine">
                    </asp:TextBox>
                </li>
    <li class="text_box">
                    <asp:Label ID="lblAlternatePhysicianTelephone" runat="server" Text="Telephone: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtAlternatePhysicianTelephone" runat="server" Text="">
                    </asp:TextBox><h4>Physical Exam</h4>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblDateofLastPhysicalExam" runat="server" Text="Date of Last Physical Exam: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtDateofLastPhysicalExam" runat="server" Text="">
                    </asp:TextBox>
                    <%--<ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="CalendarExtender2" runat="server" TargetControlID="txtDateofLastPhysicalExam">
                                    </ajaxToolkit:CalendarExtender>--%>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblYearlyPhysicalDue" runat="server" Text="Yearly Physical Due: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtYearlyPhysicalDue" runat="server" Text="">
                    </asp:TextBox>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblDiagnosis" runat="server" Text="Diagnosis: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtDiagnosis" runat="server" Text="" TextMode="MultiLine">
                    </asp:TextBox>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblAllergies" runat="server" Text="Allergies: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtAllergies" runat="server" Text="" TextMode="MultiLine">
                    </asp:TextBox>
                 </li>
    

   </ul>
             </div>
        <div class="sub_form" id="fileUpload" runat="server">
            <table width="100%">
                <tr>
                    <td>
                        <p>
                            Document Upload</p>
                    </td>
                    <td style="float: right; padding-right: 8px;">
                        <p>
                            <asp:Label ID="Label1" runat="server" ForeColor="Green" Text="Update Successfully"
                                Visible="false"></asp:Label>
                            <asp:Button ID="Button1" runat="server" Text="Add" OnClick="btnUpload_Click" class="add_btn" />
                            <asp:Button ID="Button2" runat="server" Text="Update" class="add_btn" Visible="false"
                                OnClick="btnUpload_Click" />
                            <asp:Button ID="Button4" runat="server" Text="Clear" class="add_btn" Visible="false"
                                OnClick="btnClear_Click" />
                        </p>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <ul>
                            <li class="text_box">Select File </li>
                            <li class="text_input1">
                                <asp:FileUpload ID="uplFile" runat="server" onchange="checkFileExtension(this);" />
                            </li>
                            </ul>
                            </td>
                            </tr>
                <tr>
                    <td> <ul>
                            <li class="text_box">File Description </li>
                            <li class="text_input1">
                                <asp:TextBox ID="txDocumentDetails" runat="server" Text=""></asp:TextBox>
                            </li>
                        </ul>
                    </td>
                </tr>
                <tr>
                    <td>
            <asp:GridView ID="gvDocument" runat="server" AutoGenerateColumns="false"  HeaderStyle-CssClass="grid_head_css"  CssClass="grid">
                <HeaderStyle BackColor="#DFEAF5" />
                <Columns>
                    <%--<asp:TemplateField HeaderText="No">
                        <ItemTemplate>
                            <asp:Label ID="lblDocumentID" runat="server" Text='<%#Eval("DocumentID") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Description">
                        <ItemTemplate>
                            <asp:Label ID="lblDetails" runat="server" Text='<%#Eval("Details") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Document">
                        <ItemTemplate>
                            <span>
                                <a  style="color:Blue;text-decoration:underline;" href='<%#Eval("FileName") %>' target="_blank">View</a>
                            <%--<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#Eval("FileName") %>'
                                Target="_blank" Text="View"></asp:HyperLink>--%></span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                             <asp:LinkButton ID="lbSelect" runat="server" ToolTip='<%#Eval("FileName") %>' CommandArgument='<%#Eval("DocumentID") %>' OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="lbSelect_Click">
                            Delete
                        </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </td>
                </tr>
            </table>
        </div>
<div class="sub_form">

<table width="100%">
    <tr>
        <td><p>Other Contact info</p></td>
        <td style="float:right;padding-right:8px;"><p>
        <asp:Label ID="lblMsg2" runat="server" ForeColor="Green"  Text="Update Successfully" Visible="false"></asp:Label>
        
            <asp:Button ID="btnAdd1" runat="server" Text="Add" OnClick="btnAdd_Click"  class="add_btn"/>
                    <asp:Button ID="btnUpdate1" runat="server" Text="Update"  class="add_btn" Visible="false"
                        OnClick="btnUpdate_Click" />
                    <asp:Button ID="Button3" runat="server" Text="Clear" class="add_btn" Visible="false" OnClick="btnClear_Click" />
            
        </p></td>
    </tr>
    <tr>
        <td colspan="2">
    
    <ul>
     <li class="text_box">
                    <asp:Label ID="lblResponsibleParty" runat="server" Text="Responsible Party: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtResponsibleParty" runat="server" Text="">
                    </asp:TextBox>
                </li>
    <li class="text_box">
                    <asp:Label ID="lblResponsiblePartyRelationship" runat="server" Text="Relationship: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtResponsiblePartyRelationship" runat="server" Text="">
                    </asp:TextBox>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblResponsiblePartyAddress" runat="server" Text="Address: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtResponsiblePartyAddress" runat="server" Text="" TextMode="MultiLine">
                    </asp:TextBox>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblResponsiblePartyTelephone" runat="server" Text="Telephone: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtResponsiblePartyTelephone" runat="server" Text="">
                    </asp:TextBox><h4>Power Of Attorney</h4>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblPowerOfAttorney" runat="server" Text="Power Of Attorney: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtPowerOfAttorney" runat="server" Text="">
                    </asp:TextBox>
                 </li>
    
    <li class="text_box">
                    <asp:Label ID="lblPowerOfAttorneyRelationship" runat="server" Text="Relationship: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtPowerOfAttorneyRelationship" runat="server" Text="">
                    </asp:TextBox>
                </li>
                <li class="text_box">
                    <asp:Label ID="lblPowerOfAttorneyAddress" runat="server" Text="Address: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtPowerOfAttorneyAddress" runat="server" Text="" TextMode="MultiLine">
                    </asp:TextBox>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblPowerOfAttorneyTelephone" runat="server" Text="Telephone: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtPowerOfAttorneyTelephone" runat="server" Text="">
                    </asp:TextBox><h4>In Case Of Emergency</h4>
                 </li>
                 <li class="text_box">
                    <asp:Label ID="lblNotifyInCaseOfEmergency" runat="server" Text="Notify In Case Of Emergency: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtNotifyInCaseOfEmergency" runat="server" Text="">
                    </asp:TextBox>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblNotifyInCaseOfEmergencyRelationship" runat="server" Text="Relationship: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtNotifyInCaseOfEmergencyRelationship" runat="server" Text="">
                    </asp:TextBox>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblNotifyInCaseOfEmergencyAddress" runat="server" Text="Address: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtNotifyInCaseOfEmergencyAddress" runat="server" Text="" TextMode="MultiLine">
                    </asp:TextBox>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblNotifyInCaseOfEmergencyTelephone" runat="server" Text="Telephone: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtNotifyInCaseOfEmergencyTelephone" runat="server" Text="">
                    </asp:TextBox><h4>Nearest Relative/Guardian</h4>
                    
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblNearestRelativeOrGuardian" runat="server" Text="Name: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtNearestRelativeOrGuardian" runat="server" Text="" Visible="false">
                    </asp:TextBox>
                    <asp:TextBox ID="txtContactInfoName" runat="server" Text=""></asp:TextBox>
                
        <asp:HiddenField ID="hfContactInfoID" runat="server" />
         </li>
    <li class="text_box">
                    <asp:Label ID="lblNearestRelativeOrGuardianRelationship" runat="server" Text="Relationship: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtNearestRelativeOrGuardianRelationship" runat="server" Text="" Visible="false">
                    </asp:TextBox>
                    <asp:TextBox ID="txtContactInfoRelation" runat="server" Text=""></asp:TextBox>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblNearestRelativeOrGuardianAddress" runat="server" Text="Address: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtNearestRelativeOrGuardianAddress" runat="server" Text=""  TextMode="MultiLine" Visible="false">
                    </asp:TextBox>
                    <asp:TextBox ID="txtContactInfoAddress" runat="server" Text="" TextMode="MultiLine" ></asp:TextBox>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblNearestRelativeOrGuardianTelephone" runat="server" Text="Telephone: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtNearestRelativeOrGuardianTelephone" runat="server" Text="" Visible="false">
                    </asp:TextBox>
                    <asp:TextBox ID="txtContactInfoTelephone" runat="server" Text=""></asp:TextBox>
                    <asp:Button ID="btnAddNearestRelative" runat="server" Text="Add"   
                        class="add_btn" onclick="btnAddNearestRelative_Click" 
                        />
                    <asp:Button ID="btnUpdateNearestRelative" runat="server" Text="Update"  
                        class="add_btn" Visible="false" onclick="btnUpdateNearestRelative_Click"
                         />
                 </li>
    
   
     </ul>
     </td>
    </tr>
<tr>
<td colspan="2">
     <br />
    <asp:GridView ID="gvContact" runat="server" AutoGenerateColumns="false"  HeaderStyle-CssClass="grid_head_css"  CssClass="grid" Width="100%">
                <HeaderStyle BackColor="#DFEAF5" />
                <Columns>
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbSelect" runat="server" CommandArgument='<%#Eval("ContactInfoID") %>' OnClick="lbSelectContactInfo_Click">
                            Edit
                        </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nearest Relative/Guardian">
                        <ItemTemplate>
                            <table width="370px" cellspacing="0">
                                <tr>
                                    <td width="30px">Name</td>
                                    <td width="5px">:</td>
                                    <td width="325px">
                                        <asp:Label ID="lblDetails" runat="server" Text='<%#Eval("Name") %>'>
                            </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Relationship</td>
                                    <td>:</td>
                                    <td>
                                    <asp:Label ID="lblRelation" runat="server" Text='<%#Eval("Relationship") %>'>
                            </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Address</td>
                                    <td>:</td>
                                    <td>
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("Address") %>'>
                            </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Telephone</td>
                                    <td>:</td>
                                    <td>
                                     <asp:Label ID="Label5" runat="server" Text='<%#Eval("Telephone") %>'>
                            </asp:Label>
                                    </td>
                                </tr>
                            </table>

                            
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                             <asp:LinkButton ID="lbDelete" runat="server"  CommandArgument='<%#Eval("ContactInfoID") %>' OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="lbDeleteContactInfo_Click">
                            Delete
                        </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </td></tr>
               </table>
</div>  


             <div class="sub_form">

    <table width="100%">
    <tr>
        <td><p><strong>Discharged / Expired</strong></p></td>
        <td style="float:right;padding-right:8px;"><p>
        
        <asp:Label ID="lblMsg3" runat="server" ForeColor="Green"  Text="Update Successfully" Visible="false"></asp:Label>
            <asp:Button ID="btnAdd2" runat="server" Text="Add" OnClick="btnAdd_Click"  class="add_btn"/>
                    <asp:Button ID="btnUpdate2" runat="server" Text="Update"  class="add_btn" Visible="false"
                        OnClick="btnUpdate_Click" />
                    <asp:Button ID="Button6" runat="server" Text="Clear" class="add_btn" Visible="false" OnClick="btnClear_Click" />
            
        </p></td>
    </tr>
   </table>
    <ul>
    
    <li class="text_box">
                    <asp:Label ID="lblDischargedOrExpiredDate" runat="server" Text="Discharged Or Expired Date: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtDischargedOrExpiredDate" runat="server" Text="">
                    </asp:TextBox>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblDischargedOrExpiredReason" runat="server" Text="Reason: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtDischargedOrExpiredReason" runat="server" Text="">
                    </asp:TextBox>
                 </li>
    <li class="text_box">
                    Without MD Approval?
                </li>
    <li class="text_input1">
                   <asp:CheckBox ID="cbIsWithoutMDApproval" runat="server" />
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblReleasedTo" runat="server" Text="Released To: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtReleasedTo" runat="server" Text="">
                    </asp:TextBox>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblNewAddress" runat="server" Text="New Address: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtNewAddress" runat="server" Text="" TextMode="MultiLine">
                    </asp:TextBox>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblPlaceOfDeathAddressnCitynCountynState" runat="server" Text="Place Of Death Address<br/>(City, County, State): ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtPlaceOfDeathAddressnCitynCountynState" runat="server" Text="" TextMode="MultiLine">
                    </asp:TextBox>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblPrecinctNo" runat="server" Text="Precinct No: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtPrecinctNo" runat="server" Text="">
                    </asp:TextBox>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblMorticianName" runat="server" Text="Mortician Name: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtMorticianName" runat="server" Text="">
                    </asp:TextBox>
                 </li>
    <li class="text_box">
                    <asp:Label ID="lblSignature" runat="server" Text="Signature: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtSignature" runat="server" Text="">
                    </asp:TextBox>
                 </li>
     
     </ul><br />
   

</div>
  <div class="sub_form">

    <table width="100%">
    <tr>
        <td><p><strong>Resident Billing Info</strong></p></td>
        <td style="float:right;padding-right:8px;"><p>
        
        <asp:Label ID="lblMsg4" runat="server" ForeColor="Green"  Text="Update Successfully" Visible="false"></asp:Label>
            <asp:Button ID="Button5" runat="server" Text="Add" OnClick="btnAdd_Click"  class="add_btn" Visible="false"/>
                    <asp:Button ID="Button7" runat="server" Text="Update"  class="add_btn" 
                        OnClick="btnUpdate_Click" />
                    <asp:Button ID="Button8" runat="server" Text="Clear" class="add_btn" Visible="false" OnClick="btnClear_Click" />
            
        </p></td>
    </tr>
   </table>
    <ul>
    
   
    <li class="text_box">
                    <asp:Label ID="Label6" runat="server" Text="Name(if different): ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtBillingName" runat="server" Text="">
                    </asp:TextBox>
                 </li>
   
    
    <li class="text_box">
                    <asp:Label ID="Label8" runat="server" Text="Address: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtBillingAddress" runat="server" Text="" TextMode="MultiLine">
                    </asp:TextBox>
                 </li>
                 <li class="text_box">
                    <asp:Label ID="Label7" runat="server" Text="City: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtBillingCity" runat="server" Text="">
                    </asp:TextBox>
                 </li>
    
    <li class="text_box">
                    <asp:Label ID="Label10" runat="server" Text="State: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtBillingState" runat="server" Text="">
                    </asp:TextBox>
                    <li class="text_box">
                    <asp:Label ID="Label9" runat="server" Text="Zip Code: ">
                    </asp:Label>
                </li>
    <li class="text_input1">
                    <asp:TextBox ID="txtBillingZipCode" runat="server" Text="">
                    </asp:TextBox>
                 </li>
   
     
     </ul><br />
   

</div>
</asp:Content>
