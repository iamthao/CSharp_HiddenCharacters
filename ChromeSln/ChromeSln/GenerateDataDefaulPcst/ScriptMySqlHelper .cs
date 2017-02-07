using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateDataDefaulPcst
{
    public static class ScriptMySqlHelper
    {
        public const string TableLanguageCount = @"SELECT COUNT(*) FROM `primarylanguage`;";
        public const string TableLanguage = @"SELECT `Name`, `LanguageCodes`, `IsDefault` FROM `primarylanguage` LIMIT {0}, {1};";
        public const string TableCountyCount = @"SELECT COUNT(*) FROM `county`;";
        public const string TableCounty = @"SELECT `Name`, `Code`, `StateId` FROM `county` LIMIT {0}, {1};";
        public const string TableIcdCount = @"SELECT COUNT(*) FROM `icd`;";
        public const string TableIcd = @"SELECT `Code`, `Description`, `ICDType` FROM `icd` LIMIT {0}, {1};";
        public const string TableNpiCount = @"SELECT COUNT(*) FROM `npidata`;";
        public const string TableNpi = @"SELECT `NPI`, `LastName`, `FirstName`, `MiddleName`, `Address1`, `Address2`, `City`, `State`, `Zip`, `Phone`, `EffectiveDate`, `EndDate`, `ProviderType`, `ProviderSpecialty`, `PracticeLocationName`, `ZipExtension` FROM `npidata` LIMIT {0}, {1};";
        public const string TableRouteCount = @"SELECT COUNT(*) FROM `route`;";
        public const string TableRoute = @"SELECT `Name`, `OrderNumber`, `IsDefault` FROM `route` LIMIT {0}, {1};";
        public const string TableFrequencyCount = @"SELECT COUNT(*) FROM `Frequency`;";
        public const string TableFrequency = @"SELECT `Name`, `OrderNumber`, `IsDefault` FROM `Frequency` LIMIT {0}, {1};";
        public const string TableSectionCount = @"SELECT COUNT(*) FROM `section`;";
        public const string TableSection = @"SELECT `Name`, `Content`, `Order`, `PcstVersion`, `Calculator` FROM `section` LIMIT {0}, {1};";
        public const string TableSectionQuestionCount = @"SELECT COUNT(*) FROM `sectionquestion`;";
        public const string TableSectionQuestion = @"SELECT `Content`, `Parameters`, `Calculator`, `Order`, `SectionId`, `Name`, `PcstVersion`, `IsSignature`, `IsSignatureDate`, `IsBathing`, `IsADLsCal`, `IsMOT`, `IsMedicalAppointments`, `IsServicesIncidental`, `IsBehaviorsMedicalConditionsSeizures`, `IsDiagnoses`, `IsMedications`, `IsDME`, `IsAllergies`, `IsFunctionalLimitation`, `IsActivitiesPermitted`, `IsMentalStatus`, `IsReassessmentDue`, `IsCheckZeroMinutesPCST` FROM `sectionquestion` LIMIT {0}, {1};";
    }
}
