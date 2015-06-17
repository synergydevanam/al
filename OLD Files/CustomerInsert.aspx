<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="CustomerInsert.aspx.cs" Inherits="CustomerInsert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
     jQuery(document).ready(function ($) {
         var dates = $("#ctl00_ContentPlaceHolder1_txtTourDate").datepicker({
             defaultDate: "+1w",
             changeMonth: true,
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

         $('#ctl00_ContentPlaceHolder1_txtTourTime').timepicker({
             showPeriod: true,
             showLeadingZero: true
         });
         
     });
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="sidePanelContainer">
<div class="leftSidePanel">

	<div class="formPanel">
		<div class="formPanelHeader">
			<div class="sidePanelContainer">
				<div class="leftSidePanel">
					Customer
				</div>
				<div class="rightSidePanel">
					
							
						
				</div>
				<div class="break">
				</div>
			</div>
		</div>
		<div class="formPanelContent">
					
			
					
			
			
			
			
					
			<table cellspacing="0" style="width:100%;border-collapse:collapse;" id="contentAreaPlaceHolder_formView" autogeneraterows="False" class="formView">
		<tbody><tr>
			<td colspan="2">

					<table class="detailsView">
						<tbody><tr class="detailsViewRow">
							<td class="detailsViewFieldHeader">
								First Name
							</td>
							<td>
								<div class="columnContainer">
									<div class="columnLeft">
     <asp:TextBox ID="txtFirstName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                    *
										<span style="display:none;" class="error" id="contentAreaPlaceHolder_formView_ctl01">Required</span>
									</div>
									<div class="columnRight">
										Age:
										 <asp:TextBox ID="txtAge" class="txt small-input" runat="server" Text="">
    </asp:TextBox> 
										<span style="display:none;" class="error" id="contentAreaPlaceHolder_formView_RegularExpressionValidatorAge">Invalid</span>
									</div>
									<div class="break">
									</div>
								</div>
							</td>
						</tr>
						<tr class="detailsViewRow">
							<td class="detailsViewFieldHeader">
								Last Name
							</td>
							<td>
								 <asp:TextBox ID="txtLastName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
    <span style="display:none;" class="error" id="contentAreaPlaceHolder_formView_ctl02">Required</span>
							</td>
						</tr>
						<tr class="detailsViewRow">
							<td class="detailsViewFieldHeader">
								Guest Name
							</td>
							<td>
								<div class="columnContainer">
									<div class="columnLeft">
									 <asp:TextBox ID="txtGuestName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
     </div>
									<div class="columnRight">
										Guest Age:
										 <asp:TextBox ID="txtGuestAge" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
										<span style="display:none;" class="error" id="contentAreaPlaceHolder_formView_RegularExpressionValidatorGuestAge">Invalid</span>
									</div>
									<div class="break">
									</div>
								</div>
							</td>
						</tr>
						<tr class="detailsViewRow">
							<td class="detailsViewFieldHeader">
								Relationship
							</td>
							<td>
				  <asp:DropDownList ID="ddlRelationshipID" runat="server">
     </asp:DropDownList>
							</td>
						</tr>
						<tr class="detailsViewRow">
							<td class="detailsViewFieldHeader">
								Income
							</td>
							<td>
								    <asp:DropDownList ID="ddlIncomeID" runat="server">
     </asp:DropDownList>
							</td>
						</tr>
						<tr class="detailsViewRow">
							<td class="detailsViewFieldHeader">
								Primary Phone
							</td>
							<td>
							 <asp:TextBox ID="txtPrimaryPhone" class="txt large-input" runat="server" Text="">
    </asp:TextBox>	</td>
						</tr>
						<tr class="detailsViewRow">
							<td class="detailsViewFieldHeader">
								Secondary Phone
							</td>
							<td>
							 <asp:TextBox ID="txtSecondaryPhone" class="txt large-input" runat="server" Text="">
    </asp:TextBox>	</td>
						</tr>
						<tr class="detailsViewRow">
							<td class="detailsViewFieldHeader">
								Address
							</td>
							<td>
								 <asp:TextBox ID="txtAddress1" class="txt large-input" runat="server" Text="">
    </asp:TextBox></td>
						</tr>
						<tr class="detailsViewRow">
							<td class="detailsViewFieldHeader">
								Address 2
							</td>
							<td>
								 <asp:TextBox ID="txtAddress2" class="txt large-input" runat="server" Text="">
    </asp:TextBox></td>
						</tr>
						<tr class="detailsViewRow">
							<td class="detailsViewFieldHeader">
								City
							</td>
							<td>
								  <asp:TextBox ID="txtCity" class="txt large-input" runat="server" Text="">
    </asp:TextBox></td>
						</tr>
						<tr class="detailsViewRow">
							<td class="detailsViewFieldHeader">
								State
							</td>
							<td>
					     <asp:DropDownList ID="ddlState" runat="server">
            <asp:ListItem Selected="selected" Value="">( Select )</asp:ListItem>
            <asp:ListItem Value="">---- U.S. States----</asp:ListItem>
            <asp:ListItem Value="1">Alabama</asp:ListItem>
            <asp:ListItem Value="2">Alaska</asp:ListItem>
            <asp:ListItem Value="3">Arizona</asp:ListItem>
            <asp:ListItem Value="4">Arkansas</asp:ListItem>
            <asp:ListItem Value="5">California</asp:ListItem>
            <asp:ListItem Value="6">Colorado</asp:ListItem>
            <asp:ListItem Value="7">Connecticut</asp:ListItem>
            <asp:ListItem Value="8">Delaware</asp:ListItem>
            <asp:ListItem Value="101">District of Columbia</asp:ListItem>
            <asp:ListItem Value="9">Florida</asp:ListItem>
            <asp:ListItem Value="10">Georgia</asp:ListItem>
            <asp:ListItem Value="11">Hawaii</asp:ListItem>
            <asp:ListItem Value="12">Idaho</asp:ListItem>
            <asp:ListItem Value="13">Illinois</asp:ListItem>
            <asp:ListItem Value="14">Indiana</asp:ListItem>
            <asp:ListItem Value="15">Iowa</asp:ListItem>
            <asp:ListItem Value="16">Kansas</asp:ListItem>
            <asp:ListItem Value="17">Kentucky</asp:ListItem>
            <asp:ListItem Value="18">Louisiana</asp:ListItem>
            <asp:ListItem Value="19">Maine</asp:ListItem>
            <asp:ListItem Value="20">Maryland</asp:ListItem>
            <asp:ListItem Value="21">Massachusetts</asp:ListItem>
            <asp:ListItem Value="22">Michigan</asp:ListItem>
            <asp:ListItem Value="23">Minnesota</asp:ListItem>
            <asp:ListItem Value="24">Mississippi</asp:ListItem>
            <asp:ListItem Value="25">Missouri</asp:ListItem>
            <asp:ListItem Value="26">Montana</asp:ListItem>
            <asp:ListItem Value="27">Nebraska</asp:ListItem>
            <asp:ListItem Value="28">Nevada</asp:ListItem>
            <asp:ListItem Value="29">New Hampshire</asp:ListItem>
            <asp:ListItem Value="30">New Jersey</asp:ListItem>
            <asp:ListItem Value="31">New Mexico</asp:ListItem>
            <asp:ListItem Value="32">New York</asp:ListItem>
            <asp:ListItem Value="33">North Carolina</asp:ListItem>
            <asp:ListItem Value="34">North Dakota</asp:ListItem>
            <asp:ListItem Value="35">Ohio</asp:ListItem>
            <asp:ListItem Value="36">Oklahoma</asp:ListItem>
            <asp:ListItem Value="37">Oregon</asp:ListItem>
            <asp:ListItem Value="38">Pennsylvania</asp:ListItem>
            <asp:ListItem Value="39">Rhode Island</asp:ListItem>
            <asp:ListItem Value="40">South Carolina</asp:ListItem>
            <asp:ListItem Value="41">South Dakota</asp:ListItem>
            <asp:ListItem Value="42">Tennessee</asp:ListItem>
            <asp:ListItem Value="43">Texas</asp:ListItem>
            <asp:ListItem Value="44">Utah</asp:ListItem>
            <asp:ListItem Value="45">Vermont</asp:ListItem>
            <asp:ListItem Value="46">Virginia</asp:ListItem>
            <asp:ListItem Value="47">Washington</asp:ListItem>
            <asp:ListItem Value="48">West Virginia</asp:ListItem>
            <asp:ListItem Value="49">Wisconsin</asp:ListItem>
            <asp:ListItem Value="50">Wyoming</asp:ListItem>
            <asp:ListItem Value="">---- U.S. Territories----</asp:ListItem>
            <asp:ListItem Value="152">American Samoa</asp:ListItem>
            <asp:ListItem Value="203">Guam</asp:ListItem>
            <asp:ListItem Value="254">Marshall Islands</asp:ListItem>
            <asp:ListItem Value="305">Micronesia</asp:ListItem>
            <asp:ListItem Value="356">Northern Mariana Islands</asp:ListItem>
            <asp:ListItem Value="407">Puerto Rico</asp:ListItem>
            <asp:ListItem Value="458">Virgin Islands</asp:ListItem>
            <asp:ListItem Value="">---- Military Location----</asp:ListItem>
            <asp:ListItem Value="509">Armed Forces Americas</asp:ListItem>
            <asp:ListItem Value="560">Armed Forces Europe</asp:ListItem>
            <asp:ListItem Value="611">Armed Forces Pacific</asp:ListItem>
            <asp:ListItem Value="">---- Canadian Provinces----</asp:ListItem>
            <asp:ListItem Value="662">Alberta</asp:ListItem>
            <asp:ListItem Value="713">British Columbia</asp:ListItem>
            <asp:ListItem Value="764">Manitoba</asp:ListItem>
            <asp:ListItem Value="815">New Brunswick</asp:ListItem>
            <asp:ListItem Value="866">Newfoundland</asp:ListItem>
            <asp:ListItem Value="917">Northwest Territories</asp:ListItem>
            <asp:ListItem Value="968">Nova Scotia</asp:ListItem>
            <asp:ListItem Value="1019">Nunavit</asp:ListItem>
            <asp:ListItem Value="1070">Ontario</asp:ListItem>
            <asp:ListItem Value="1121">Prince Edward Island</asp:ListItem>
            <asp:ListItem Value="1172">Quebec</asp:ListItem>
            <asp:ListItem Value="1223">Saskatchewan</asp:ListItem>
            <asp:ListItem Value="1274">Yukon</asp:ListItem>
        </asp:DropDownList>
							</td>
						</tr>
						<tr class="detailsViewRow">
							<td class="detailsViewFieldHeader">
								Zipcode
							</td>
							<td>
								<asp:TextBox ID="txtZipcode" class="txt large-input" runat="server"></asp:TextBox>
&nbsp;</td>
						</tr>
						<tr class="detailsViewRow">
							<td class="detailsViewFieldHeader">
								Country
							</td>
							<td>
							        <asp:DropDownList ID="ddlCountry" runat="server" 
                                       >
            <asp:ListItem   Value="">( Select )</asp:ListItem>
            <asp:ListItem Value="1">United States</asp:ListItem>
            <asp:ListItem Value="38">Canada</asp:ListItem>
            <asp:ListItem Value="138">Mexico</asp:ListItem>
            <asp:ListItem Value="2">Afghanistan</asp:ListItem>
            <asp:ListItem Value="3">Albania</asp:ListItem>
            <asp:ListItem Value="4">Algeria</asp:ListItem>
            <asp:ListItem Value="5">American Samoa</asp:ListItem>
            <asp:ListItem Value="6">Andorra</asp:ListItem>
            <asp:ListItem Value="7">Anguilla</asp:ListItem>
            <asp:ListItem Value="8">Antarctica</asp:ListItem>
            <asp:ListItem Value="9">Antigua And Barbuda</asp:ListItem>
            <asp:ListItem Value="10">Argentina</asp:ListItem>
            <asp:ListItem Value="11">Armenia</asp:ListItem>
            <asp:ListItem Value="12">Aruba</asp:ListItem>
            <asp:ListItem Value="13">Australia</asp:ListItem>
            <asp:ListItem Value="14">Austria</asp:ListItem>
            <asp:ListItem Value="15">Azerbaijan</asp:ListItem>
            <asp:ListItem Value="16">Bahamas</asp:ListItem>
            <asp:ListItem Value="17">Bahrain</asp:ListItem>
            <asp:ListItem Value="18">Bangladesh</asp:ListItem>
            <asp:ListItem Value="19">Barbados</asp:ListItem>
            <asp:ListItem Value="20">Belarus</asp:ListItem>
            <asp:ListItem Value="21">Belgium</asp:ListItem>
            <asp:ListItem Value="22">Belize</asp:ListItem>
            <asp:ListItem Value="23">Benin</asp:ListItem>
            <asp:ListItem Value="24">Bermuda</asp:ListItem>
            <asp:ListItem Value="25">Bhutan</asp:ListItem>
            <asp:ListItem Value="26">Bolivia</asp:ListItem>
            <asp:ListItem Value="27">Bosnia and Herzegovina</asp:ListItem>
            <asp:ListItem Value="28">Botswana</asp:ListItem>
            <asp:ListItem Value="29">Bouvet Island</asp:ListItem>
            <asp:ListItem Value="30">Brazil</asp:ListItem>
            <asp:ListItem Value="31">British Indian Ocean Territory</asp:ListItem>
            <asp:ListItem Value="32">Brunei Darussalam</asp:ListItem>
            <asp:ListItem Value="33">Bulgaria</asp:ListItem>
            <asp:ListItem Value="34">Burkina Faso</asp:ListItem>
            <asp:ListItem Value="35">Burundi</asp:ListItem>
            <asp:ListItem Value="36">Cambodia</asp:ListItem>
            <asp:ListItem Value="37">Cameroon</asp:ListItem>
            <asp:ListItem Value="39">Cape Verde</asp:ListItem>
            <asp:ListItem Value="40">Cayman Islands</asp:ListItem>
            <asp:ListItem Value="41">Central African Republic</asp:ListItem>
            <asp:ListItem Value="42">Chad</asp:ListItem>
            <asp:ListItem Value="43">Chile</asp:ListItem>
            <asp:ListItem Value="44">China</asp:ListItem>
            <asp:ListItem Value="45">Christmas Island</asp:ListItem>
            <asp:ListItem Value="46">Cocos (Keeling) Islands</asp:ListItem>
            <asp:ListItem Value="47">Colombia</asp:ListItem>
            <asp:ListItem Value="48">Comoros</asp:ListItem>
            <asp:ListItem Value="49">Congo</asp:ListItem>
            <asp:ListItem Value="50">Congo, the Democratic Republic of the</asp:ListItem>
            <asp:ListItem Value="51">Cook Islands</asp:ListItem>
            <asp:ListItem Value="52">Costa Rica</asp:ListItem>
            <asp:ListItem Value="53">Cote d'Ivoire</asp:ListItem>
            <asp:ListItem Value="54">Croatia</asp:ListItem>
            <asp:ListItem Value="55">Cyprus</asp:ListItem>
            <asp:ListItem Value="56">Czech Republic</asp:ListItem>
            <asp:ListItem Value="57">Denmark</asp:ListItem>
            <asp:ListItem Value="58">Djibouti</asp:ListItem>
            <asp:ListItem Value="59">Dominica</asp:ListItem>
            <asp:ListItem Value="60">Dominican Republic</asp:ListItem>
            <asp:ListItem Value="61">East Timor</asp:ListItem>
            <asp:ListItem Value="62">Ecuador</asp:ListItem>
            <asp:ListItem Value="63">Egypt</asp:ListItem>
            <asp:ListItem Value="64">El Salvador</asp:ListItem>
            <asp:ListItem Value="65">England</asp:ListItem>
            <asp:ListItem Value="66">Equatorial Guinea</asp:ListItem>
            <asp:ListItem Value="67">Eritrea</asp:ListItem>
            <asp:ListItem Value="68">Espana</asp:ListItem>
            <asp:ListItem Value="69">Estonia</asp:ListItem>
            <asp:ListItem Value="70">Ethiopia</asp:ListItem>
            <asp:ListItem Value="71">Falkland Islands</asp:ListItem>
            <asp:ListItem Value="72">Faroe Islands</asp:ListItem>
            <asp:ListItem Value="73">Fiji</asp:ListItem>
            <asp:ListItem Value="74">Finland</asp:ListItem>
            <asp:ListItem Value="75">France</asp:ListItem>
            <asp:ListItem Value="76">French Guiana</asp:ListItem>
            <asp:ListItem Value="77">French Polynesia</asp:ListItem>
            <asp:ListItem Value="78">French Southern Territories</asp:ListItem>
            <asp:ListItem Value="79">Gabon</asp:ListItem>
            <asp:ListItem Value="80">Gambia</asp:ListItem>
            <asp:ListItem Value="81">Georgia</asp:ListItem>
            <asp:ListItem Value="82">Germany</asp:ListItem>
            <asp:ListItem Value="83">Ghana</asp:ListItem>
            <asp:ListItem Value="84">Gibraltar</asp:ListItem>
            <asp:ListItem Value="85">Great Britain</asp:ListItem>
            <asp:ListItem Value="86">Greece</asp:ListItem>
            <asp:ListItem Value="87">Greenland</asp:ListItem>
            <asp:ListItem Value="88">Grenada</asp:ListItem>
            <asp:ListItem Value="89">Guadeloupe</asp:ListItem>
            <asp:ListItem Value="90">Guam</asp:ListItem>
            <asp:ListItem Value="91">Guatemala</asp:ListItem>
            <asp:ListItem Value="92">Guinea</asp:ListItem>
            <asp:ListItem Value="93">Guinea-Bissau</asp:ListItem>
            <asp:ListItem Value="94">Guyana</asp:ListItem>
            <asp:ListItem Value="95">Haiti</asp:ListItem>
            <asp:ListItem Value="96">Heard and Mc Donald Islands</asp:ListItem>
            <asp:ListItem Value="97">Honduras</asp:ListItem>
            <asp:ListItem Value="98">Hong Kong</asp:ListItem>
            <asp:ListItem Value="99">Hungary</asp:ListItem>
            <asp:ListItem Value="100">Iceland</asp:ListItem>
            <asp:ListItem Value="101">India</asp:ListItem>
            <asp:ListItem Value="102">Indonesia</asp:ListItem>
            <asp:ListItem Value="103">Ireland</asp:ListItem>
            <asp:ListItem Value="104">Israel</asp:ListItem>
            <asp:ListItem Value="105">Italy</asp:ListItem>
            <asp:ListItem Value="106">Jamaica</asp:ListItem>
            <asp:ListItem Value="107">Japan</asp:ListItem>
            <asp:ListItem Value="108">Jordan</asp:ListItem>
            <asp:ListItem Value="109">Kazakhstan</asp:ListItem>
            <asp:ListItem Value="110">Kenya</asp:ListItem>
            <asp:ListItem Value="111">Kiribati</asp:ListItem>
            <asp:ListItem Value="112">Korea, Republic of</asp:ListItem>
            <asp:ListItem Value="113">Korea (South)</asp:ListItem>
            <asp:ListItem Value="114">Kuwait</asp:ListItem>
            <asp:ListItem Value="115">Kyrgyzstan</asp:ListItem>
            <asp:ListItem Value="116">Lao People's Democratic Republic</asp:ListItem>
            <asp:ListItem Value="117">Latvia</asp:ListItem>
            <asp:ListItem Value="118">Lebanon</asp:ListItem>
            <asp:ListItem Value="119">Lesotho</asp:ListItem>
            <asp:ListItem Value="120">Liberia</asp:ListItem>
            <asp:ListItem Value="121">Libya</asp:ListItem>
            <asp:ListItem Value="122">Liechtenstein</asp:ListItem>
            <asp:ListItem Value="123">Lithuania</asp:ListItem>
            <asp:ListItem Value="124">Luxembourg</asp:ListItem>
            <asp:ListItem Value="125">Macau</asp:ListItem>
            <asp:ListItem Value="126">Macedonia</asp:ListItem>
            <asp:ListItem Value="127">Madagascar</asp:ListItem>
            <asp:ListItem Value="128">Malawi</asp:ListItem>
            <asp:ListItem Value="129">Malaysia</asp:ListItem>
            <asp:ListItem Value="130">Maldives</asp:ListItem>
            <asp:ListItem Value="131">Mali</asp:ListItem>
            <asp:ListItem Value="132">Malta</asp:ListItem>
            <asp:ListItem Value="133">Marshall Islands</asp:ListItem>
            <asp:ListItem Value="134">Martinique</asp:ListItem>
            <asp:ListItem Value="135">Mauritania</asp:ListItem>
            <asp:ListItem Value="136">Mauritius</asp:ListItem>
            <asp:ListItem Value="137">Mayotte</asp:ListItem>
            <asp:ListItem Value="139">Micronesia, Federated States of</asp:ListItem>
            <asp:ListItem Value="140">Moldova, Republic of</asp:ListItem>
            <asp:ListItem Value="141">Monaco</asp:ListItem>
            <asp:ListItem Value="142">Mongolia</asp:ListItem>
            <asp:ListItem Value="143">Montserrat</asp:ListItem>
            <asp:ListItem Value="144">Morocco</asp:ListItem>
            <asp:ListItem Value="145">Mozambique</asp:ListItem>
            <asp:ListItem Value="146">Myanmar</asp:ListItem>
            <asp:ListItem Value="147">Namibia</asp:ListItem>
            <asp:ListItem Value="148">Nauru</asp:ListItem>
            <asp:ListItem Value="149">Nepal</asp:ListItem>
            <asp:ListItem Value="150">Netherlands</asp:ListItem>
            <asp:ListItem Value="151">Netherlands Antilles</asp:ListItem>
            <asp:ListItem Value="152">New Caledonia</asp:ListItem>
            <asp:ListItem Value="153">New Zealand</asp:ListItem>
            <asp:ListItem Value="154">Nicaragua</asp:ListItem>
            <asp:ListItem Value="155">Niger</asp:ListItem>
            <asp:ListItem Value="156">Nigeria</asp:ListItem>
            <asp:ListItem Value="157">Niue</asp:ListItem>
            <asp:ListItem Value="158">Norfolk Island</asp:ListItem>
            <asp:ListItem Value="159">Northern Ireland</asp:ListItem>
            <asp:ListItem Value="160">Northern Mariana Islands</asp:ListItem>
            <asp:ListItem Value="161">Norway</asp:ListItem>
            <asp:ListItem Value="162">Oman</asp:ListItem>
            <asp:ListItem Value="163">Pakistan</asp:ListItem>
            <asp:ListItem Value="164">Palau</asp:ListItem>
            <asp:ListItem Value="165">Panama</asp:ListItem>
            <asp:ListItem Value="166">Papua New Guinea</asp:ListItem>
            <asp:ListItem Value="167">Paraguay</asp:ListItem>
            <asp:ListItem Value="168">Peru</asp:ListItem>
            <asp:ListItem Value="169">Philippines</asp:ListItem>
            <asp:ListItem Value="170">Pitcairn</asp:ListItem>
            <asp:ListItem Value="171">Poland</asp:ListItem>
            <asp:ListItem Value="172">Portugal</asp:ListItem>
            <asp:ListItem Value="173">Puerto Rico</asp:ListItem>
            <asp:ListItem Value="174">Qatar</asp:ListItem>
            <asp:ListItem Value="175">Reunion</asp:ListItem>
            <asp:ListItem Value="176">Romania</asp:ListItem>
            <asp:ListItem Value="177">Russia</asp:ListItem>
            <asp:ListItem Value="178">Russian Federation</asp:ListItem>
            <asp:ListItem Value="179">Rwanda</asp:ListItem>
            <asp:ListItem Value="180">Saint Kitts and Nevis</asp:ListItem>
            <asp:ListItem Value="181">Saint Lucia</asp:ListItem>
            <asp:ListItem Value="182">Saint Vincent and the Grenadines</asp:ListItem>
            <asp:ListItem Value="183">Samoa (Independent)</asp:ListItem>
            <asp:ListItem Value="184">San Marino</asp:ListItem>
            <asp:ListItem Value="185">Sao Tome and Principe</asp:ListItem>
            <asp:ListItem Value="186">Saudi Arabia</asp:ListItem>
            <asp:ListItem Value="187">Scotland</asp:ListItem>
            <asp:ListItem Value="188">Senegal</asp:ListItem>
            <asp:ListItem Value="189">Serbia and Montenegro</asp:ListItem>
            <asp:ListItem Value="190">Seychelles</asp:ListItem>
            <asp:ListItem Value="191">Sierra Leone</asp:ListItem>
            <asp:ListItem Value="192">Singapore</asp:ListItem>
            <asp:ListItem Value="193">Slovakia</asp:ListItem>
            <asp:ListItem Value="194">Slovenia</asp:ListItem>
            <asp:ListItem Value="195">Solomon Islands</asp:ListItem>
            <asp:ListItem Value="196">Somalia</asp:ListItem>
            <asp:ListItem Value="197">South Africa</asp:ListItem>
            <asp:ListItem Value="199">South Korea</asp:ListItem>
            <asp:ListItem Value="200">Spain</asp:ListItem>
            <asp:ListItem Value="201">Sri Lanka</asp:ListItem>
            <asp:ListItem Value="202">St. Helena</asp:ListItem>
            <asp:ListItem Value="203">St. Pierre and Miquelon</asp:ListItem>
            <asp:ListItem Value="204">Suriname</asp:ListItem>
            <asp:ListItem Value="205">Svalbard and Jan Mayen Islands</asp:ListItem>
            <asp:ListItem Value="206">Swaziland</asp:ListItem>
            <asp:ListItem Value="207">Sweden</asp:ListItem>
            <asp:ListItem Value="208">Switzerland</asp:ListItem>
            <asp:ListItem Value="209">Taiwan</asp:ListItem>
            <asp:ListItem Value="210">Tajikistan</asp:ListItem>
            <asp:ListItem Value="211">Tanzania</asp:ListItem>
            <asp:ListItem Value="212">Thailand</asp:ListItem>
            <asp:ListItem Value="213">Togo</asp:ListItem>
            <asp:ListItem Value="214">Tokelau</asp:ListItem>
            <asp:ListItem Value="215">Tonga</asp:ListItem>
            <asp:ListItem Value="216">Trinidad</asp:ListItem>
            <asp:ListItem Value="217">Trinidad and Tobago</asp:ListItem>
            <asp:ListItem Value="218">Tunisia</asp:ListItem>
            <asp:ListItem Value="219">Turkey</asp:ListItem>
            <asp:ListItem Value="220">Turkmenistan</asp:ListItem>
            <asp:ListItem Value="221">Turks and Caicos Islands</asp:ListItem>
            <asp:ListItem Value="222">Tuvalu</asp:ListItem>
            <asp:ListItem Value="223">Uganda</asp:ListItem>
            <asp:ListItem Value="224">Ukraine</asp:ListItem>
            <asp:ListItem Value="225">United Arab Emirates</asp:ListItem>
            <asp:ListItem Value="226">United Kingdom</asp:ListItem>
            <asp:ListItem Value="228">United States Minor Outlying Islands</asp:ListItem>
            <asp:ListItem Value="229">Uruguay</asp:ListItem>
            <asp:ListItem Value="231">Uzbekistan</asp:ListItem>
            <asp:ListItem Value="232">Vanuatu</asp:ListItem>
            <asp:ListItem Value="233">Vatican City State (Holy See)</asp:ListItem>
            <asp:ListItem Value="234">Venezuela</asp:ListItem>
            <asp:ListItem Value="235">Viet Nam</asp:ListItem>
            <asp:ListItem Value="236">Virgin Islands (British)</asp:ListItem>
            <asp:ListItem Value="237">Virgin Islands (U.S.)</asp:ListItem>
            <asp:ListItem Value="238">Wales</asp:ListItem>
            <asp:ListItem Value="239">Wallis and Futuna Islands</asp:ListItem>
            <asp:ListItem Value="240">Western Sahara</asp:ListItem>
            <asp:ListItem Value="241">Yemen</asp:ListItem>
            <asp:ListItem Value="242">Zambia</asp:ListItem>
            <asp:ListItem Value="243">Zimbabwe</asp:ListItem>
        </asp:DropDownList>
							</td>
						</tr>
						<tr class="detailsViewRow">
							<td class="detailsViewFieldHeader">
								Business
							</td>
							<td>
								 <asp:TextBox ID="txtBusiness" class="txt large-input" runat="server" Text="">
    </asp:TextBox></td>
						</tr>
						<tr class="detailsViewRow">
							<td class="detailsViewFieldHeader">
								Email
							</td>
							<td>
								 <asp:TextBox ID="txtEmail" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
							</td>
						</tr>
					</tbody></table>

				</td>
		</tr>
	</tbody></table>
		</div>
	</div>

	
	

</div>
<div class="rightSidePanel">

	

<div class="formPanel">
	<div class="formPanelHeader">
		<span id="contentAreaPlaceHolder_toursDetails_panelTitle">Tour</span>
	</div>
	<input type="hidden" id="contentAreaPlaceHolder_toursDetails_hiddenTourID" name="ctl00$contentAreaPlaceHolder$toursDetails$hiddenTourID">
	
	
	
	
	
	
	<table cellspacing="0" style="width:100%;border-collapse:collapse;" id="contentAreaPlaceHolder_toursDetails_formView" class="formView">
		<tbody><tr>
			<td colspan="2">

			<div id="contentAreaPlaceHolder_toursDetails_formView_panelContent">
				<div class="formPanelContent">
					<table class="detailsView">
						<tbody><tr><td>
<asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
&nbsp;</td>
					</tr></tbody></table>
					<table class="detailsView">
						<tbody><tr class="detailsViewRow">
							<td class="detailsViewFieldHeader">
								Tour Status
							</td>
							<td>
							    <asp:DropDownList ID="ddlTourStatusID" runat="server">
     </asp:DropDownList>&nbsp;*
									<span style="display:none;" class="error" id="contentAreaPlaceHolder_toursDetails_formView_ctl01">Required</span>
							</td>
						</tr>
						
						<tr class="detailsViewRow">
							<td class="detailsViewFieldHeader">
								Sales Center
							</td>
							<td>
								<asp:DropDownList ID="ddlSalesCenterID" runat="server">
     </asp:DropDownList>&nbsp;*
									 
							</td>
						</tr>
						<tr class="detailsViewRow">
							<td class="detailsViewFieldHeader">
								Tour Date
							</td>
							<td>
								     <asp:TextBox ID="txtTourDate" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
								
								
								
							</td>
						</tr>
						<tr class="detailsViewRow">
							<td class="detailsViewFieldHeader">
								Tour Time
							</td>
							<td>
								   <asp:TextBox ID="txtTourTime" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
									</td>
						</tr>
					</tbody></table>
				</div>
				
				<div class="formPanelSubHeaderDivider">
					<div class="formPanelSubHeader">
						Marketing Information
					</div>
				</div>
				<div class="formPanelContent">
					<table class="detailsView">
						<tbody><tr class="detailsViewRow" id="contentAreaPlaceHolder_toursDetails_formView_trMarketingUser1">
				<td class="detailsViewFieldHeader">
								Marketing Agent
							</td>
				<td>							
								<div class="requiredUsersPick">
									<div style="width:310px;" emptyitemtext="None" class="RadComboBox RadComboBox_Default" id="ctl00_contentAreaPlaceHolder_toursDetails_formView_dropDownMarketingAgent">
					<table style="border-width: 0pt; border-collapse: collapse;" summary="combobox">
						<tbody><tr>
							<td class="rcbInputCell rcbInputCellLeft" style="width:100%;">
                              <asp:DropDownList ID="ddlMarketingAgentID" runat="server">
     </asp:DropDownList>
                            </td>
							<td class="rcbArrowCell rcbArrowCellRight">
                            </td>
						</tr>
					</tbody></table>
					<!-- 2010.3.1317.40 --><div style="z-index:6000;" class="rcbSlide"><div style="display:none;" class="RadComboBoxDropDown RadComboBoxDropDown_Default " id="ctl00_contentAreaPlaceHolder_toursDetails_formView_dropDownMarketingAgent_DropDown"><div style="height:250px;width:100%;" class="rcbScroll rcbWidth"><ul style="list-style:none;margin:0;padding:0;zoom:1;" class="rcbList"><li class="rcbItem ">RPI Rudi Gustin</li></ul></div></div></div><input type="hidden" name="ctl00_contentAreaPlaceHolder_toursDetails_formView_dropDownMarketingAgent_ClientState" id="ctl00_contentAreaPlaceHolder_toursDetails_formView_dropDownMarketingAgent_ClientState" autocomplete="off" value="{&quot;logEntries&quot;:[],&quot;value&quot;:&quot;47&quot;,&quot;text&quot;:&quot;RPI Rudi Gustin&quot;,&quot;enabled&quot;:true}">
				</div>&nbsp;*<br>
										<span style="display:none;" class="error" id="contentAreaPlaceHolder_toursDetails_formView_ctl09">Required</span>
								</div>
							</td>
			</tr>
			
						<tr class="detailsViewRow" id="contentAreaPlaceHolder_toursDetails_formView_trMarketingUser2">
				<td class="detailsViewFieldHeader">
								Marketing Closer
							</td>
				<td>
								<div style="width:310px;" emptyitemtext="None" class="RadComboBox RadComboBox_Default" id="ctl00_contentAreaPlaceHolder_toursDetails_formView_dropDownMarketingCloser">
					<table style="border-width: 0pt; border-collapse: collapse;" summary="combobox">
						<tbody><tr>
							<td class="rcbInputCell rcbInputCellLeft" style="width:100%;">
                             <asp:DropDownList ID="ddlMarketingCloserID" runat="server">
     </asp:DropDownList>
                            </td>
							<td class="rcbArrowCell rcbArrowCellRight"> </td>
						</tr>
					</tbody></table>
					<div style="z-index:6000;" class="rcbSlide"><div style="display:none;" class="RadComboBoxDropDown RadComboBoxDropDown_Default " id="ctl00_contentAreaPlaceHolder_toursDetails_formView_dropDownMarketingCloser_DropDown"><div style="height:250px;width:100%;" class="rcbScroll rcbWidth"></div></div></div><input type="hidden" name="ctl00_contentAreaPlaceHolder_toursDetails_formView_dropDownMarketingCloser_ClientState" id="ctl00_contentAreaPlaceHolder_toursDetails_formView_dropDownMarketingCloser_ClientState" autocomplete="off" value="{&quot;logEntries&quot;:[],&quot;value&quot;:&quot;&quot;,&quot;text&quot;:&quot;&quot;,&quot;enabled&quot;:true}">
				</div>
							</td>
			</tr>
			
						
						
						<tr class="detailsViewRow">
							<td class="detailsViewFieldHeader">
								Marketing Venue
							</td>
							<td>
								<div style="width:310px;" emptyitemtext="None" class="RadComboBox RadComboBox_Default" id="ctl00_contentAreaPlaceHolder_toursDetails_formView_dropDownVenue">
				<table style="border-width: 0pt; border-collapse: collapse;" summary="combobox" class="rcbDisabled">
					<tbody><tr>
						<td class="rcbInputCell rcbInputCellLeft" style="width:100%;">
                           <asp:DropDownList ID="ddlMarketingVanueID" runat="server">
     </asp:DropDownList>
                        </td>
						<td class="rcbArrowCell rcbArrowCellRight"> </td>
					</tr>
				</tbody></table>
				<div style="z-index:6000;" class="rcbSlide"><div style="display:none;" class="RadComboBoxDropDown RadComboBoxDropDown_Default " id="ctl00_contentAreaPlaceHolder_toursDetails_formView_dropDownVenue_DropDown"><div style="height:250px;width:100%;" class="rcbScroll rcbWidth"></div></div></div><input type="hidden" name="ctl00_contentAreaPlaceHolder_toursDetails_formView_dropDownVenue_ClientState" id="ctl00_contentAreaPlaceHolder_toursDetails_formView_dropDownVenue_ClientState" value="{&quot;logEntries&quot;:[],&quot;value&quot;:&quot;&quot;,&quot;text&quot;:&quot;&quot;,&quot;enabled&quot;:false}" autocomplete="off">
			</div>
							</td>
						</tr>
						<tr class="detailsViewRow" id="contentAreaPlaceHolder_toursDetails_formView_trCampaign">
				<td class="detailsViewFieldHeader">
								Lead Source
							</td>
				<td>
								<div style="width:310px;" emptyitemtext="None" class="RadComboBox RadComboBox_Default" id="ctl00_contentAreaPlaceHolder_toursDetails_formView_dropDownCampaigns">
					<table style="border-width: 0pt; border-collapse: collapse;" summary="combobox">
						<tbody><tr>
							<td class="rcbInputCell rcbInputCellLeft" style="width:100%;">
                                 <asp:Label ID="lblLeadSourceID" runat="server" Text="Lead Source: ">
    </asp:Label>
                            </td>
							<td class="rcbArrowCell rcbArrowCellRight"> </td>
						</tr>
					</tbody></table>
					<div style="z-index:6000;" class="rcbSlide"><div style="display:none;" class="RadComboBoxDropDown RadComboBoxDropDown_Default " id="ctl00_contentAreaPlaceHolder_toursDetails_formView_dropDownCampaigns_DropDown"><div style="height:250px;width:100%;" class="rcbScroll rcbWidth"></div></div>
                           <asp:DropDownList ID="ddlLeadSourceID" runat="server">
     </asp:DropDownList>
                                    </div><input type="hidden" name="ctl00_contentAreaPlaceHolder_toursDetails_formView_dropDownCampaigns_ClientState" id="ctl00_contentAreaPlaceHolder_toursDetails_formView_dropDownCampaigns_ClientState" autocomplete="off" value="{&quot;logEntries&quot;:[],&quot;value&quot;:&quot;&quot;,&quot;text&quot;:&quot;&quot;,&quot;enabled&quot;:true}">
				</div>
							</td>
			</tr>
			
						
						
						<tr class="detailsViewRow">
							<td class="detailsViewFieldHeader">
								Gifts
							</td>
							<td>
								<div id="contentAreaPlaceHolder_toursDetails_formView_giftsMapping_UpdatePanel2">
				

	<div style="margin-bottom:5px;" id="contentAreaPlaceHolder_toursDetails_formView_giftsMapping_panelDropDownGifts">
					
		<div style="width:280px;" emptyitemtext="None" class="RadComboBox RadComboBox_Default" id="ctl00_contentAreaPlaceHolder_toursDetails_formView_giftsMapping_dropDownGifts">
						<table style="border-width: 0pt; border-collapse: collapse;" summary="combobox" class="rcbDisabled">
							<tbody><tr>
								<td class="rcbInputCell rcbInputCellLeft" style="width:100%;">
                                    <asp:DropDownList ID="ddlGiftID" runat="server">
     </asp:DropDownList>
                                </td>
								<td class="rcbArrowCell rcbArrowCellRight"> </td>
							</tr>
						</tbody></table>
						<div style="z-index:6000;" class="rcbSlide"><div style="display:none;" class="RadComboBoxDropDown RadComboBoxDropDown_Default " id="ctl00_contentAreaPlaceHolder_toursDetails_formView_giftsMapping_dropDownGifts_DropDown"><div style="height:250px;width:100%;" class="rcbScroll rcbWidth"></div></div></div><input type="hidden" name="ctl00_contentAreaPlaceHolder_toursDetails_formView_giftsMapping_dropDownGifts_ClientState" id="ctl00_contentAreaPlaceHolder_toursDetails_formView_giftsMapping_dropDownGifts_ClientState" value="{&quot;logEntries&quot;:[],&quot;value&quot;:&quot;&quot;,&quot;text&quot;:&quot;&quot;,&quot;enabled&quot;:false}" autocomplete="off">
					</div>
		
		
	
				</div>

	<div>

				</div>

	


			</div>
							</td>
						</tr>
						<tr class="detailsViewRow">
							<td class="detailsViewFieldHeader">
								Deposit Amount
							</td>
							<td>
								<div style="width:310px;" class="columnContainer">
									<div class="columnLeft">
										
                                         <asp:TextBox ID="txtDepositAmount" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                                        </div>
									<div class="columnRight">
										Refundable:
            <asp:DropDownList ID="ddlDepositRefundable" runat="server">
                <asp:ListItem Value="True">Yes</asp:ListItem>
                <asp:ListItem Value="False">No</asp:ListItem>
            </asp:DropDownList>
										 
									</div>
									<div class="break">
									</div>
								</div>
							</td>
						</tr>
						<tr class="detailsViewRow header">
							<td colspan="2" class="detailsViewFieldHeader">
								Marketing Notes
							</td>
						</tr>
						<tr class="detailsViewRow item">
							<td colspan="2" class="detailsViewFieldItem">
								
		
	

<div id="contentAreaPlaceHolder_toursDetails_formView_marketingNotes_addNotePanel">
				
	
       <asp:TextBox ID="txtNotes" TextMode="MultiLine"  style="width:350px;" runat="server" Text="">
    </asp:TextBox>
			</div>
							</td>
						</tr>
					</tbody></table>
				</div>
				
				<table class="detailsView">
					<tbody><tr class="detailsViewCommandRow">
						<td colspan="2">
<asp:Button ID="btnAdd0" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
&nbsp;</td>
					</tr>
				</tbody></table>
			</div>

		</td>
		</tr>
	</tbody></table>
</div>
	

</div>
<div class="break"></div>
</div>
</asp:Content>

