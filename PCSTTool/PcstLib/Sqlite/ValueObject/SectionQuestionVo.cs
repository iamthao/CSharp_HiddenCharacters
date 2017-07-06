using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcstLib.Sqlite.ValueObject
{
    public class SectionQuestionVo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Parameters { get; set; }
        public string Calculator { get; set; }
        public int Order { get; set; }
        public bool IsSignature { get; set; }
        public bool IsSignatureDate { get; set; }
        public bool IsBathing { get; set; }
        public bool IsADLsCal { get; set; }
        public bool IsMOT { get; set; }
        public bool IsMedicalAppointments { get; set; }
        public bool? IsServicesIncidental { get; set; }
        public bool? IsBehaviorsMedicalConditionsSeizures { get; set; }
        public bool? IsDiagnoses { get; set; }
        public bool? IsMedications { get; set; }
        public bool? IsDME { get; set; }
        public bool? IsAllergies { get; set; }
        public bool? IsFunctionalLimitation { get; set; }
        public bool? IsActivitiesPermitted { get; set; }
        public bool? IsMentalStatus { get; set; }
        public bool? IsReassessmentDue { get; set; }
        public bool? IsCheckZeroMinutesPCST { get; set; }
        public bool? IsMid { get; set; }
        public int SectionId { get; set; }
    }
}
