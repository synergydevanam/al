using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;

public partial class AdminResidentInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadInitialValue();
            loadProperty();
            fileUpload.Visible = false;
            if (Request.QueryString["residentID"] != null)
            {
                fileUpload.Visible = true;
                int residentID = Int32.Parse(Request.QueryString["residentID"]);
                if (residentID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                    btnUpdate1.Visible = false;
                    btnAdd1.Visible = true;
                    btnUpdate2.Visible = false;
                    btnAdd2.Visible = true;
                }
                else
                {
                    showDocumentClinet(residentID);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    btnAdd1.Visible = false;
                    btnUpdate1.Visible = true;
                    btnAdd2.Visible = false;
                    btnUpdate2.Visible = true;
                    showResidentData();
                }
            }
        }
    }

    private Login getLogin()
    {
        Login login = new Login();
        try
        {
            if (Session["Login"] == null) { Session["PreviousPage"] = HttpContext.Current.Request.Url.AbsoluteUri; Response.Redirect("../LoginPage.aspx"); }

            login = (Login)Session["Login"];
        }
        catch (Exception ex)
        { }

        return login;
    }

    private void loadProperty()
    {
        //ListItem li = new ListItem("Select Property...", "0");
        //ddlPropertyID.Items.Add(li);

        List<Property> properties = new List<Property>();
        properties = PropertyManager.GetAllPropertiesSearch("Where AL_Property.ExtraField7 <> 'InActive' and AL_Property.PropertyID in (0" + (getLogin().ExtraField3 == "" ? "" : "," + getLogin().ExtraField3) + ")");
        foreach (Property property in properties)
        {
            ListItem item = new ListItem(property.Address.ToString(), property.PropertyID.ToString());
            ddlPropertyID.Items.Add(item);
        }
    }

    private void loadInitialValue()
    {
        //txtAdmissionDate.Text = DateTime.Today.ToString("dd MMM yyyy");
        //txtDateOfBirth.Text = DateTime.Today.ToString("dd MMM yyyy");
        //txtDateofLastPhysicalExam.Text = DateTime.Today.ToString("dd MMM yyyy");
        //txtDischargedOrExpiredDate.Text = DateTime.Today.ToString("dd MMM yyyy");
    }

    private DateTime ChangeTheDate(string datetime)
    {
        if (datetime == "")
        {
            return DateTime.Parse("1 Jan 1753");
        }
        else
        {
            if (datetime.Contains('/'))
            {
                return DateTime.Parse(datetime.Split('/')[2]+"-"+datetime.Split('/')[0]+"-"+datetime.Split('/')[1]);
            }
            else
                return DateTime.Parse("1 Jan 1753");
        }
    }

    private string CheckNullDate(DateTime datetime)
    {
        if (datetime == DateTime.Parse("1 Jan 1753"))
            return "";
        else
        {
          return  datetime.ToString("MM/dd/yyyy");
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Resident resident = new Resident();

        resident.Name = txtName.Text;
        resident.AdmissionDate = ChangeTheDate(txtAdmissionDate.Text);
        resident.AdmissionFrom = txtAdmissionFrom.Text;
        resident.UsualOccupation = txtUsualOccupation.Text;
        resident.PlaceOfBirth = txtPlaceOfBirth.Text;
        resident.UsualAddress = txtUsualAddress.Text;
        resident.Telephone = txtTelephone.Text;
        resident.Race = txtRace.Text;
        resident.Age = Int32.Parse(txtAge.Text==""?"0":txtAge.Text);
        resident.DateOfBirth = ChangeTheDate(txtDateOfBirth.Text);
        resident.Sex = txtSex.Text;
        resident.MaritalStatus = txtMaritalStatus.Text;
        resident.Height = txtHeight.Text;
        resident.Weight = txtWeight.Text;
        resident.Religion = txtReligion.Text;
        resident.Clergyman = txtClergyman.Text;
        resident.ChurchSynagogue = txtChurchSynagogue.Text;
        resident.ChurchSynagogueTelephone = txtChurchSynagogueTelephone.Text;
        resident.Address = txtAddress.Text;
        resident.AddressTelephone = txtAddressTelephone.Text;
        resident.SocialSecurity = txtSocialSecurity.Text;
        resident.Medicare = txtMedicare.Text;
        resident.Medicaid = txtMedicaid.Text;
        resident.Insurance = txtInsurance.Text;
        resident.InsuranceAddress = txtInsuranceAddress.Text;
        resident.InsuranceAddressTelephone = txtInsuranceAddressTelephone.Text;
        resident.Policy = txtPolicy.Text;
        resident.InsuranceGroup = txtInsuranceGroup.Text;
        resident.InsuranceGroupNo = txtInsuranceGroupNo.Text;
        resident.ResponsibleParty = txtResponsibleParty.Text;
        resident.ResponsiblePartyRelationship = txtResponsiblePartyRelationship.Text;
        resident.ResponsiblePartyAddress = txtResponsiblePartyAddress.Text;
        resident.ResponsiblePartyTelephone = txtResponsiblePartyTelephone.Text;
        resident.PowerOfAttorney = txtPowerOfAttorney.Text;
        resident.PowerOfAttorneyAddress = txtPowerOfAttorneyAddress.Text;
        resident.PowerOfAttorneyRelationship = txtPowerOfAttorneyRelationship.Text;
        resident.PowerOfAttorneyTelephone = txtPowerOfAttorneyTelephone.Text;
        resident.NearestRelativeOrGuardian = txtNearestRelativeOrGuardian.Text;
        resident.NearestRelativeOrGuardianRelationship = txtNearestRelativeOrGuardianRelationship.Text;
        resident.NearestRelativeOrGuardianAddress = txtNearestRelativeOrGuardianAddress.Text;
        resident.NearestRelativeOrGuardianTelephone = txtNearestRelativeOrGuardianTelephone.Text;
        resident.NotifyInCaseOfEmergency = txtNotifyInCaseOfEmergency.Text;
        resident.NotifyInCaseOfEmergencyRelationship = txtNotifyInCaseOfEmergencyRelationship.Text;
        resident.NotifyInCaseOfEmergencyAddress = txtNotifyInCaseOfEmergencyAddress.Text;
        resident.NotifyInCaseOfEmergencyTelephone = txtNotifyInCaseOfEmergencyTelephone.Text;
        resident.HospitalPreference = txtHospitalPreference.Text;
        resident.HospitalPreferenceTelephone = txtHospitalPreferenceTelephone.Text;
        resident.HospitalPreferenceEmail = txtHospitalPreferenceEmail.Text;
        resident.FuneralHomePreference = txtFuneralHomePreference.Text;
        resident.FuneralHomePreferenceTelephone = txtFuneralHomePreferenceTelephone.Text;
        resident.PharmacyPreference = txtPharmacyPreference.Text;
        resident.PharmacyPreferenceTelephone = txtPharmacyPreferenceTelephone.Text;
        resident.Dentist = txtDentist.Text;
        resident.DentistTelephone = txtDentistTelephone.Text;
        resident.AttendingPhysician = txtAttendingPhysician.Text;
        resident.AttendingPhysicianAddress = txtAttendingPhysicianAddress.Text;
        resident.AttendingPhysicianTelephone = txtAttendingPhysicianTelephone.Text;
        resident.AlternatePhysician = txtAlternatePhysician.Text;
        resident.AlternatePhysicianAddress = txtAlternatePhysicianAddress.Text;
        resident.AlternatePhysicianTelephone = txtAlternatePhysicianTelephone.Text;
        resident.DateofLastPhysicalExam = ChangeTheDate(txtDateofLastPhysicalExam.Text);
        resident.YearlyPhysicalDue = txtYearlyPhysicalDue.Text;
        resident.Diagnosis = txtDiagnosis.Text;
        resident.Allergies = txtAllergies.Text;
        resident.DischargedOrExpiredDate = ChangeTheDate(txtDischargedOrExpiredDate.Text);
        resident.DischargedOrExpiredReason = txtDischargedOrExpiredReason.Text;
        resident.IsWithoutMDApproval = cbIsWithoutMDApproval.Checked;
        resident.ReleasedTo = txtReleasedTo.Text;
        resident.NewAddress = txtNewAddress.Text;
        resident.PlaceOfDeathAddressnCitynCountynState = txtPlaceOfDeathAddressnCitynCountynState.Text;
        resident.PrecinctNo = txtPrecinctNo.Text;
        resident.MorticianName = txtMorticianName.Text;
        resident.Signature = txtSignature.Text;
        resident.ExtraField1 = ddlPropertyID.SelectedValue;
        resident.ExtraField2 = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"); ;
        resident.ExtraField3 = getLogin().FirstName +" "+getLogin().MiddleName +" "+getLogin().LastName ;
        resident.ExtraField4 = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"); ;
        resident.ExtraField5 = getLogin().FirstName + " " + getLogin().MiddleName + " " + getLogin().LastName; ;
        resident.ExtraField6 = "";
        resident.ExtraField7 = "";
        resident.ExtraField8 = txtExtraField8.Text;
        resident.ExtraField9 = "";
        resident.ExtraField10 = ddlStatus.SelectedValue;
        int resutl = ResidentManager.InsertResident(resident);
        Response.Redirect("AdminResidentInsertUpdate.aspx?residentID="+resutl.ToString());
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Resident resident = new Resident();
        resident = ResidentManager.GetResidentByID(Int32.Parse(Request.QueryString["residentID"]));
        Resident tempResident = new Resident();
        tempResident.ResidentID = resident.ResidentID;

        tempResident.Name = txtName.Text;
        tempResident.AdmissionDate = ChangeTheDate(txtAdmissionDate.Text);
        tempResident.AdmissionFrom = txtAdmissionFrom.Text;
        tempResident.UsualOccupation = txtUsualOccupation.Text;
        tempResident.PlaceOfBirth = txtPlaceOfBirth.Text;
        tempResident.UsualAddress = txtUsualAddress.Text;
        tempResident.Telephone = txtTelephone.Text;
        tempResident.Race = txtRace.Text;
        tempResident.Age = Int32.Parse(txtAge.Text);
        tempResident.DateOfBirth = ChangeTheDate(txtDateOfBirth.Text);
        tempResident.Sex = txtSex.Text;
        tempResident.MaritalStatus = txtMaritalStatus.Text;
        tempResident.Height = txtHeight.Text;
        tempResident.Weight = txtWeight.Text;
        tempResident.Religion = txtReligion.Text;
        tempResident.Clergyman = txtClergyman.Text;
        tempResident.ChurchSynagogue = txtChurchSynagogue.Text;
        tempResident.ChurchSynagogueTelephone = txtChurchSynagogueTelephone.Text;
        tempResident.Address = txtAddress.Text;
        tempResident.AddressTelephone = txtAddressTelephone.Text;
        tempResident.SocialSecurity = txtSocialSecurity.Text;
        tempResident.Medicare = txtMedicare.Text;
        tempResident.Medicaid = txtMedicaid.Text;
        tempResident.Insurance = txtInsurance.Text;
        tempResident.InsuranceAddress = txtInsuranceAddress.Text;
        tempResident.InsuranceAddressTelephone = txtInsuranceAddressTelephone.Text;
        tempResident.Policy = txtPolicy.Text;
        tempResident.InsuranceGroup = txtInsuranceGroup.Text;
        tempResident.InsuranceGroupNo = txtInsuranceGroupNo.Text;
        tempResident.ResponsibleParty = txtResponsibleParty.Text;
        tempResident.ResponsiblePartyRelationship = txtResponsiblePartyRelationship.Text;
        tempResident.ResponsiblePartyAddress = txtResponsiblePartyAddress.Text;
        tempResident.ResponsiblePartyTelephone = txtResponsiblePartyTelephone.Text;
        tempResident.PowerOfAttorney = txtPowerOfAttorney.Text;
        tempResident.PowerOfAttorneyAddress = txtPowerOfAttorneyAddress.Text;
        tempResident.PowerOfAttorneyRelationship = txtPowerOfAttorneyRelationship.Text;
        tempResident.PowerOfAttorneyTelephone = txtPowerOfAttorneyTelephone.Text;
        tempResident.NearestRelativeOrGuardian = txtNearestRelativeOrGuardian.Text;
        tempResident.NearestRelativeOrGuardianRelationship = txtNearestRelativeOrGuardianRelationship.Text;
        tempResident.NearestRelativeOrGuardianAddress = txtNearestRelativeOrGuardianAddress.Text;
        tempResident.NearestRelativeOrGuardianTelephone = txtNearestRelativeOrGuardianTelephone.Text;
        tempResident.NotifyInCaseOfEmergency = txtNotifyInCaseOfEmergency.Text;
        tempResident.NotifyInCaseOfEmergencyRelationship = txtNotifyInCaseOfEmergencyRelationship.Text;
        tempResident.NotifyInCaseOfEmergencyAddress = txtNotifyInCaseOfEmergencyAddress.Text;
        tempResident.NotifyInCaseOfEmergencyTelephone = txtNotifyInCaseOfEmergencyTelephone.Text;
        tempResident.HospitalPreference = txtHospitalPreference.Text;
        tempResident.HospitalPreferenceTelephone = txtHospitalPreferenceTelephone.Text;
        tempResident.HospitalPreferenceEmail = txtHospitalPreferenceEmail.Text;
        tempResident.FuneralHomePreference = txtFuneralHomePreference.Text;
        tempResident.FuneralHomePreferenceTelephone = txtFuneralHomePreferenceTelephone.Text;
        tempResident.PharmacyPreference = txtPharmacyPreference.Text;
        tempResident.PharmacyPreferenceTelephone = txtPharmacyPreferenceTelephone.Text;
        tempResident.Dentist = txtDentist.Text;
        tempResident.DentistTelephone = txtDentistTelephone.Text;
        tempResident.AttendingPhysician = txtAttendingPhysician.Text;
        tempResident.AttendingPhysicianAddress = txtAttendingPhysicianAddress.Text;
        tempResident.AttendingPhysicianTelephone = txtAttendingPhysicianTelephone.Text;
        tempResident.AlternatePhysician = txtAlternatePhysician.Text;
        tempResident.AlternatePhysicianAddress = txtAlternatePhysicianAddress.Text;
        tempResident.AlternatePhysicianTelephone = txtAlternatePhysicianTelephone.Text;
        tempResident.DateofLastPhysicalExam = ChangeTheDate(txtDateofLastPhysicalExam.Text);
        tempResident.YearlyPhysicalDue = txtYearlyPhysicalDue.Text;
        tempResident.Diagnosis = txtDiagnosis.Text;
        tempResident.Allergies = txtAllergies.Text;
        tempResident.DischargedOrExpiredDate = ChangeTheDate(txtDischargedOrExpiredDate.Text);
        tempResident.DischargedOrExpiredReason = txtDischargedOrExpiredReason.Text;
        tempResident.IsWithoutMDApproval = cbIsWithoutMDApproval.Checked;
        tempResident.ReleasedTo = txtReleasedTo.Text;
        tempResident.NewAddress = txtNewAddress.Text;
        tempResident.PlaceOfDeathAddressnCitynCountynState = txtPlaceOfDeathAddressnCitynCountynState.Text;
        tempResident.PrecinctNo = txtPrecinctNo.Text;
        tempResident.MorticianName = txtMorticianName.Text;
        tempResident.Signature = txtSignature.Text;
        tempResident.ExtraField1 = ddlPropertyID.SelectedValue;
        tempResident.ExtraField2 = resident.ExtraField2;
        tempResident.ExtraField3 = resident.ExtraField3;
        tempResident.ExtraField4 = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
        tempResident.ExtraField5 = getLogin().FirstName + " " + getLogin().MiddleName + " " + getLogin().LastName;
        tempResident.ExtraField6 = "";
        tempResident.ExtraField7 = "";
        tempResident.ExtraField8 = txtExtraField8.Text;
        tempResident.ExtraField9 = "";
        tempResident.ExtraField10 = ddlStatus.SelectedValue;
        bool result = ResidentManager.UpdateResident(tempResident);
        lblMsg1.Visible = true;
        lblMsg2.Visible = true;
        lblMsg3.Visible = true;
        //Response.Redirect("AdminResidentDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtName.Text = "";
        txtAdmissionDate.Text = "";
        txtAdmissionFrom.Text = "";
        txtUsualOccupation.Text = "";
        txtPlaceOfBirth.Text = "";
        txtUsualAddress.Text = "";
        txtTelephone.Text = "";
        txtRace.Text = "";
        txtAge.Text = "";
        txtDateOfBirth.Text = "";
        txtSex.Text = "";
        txtMaritalStatus.Text = "";
        txtHeight.Text = "";
        txtWeight.Text = "";
        txtReligion.Text = "";
        txtClergyman.Text = "";
        txtChurchSynagogue.Text = "";
        txtChurchSynagogueTelephone.Text = "";
        txtAddress.Text = "";
        txtAddressTelephone.Text = "";
        txtSocialSecurity.Text = "";
        txtMedicare.Text = "";
        txtMedicaid.Text = "";
        txtInsurance.Text = "";
        txtInsuranceAddress.Text = "";
        txtInsuranceAddressTelephone.Text = "";
        txtPolicy.Text = "";
        txtInsuranceGroup.Text = "";
        txtInsuranceGroupNo.Text = "";
        txtResponsibleParty.Text = "";
        txtResponsiblePartyRelationship.Text = "";
        txtResponsiblePartyAddress.Text = "";
        txtResponsiblePartyTelephone.Text = "";
        txtPowerOfAttorney.Text = "";
        txtPowerOfAttorneyAddress.Text = "";
        txtPowerOfAttorneyRelationship.Text = "";
        txtPowerOfAttorneyTelephone.Text = "";
        txtNearestRelativeOrGuardian.Text = "";
        txtNearestRelativeOrGuardianRelationship.Text = "";
        txtNearestRelativeOrGuardianAddress.Text = "";
        txtNearestRelativeOrGuardianTelephone.Text = "";
        txtNotifyInCaseOfEmergency.Text = "";
        txtNotifyInCaseOfEmergencyRelationship.Text = "";
        txtNotifyInCaseOfEmergencyAddress.Text = "";
        txtNotifyInCaseOfEmergencyTelephone.Text = "";
        txtHospitalPreference.Text = "";
        txtHospitalPreferenceTelephone.Text = "";
        txtHospitalPreferenceEmail.Text = "";
        txtFuneralHomePreference.Text = "";
        txtFuneralHomePreferenceTelephone.Text = "";
        txtPharmacyPreference.Text = "";
        txtPharmacyPreferenceTelephone.Text = "";
        txtDentist.Text = "";
        txtDentistTelephone.Text = "";
        txtAttendingPhysician.Text = "";
        txtAttendingPhysicianAddress.Text = "";
        txtAttendingPhysicianTelephone.Text = "";
        txtAlternatePhysician.Text = "";
        txtAlternatePhysicianAddress.Text = "";
        txtAlternatePhysicianTelephone.Text = "";
        txtDateofLastPhysicalExam.Text = "";
        txtYearlyPhysicalDue.Text = "";
        txtDiagnosis.Text = "";
        txtAllergies.Text = "";
        txtDischargedOrExpiredDate.Text = "";
        txtDischargedOrExpiredReason.Text = "";
        cbIsWithoutMDApproval.Checked = false;
        txtReleasedTo.Text = "";
        txtNewAddress.Text = "";
        txtPlaceOfDeathAddressnCitynCountynState.Text = "";
        txtPrecinctNo.Text = "";
        txtMorticianName.Text = "";
        txtSignature.Text = "";
        txtExtraField8.Text = "";
    }
    private void showResidentData()
    {
        Resident resident = new Resident();
        resident = ResidentManager.GetResidentByID(Int32.Parse(Request.QueryString["residentID"]));

        txtName.Text = resident.Name;
        txtAdmissionDate.Text = CheckNullDate(resident.AdmissionDate);//.ToString("dd MMM yyyy");
        txtAdmissionFrom.Text = resident.AdmissionFrom;
        txtUsualOccupation.Text = resident.UsualOccupation;
        txtPlaceOfBirth.Text = resident.PlaceOfBirth;
        txtUsualAddress.Text = resident.UsualAddress;
        txtTelephone.Text = resident.Telephone;
        txtRace.Text = resident.Race;
        txtAge.Text = resident.Age.ToString();
        txtDateOfBirth.Text = CheckNullDate(resident.DateOfBirth);//.ToString("dd MMM yyyy");
        txtSex.Text = resident.Sex;
        txtMaritalStatus.Text = resident.MaritalStatus;
        txtHeight.Text = resident.Height;
        txtWeight.Text = resident.Weight;
        txtReligion.Text = resident.Religion;
        txtClergyman.Text = resident.Clergyman;
        txtChurchSynagogue.Text = resident.ChurchSynagogue;
        txtChurchSynagogueTelephone.Text = resident.ChurchSynagogueTelephone;
        txtAddress.Text = resident.Address;
        txtAddressTelephone.Text = resident.AddressTelephone;
        txtSocialSecurity.Text = resident.SocialSecurity;
        txtMedicare.Text = resident.Medicare;
        txtMedicaid.Text = resident.Medicaid;
        txtInsurance.Text = resident.Insurance;
        txtInsuranceAddress.Text = resident.InsuranceAddress;
        txtInsuranceAddressTelephone.Text = resident.InsuranceAddressTelephone;
        txtPolicy.Text = resident.Policy;
        txtInsuranceGroup.Text = resident.InsuranceGroup;
        txtInsuranceGroupNo.Text = resident.InsuranceGroupNo;
        txtResponsibleParty.Text = resident.ResponsibleParty;
        txtResponsiblePartyRelationship.Text = resident.ResponsiblePartyRelationship;
        txtResponsiblePartyAddress.Text = resident.ResponsiblePartyAddress;
        txtResponsiblePartyTelephone.Text = resident.ResponsiblePartyTelephone;
        txtPowerOfAttorney.Text = resident.PowerOfAttorney;
        txtPowerOfAttorneyAddress.Text = resident.PowerOfAttorneyAddress;
        txtPowerOfAttorneyRelationship.Text = resident.PowerOfAttorneyRelationship;
        txtPowerOfAttorneyTelephone.Text = resident.PowerOfAttorneyTelephone;
        txtNearestRelativeOrGuardian.Text = resident.NearestRelativeOrGuardian;
        txtNearestRelativeOrGuardianRelationship.Text = resident.NearestRelativeOrGuardianRelationship;
        txtNearestRelativeOrGuardianAddress.Text = resident.NearestRelativeOrGuardianAddress;
        txtNearestRelativeOrGuardianTelephone.Text = resident.NearestRelativeOrGuardianTelephone;
        txtNotifyInCaseOfEmergency.Text = resident.NotifyInCaseOfEmergency;
        txtNotifyInCaseOfEmergencyRelationship.Text = resident.NotifyInCaseOfEmergencyRelationship;
        txtNotifyInCaseOfEmergencyAddress.Text = resident.NotifyInCaseOfEmergencyAddress;
        txtNotifyInCaseOfEmergencyTelephone.Text = resident.NotifyInCaseOfEmergencyTelephone;
        txtHospitalPreference.Text = resident.HospitalPreference;
        txtHospitalPreferenceTelephone.Text = resident.HospitalPreferenceTelephone;
        txtHospitalPreferenceEmail.Text = resident.HospitalPreferenceEmail;
        txtFuneralHomePreference.Text = resident.FuneralHomePreference;
        txtFuneralHomePreferenceTelephone.Text = resident.FuneralHomePreferenceTelephone;
        txtPharmacyPreference.Text = resident.PharmacyPreference;
        txtPharmacyPreferenceTelephone.Text = resident.PharmacyPreferenceTelephone;
        txtDentist.Text = resident.Dentist;
        txtDentistTelephone.Text = resident.DentistTelephone;
        txtAttendingPhysician.Text = resident.AttendingPhysician;
        txtAttendingPhysicianAddress.Text = resident.AttendingPhysicianAddress;
        txtAttendingPhysicianTelephone.Text = resident.AttendingPhysicianTelephone;
        txtAlternatePhysician.Text = resident.AlternatePhysician;
        txtAlternatePhysicianAddress.Text = resident.AlternatePhysicianAddress;
        txtAlternatePhysicianTelephone.Text = resident.AlternatePhysicianTelephone;
        txtDateofLastPhysicalExam.Text = CheckNullDate(resident.DateofLastPhysicalExam);//.ToString("dd MMM yyyy");
        txtYearlyPhysicalDue.Text = resident.YearlyPhysicalDue;
        txtDiagnosis.Text = resident.Diagnosis;
        txtAllergies.Text = resident.Allergies;
        txtDischargedOrExpiredDate.Text = CheckNullDate(resident.DischargedOrExpiredDate);//.ToString("dd MMM yyyy");
        txtDischargedOrExpiredReason.Text = resident.DischargedOrExpiredReason;
        cbIsWithoutMDApproval.Checked = resident.IsWithoutMDApproval;
        txtReleasedTo.Text = resident.ReleasedTo;
        txtNewAddress.Text = resident.NewAddress;
        txtPlaceOfDeathAddressnCitynCountynState.Text = resident.PlaceOfDeathAddressnCitynCountynState;
        txtPrecinctNo.Text = resident.PrecinctNo;
        txtMorticianName.Text = resident.MorticianName;
        txtSignature.Text = resident.Signature;
        ddlPropertyID.SelectedValue = resident.ExtraField1;
        txtExtraField8.Text = resident.ExtraField8;
        ddlStatus.SelectedValue = resident.ExtraField10 == "InActive" ? "InActive" : "Active";
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (uplFile.PostedFile != null && uplFile.PostedFile.ContentLength > 0)
        {
            //try
            //{
            string dirUrl = "ResidentFile";
            string dirPath = Server.MapPath(dirUrl);

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            string fileName = Path.GetFileName(uplFile.PostedFile.FileName);
            string fileUrl = dirUrl + "/" + Path.GetFileName(uplFile.PostedFile.FileName);
            string filePath = Server.MapPath(fileUrl);
            uplFile.PostedFile.SaveAs(filePath);

            var clientId = int.Parse(Request.QueryString["residentID"]);

            Document dm = new Document();
            dm.ClientID = clientId;
            dm.Details = txDocumentDetails.Text;
            dm.FileName = dirUrl + "/" + fileName;

            int result = DocumentManager.InsertDocument(dm);

            showDocumentClinet(clientId);
        }
    }
    private void showDocumentClinet(int clientId)
    {
        gvDocument.DataSource = DocumentManager.GetDocumentByClientID(clientId);
        gvDocument.DataBind();
    }
}
