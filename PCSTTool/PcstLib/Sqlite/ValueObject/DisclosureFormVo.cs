using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcstLib.Sqlite.ValueObject
{
    public class DisclosureFormVo
    {
        public DisclosureFormVo()
        {
            Providers = new List<ProviderDisclosureFormViewModel>();
        }
        public int Id { get; set; }
        public int RequestTaskId { get; set; }
        public string LastModified { get; set; }
        public MemberDisclosureFormViewModel Member { get; set; }
        public PhysicianDisclosureFormViewModel Physician { get; set; }
        public OtherHealthcareProfessionalViewModel OtherHealthcareProfessional { get; set; }
        public OtherAsListedViewModel OtherAsListed { get; set; }
        public bool IsHasProviderAgency { get; set; }
        public List<ProviderDisclosureFormViewModel> Providers { get; set; }
        public bool IsExercisedToChooseProvider { get; set; }
        public bool DoNotWantToChooseProvider { get; set; }
        public string NotBeReleased { get; set; }
        public bool IsExpiresOneYear { get; set; }
        public bool IsOnTheFollowingDate { get; set; }
        public DateTime? TheFollowingDate { get; set; }
        public GuardianDisclosureFormViewModel Guardian { get; set; }
        public DateTime? DateSigned { get; set; }

        public string DateSignedStr
        {
            get; set;
            //get { return DateSigned.ToString("MM/dd/yyyy"); }
        }
        public string TheFollowingDateStr
        {
            get; set;
            //get { return TheFollowingDate == null ? "" : TheFollowingDate.GetValueOrDefault().ToString("MM/dd/yyyy"); }
        }
    }

    public class ProviderDisclosureFormViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public string Mpi { get; set; }
        public string Npi { get; set; }
    }
    public class MemberDisclosureFormViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Mid { get; set; }
        public DateTime? Dob { get; set; }
        public string DobStr { 
            get; set;
            //get { return Dob.ToString("MM/dd/yyyy"); }
        }
        public string Signature { get; set; }
    }
    public class PhysicianDisclosureFormViewModel
    {
        public string FullName { get; set; }
        public string ClinicName { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public bool IsHasPhysician { get; set; }
    }

    public class OtherHealthcareProfessionalViewModel
    {
        public string FullName { get; set; }
        public string ClinicName { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public bool IsHasOtherHealthcareProfessional { get; set; }
    }

    public class OtherAsListedViewModel
    {
        public OtherAsListedViewModel()
        {
            OtherDisclosureForms = new List<OtherDisclosureForm>();
        }

        public List<OtherDisclosureForm> OtherDisclosureForms { get; set; }
        public bool IsHasOtherAsListed { get; set; }
    }

    public class OtherDisclosureForm
    {
        public string Name { get; set; }
        public string Relationship { get; set; }
    }

    public class GuardianDisclosureFormViewModel
    {
        public string Name { get; set; }
        public string Relationship { get; set; }
        public string Signature { get; set; }
    }
}
