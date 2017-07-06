using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcstLib.Sqlite.Entities;
using PcstLib.Utility;

namespace PcstLib.Sqlite.ValueObject
{
    public class RequestAssessmentPcsVo
    {
        //public int Id { get; set; }
        public int RequestId { get; set; }
        public string RequestNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public string FullName
        {
            get { return CaculatorHelper.GetFullName(FirstName, MiddleName, LastName); }
        }

        public int? Gender { get; set; }
        public DateTime? Dob { get; set; }

        public string DobStr
        {
            get { return Dob != null ? Dob.GetValueOrDefault().ToString("MM/dd/yyyy") : ""; }
        }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }

        public string FullAddress
        {
            get { return CaculatorHelper.GetFullAddress(Address1, Address2, City, State, Zip); }
        }

        public int AssessmentPcsId { get; set; }
        public List<AssQuestionVo> AssessmentSectionQuestions { get; set; }
        public List<SectionVo> Sections { get; set; }
        public int PcsVersion { get; set; }
        public List<string> Exceptions { get; set; }
        public string TaskActionParamViewModelStr { get; set; }
        public bool IsNewVersion { get; set; }
        public bool IsAutoSave { get; set; }
        public int? UpdaterId { get; set; }
        public int? MOT { get; set; }
        public int? TotalHours { get; set; }
        public int? TotalEquipment { get; set; }
        public int? ADLTime { get; set; }
        public int? MedicalAppoimentTime { get; set; }
        public int? AdditionTime { get; set; }

        //Thao add//
        public int? ClientTimeZone { get; set; }
        public string MedicaidId { get; set; }
        //public List<string> ListCountry { get; set; }
        //public List<string> ListPrimaryLanguage { get; set; }
        public string AssessorId { get; set; }
        public RequestType RequestType { get; set; }
        public string LastCompleteAssessmentDate { get; set; }
        public string MemberPhone { get; set; }
        public string MemberState { get; set; }

        //physician
        public DateTime? PhysicianDateLastSeen { get; set; }

        public string PhysicianDateLastSeenStr
        {
            get
            {
                if (PhysicianDateLastSeen != null)
                    return PhysicianDateLastSeen.GetValueOrDefault().ToShortDateString();
                return "";
            }
        }
        public string PhysicianFirstName { get; set; }
        public string PhysicianLastName { get; set; }
        public string PhysicianMiddleName { get; set; }

        public string PhysicianFullName
        {
            get
            {
                return CaculatorHelper.GetFullName(PhysicianFirstName, PhysicianMiddleName, PhysicianLastName);
            }
        }
        public string PhysicianNPI { get; set; }
        public string PhysicianMID { get; set; }
        public string PhysicianPhone { get; set; }
        public string PhysicianFax { get; set; }
        public string PhysicianPracticeName { get; set; }
        public string PhysicianAddress1 { get; set; }
        public string PhysicianAddress2 { get; set; }
        public string PhysicianZip { get; set; }
        public string PhysicianCity { get; set; }
        public string PhysicianState { get; set; }
        public string PhysicianFullAddress
        {
            get
            {
                return CaculatorHelper.GetFullAddress(PhysicianAddress1, PhysicianAddress2, PhysicianCity, PhysicianState, PhysicianZip);
            }
        }

        public List<DiagnosesPcst> ListDiagnosses { get; set; }
        public string AssessmentName { get; set; }
        public bool? IsSaveAll { get; set; }

        public DisclosureFormVo DisclosureFormVo { get; set; }
        public List<MessageErrorVo> MessageErrorTotal { get; set; }
        public int? CurrentSectionId { get; set; }
        public int? TabSelected { get; set; }

    }

    public class ExtensionAssessment
    {
        public bool DisclosureFormIsComplete { get; set; }
        public List<MessageErrorVo> ErrorDisclosureForm { get; set; } 
    }
}
