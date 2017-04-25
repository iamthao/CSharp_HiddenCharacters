using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateFile.GendataDefault
{
    public static class ScriptSqliteHelper
    {
        public const string TableLanguage = @"CREATE TABLE IF NOT EXISTS
                                [primarylanguage] (
                                [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                [Name] NVARCHAR(100) NOT NULL,
                                [LanguageCodes] NVARCHAR(10) NULL,
                                [IsDefault] BOOLEAN NOT NULL)";

        public const string InsertLanguageSchedule =
            @"INSERT INTO [primarylanguage] ([Name], [LanguageCodes], [IsDefault]) values ";

        public const string InsertLanguageValue = @"(|0|, |1|, |2|)";

        public const string TableCounty = @"CREATE TABLE IF NOT EXISTS
                                [county] (
                                [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                [Name] NVARCHAR(100) NOT NULL,
                                [Code] NVARCHAR(2) NULL,
                                [StateId] INTEGER NOT NULL)";
        public const string InsertCountySchedule = @"INSERT INTO [county] ([Name], [Code], [StateId]) values ";
        public const string InsertCountyValue = @"(|0|, |1|, |2|)";

        public const string TableIcd = @"CREATE TABLE IF NOT EXISTS
                                [icd] (
                                [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                [Code] NVARCHAR(50) NOT NULL UNIQUE,
                                [Description] NVARCHAR(1000) NOT NULL,
                                [ICDType] INTEGER NOT NULL)";
        public const string InsertIcdSchedule = @"INSERT INTO [icd] ([Code], [Description], [ICDType]) values ";
        public const string InsertIcdValue = @"(|0|, |1|, |2|)";

        public const string TableNpi = @"CREATE VIRTUAL TABLE IF NOT EXISTS 
                                [npidata] USING fts4(
                                [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                [NPI] NVARCHAR(10) NOT NULL UNIQUE,
                                [LastName] NVARCHAR(25) NULL,
                                [FirstName] NVARCHAR(13) NULL,
                                [MiddleName] NVARCHAR(1) NULL,
                                [Address1] NVARCHAR(30) NULL,
                                [Address2] NVARCHAR(30) NULL,
                                [City] NVARCHAR(30) NULL,
                                [State] NVARCHAR(2) NULL,
                                [Zip] NVARCHAR(5) NULL,
                                [Phone] NVARCHAR(10) NULL,
                                [Fax] NVARCHAR(10) NULL,
                                [MedicaidId] NVARCHAR(9) NULL,
                                [EffectiveDate] DATETIME NULL,
                                [EndDate] DATETIME NULL,
                                [ProviderType] NVARCHAR(2) NULL,
                                [ProviderTypeDescription] NVARCHAR(50) NULL,
                                [ProviderSpecialty] NVARCHAR(3) NULL,
                                [ProviderSpecialtyDescription] NVARCHAR(50) NULL,
                                [PracticeLocationNameType] NVARCHAR(1) NULL,
                                [PracticeLocationName] NVARCHAR(50) NULL,
                                [ZipExtension] NVARCHAR(4) NULL)";

        public const string InsertNpiSchedule =
            @"INSERT INTO [npidata] ([NPI], [LastName], [FirstName], [MiddleName], [Address1], [Address2], [City], [State], [Zip], [Phone], [EffectiveDate], [EndDate], [ProviderType], [ProviderSpecialty], [PracticeLocationName], [ZipExtension]) values ";

        public const string InsertNpiValue =
            @"(|0|, |1|, |2|, |3|, |4|, |5|, |6|, |7|, |8|, |9|, |10|, |11|, |12|, |13|, |14|, |15|)";

        public const string TableRoute = @"CREATE TABLE IF NOT EXISTS
                                [route] (
                                [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                [Name] NVARCHAR(100) NOT NULL,
                                [OrderNumber] INTEGER NOT NULL,
                                [IsDefault] BOOLEAN NOT NULL)";
        public const string InsertRouteSchedule = @"INSERT INTO [route] ([Name], [OrderNumber], [IsDefault]) values ";
        public const string InsertRouteValue = @"(|0|, |1|, |2|)";

        public const string TableFrequency = @"CREATE TABLE IF NOT EXISTS
                                [frequency] (
                                [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                [Name] NVARCHAR(50) NOT NULL,
                                [OrderNumber] INTEGER NULL,
                                [IsDefault] BOOLEAN NOT NULL)";

        public const string InsertFrequencySchedule =
            @"INSERT INTO [frequency] ([Name], [OrderNumber], [IsDefault]) values ";

        public const string InsertFrequencyValue = @"(|0|, |1|, |2|)";


        public const string TableSection = @"CREATE TABLE IF NOT EXISTS
                                [section] (
                                [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                [Name] NVARCHAR(200) NOT NULL,
                                [Content] TEXT NOT NULL,
                                [Order] INTEGER NOT NULL,
                                [PcstVersion] INTEGER NOT NULL,
                                [Calculator] TEXT NULL)";

        public const string InsertSectionSchedule =
            @"INSERT INTO [section] ([Name], [Content], [Order], [PcstVersion], [Calculator]) values ";

        public const string InsertSectionValue = @"(|0|, |1|, |2|, |3|, |4|)";

        public const string TableSectionQuestion = @"CREATE TABLE IF NOT EXISTS
                                [sectionquestion] (
                                [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                [Content] TEXT NOT NULL, 
                                [Parameters] TEXT NOT NULL, 
                                [Calculator] TEXT NULL, 
                                [Order] INTEGER NOT NULL, 
                                [SectionId] INTEGER NOT NULL, 
                                [Name] NVARCHAR(200) NOT NULL, 
                                [PcstVersion] INTEGER NOT NULL, 
                                [IsSignature] BOOLEAN NULL, 
                                [IsSignatureDate] BOOLEAN NULL, 
                                [IsBathing] BOOLEAN NULL, 
                                [IsADLsCal] BOOLEAN NULL, 
                                [IsMOT] BOOLEAN NULL, 
                                [IsMedicalAppointments] BOOLEAN NULL, 
                                [IsServicesIncidental] BOOLEAN NULL, 
                                [IsBehaviorsMedicalConditionsSeizures] BOOLEAN NULL, 
                                [IsDiagnoses] BOOLEAN NULL, 
                                [IsMedications] BOOLEAN NULL, 
                                [IsDME] BOOLEAN NULL, 
                                [IsAllergies] BOOLEAN NULL, 
                                [IsFunctionalLimitation] BOOLEAN NULL, 
                                [IsActivitiesPermitted] BOOLEAN NULL, 
                                [IsMentalStatus] BOOLEAN NULL, 
                                [IsReassessmentDue] BOOLEAN NULL, 
                                [IsCheckZeroMinutesPCST] BOOLEAN NULL,
                                [IsMid] BOOLEAN NULL,
                                [FieldCheckDME] TEXT NULL,
                                CONSTRAINT `section_sectionquestion` FOREIGN KEY (`SectionId`) REFERENCES `section` (`Id`) ON UPDATE NO ACTION ON DELETE NO ACTION)";

        public const string InsertSectionQuestionSchedule =
            @"insert into `sectionquestion` (`Content`, `Parameters`, `Calculator`, `Order`, `SectionId`, `Name`,
                                                            `PcstVersion`, `IsSignature`, `IsSignatureDate`, `IsBathing`, `IsADLsCal`, `IsMOT`, `IsMedicalAppointments`,
                                                           `IsServicesIncidental`, `IsBehaviorsMedicalConditionsSeizures`, `IsDiagnoses`, `IsMedications`, `IsDME`,
                                                            `IsAllergies`, `IsFunctionalLimitation`, `IsActivitiesPermitted`, `IsMentalStatus`, `IsReassessmentDue`,
                                                            `IsCheckZeroMinutesPCST`, `IsMid`, `FieldCheckDME`) values ";

        public const string InsertSectionQuestionValue =
            @"(|0|, |1|, |2|, |3|, |4|, |5|, |6|, |7|, |8|, |9|, |10|, |11|, |12|, |13|, |14|, |15|, |16|, |17|, |18|, |19|, |20|, |21|, |22|, |23|, |24|, |25|)";

        public const string TableAssessmentSectionQuestion = @"CREATE TABLE IF NOT EXISTS
                                [assessmentsectionquestion] (
                                [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                [AssessmentId] INTEGER NOT NULL REFERENCES assessment([Id]) ON DELETE RESTRICT ON UPDATE RESTRICT,
                                
                                [SectionQuestionId] INTEGER NOT NULL,
                                [Order] INTEGER NOT NULL,
                                [Field01] text NULL,
                                [Field02] text NULL,
                                [Field03] text NULL,
                                [Field04] text NULL,
                                [Field05] text NULL,
                                [Field06] text NULL,
                                [Field07] text NULL,
                                [Field08] text NULL,
                                [Field09] text NULL,
                                [Field10] text NULL,
                                [Field11] text NULL,
                                [Field12] text NULL,
                                [Field13] text NULL,
                                [Field14] text NULL,
                                [Field15] text NULL,
                                [Field16] text NULL,
                                [Field17] text NULL,
                                [Field18] text NULL,
                                [Field19] text NULL,
                                [Field20] text NULL,
                                [Field21] text NULL,
                                [Field22] text NULL,
                                [Field23] text NULL,
                                [Field24] text NULL,
                                [Field25] text NULL,
                                [Field26] text NULL,
                                [Field27] text NULL,
                                [Field28] text NULL,
                                [Field29] text NULL,
                                [Field30] text NULL,
                                [Field31] text NULL,
                                [Field32] text NULL,
                                [Field33] text NULL,
                                [Field34] text NULL,
                                [Field35] text NULL,
                                [Field36] text NULL,
                                [Field37] text NULL,
                                [Field38] text NULL,
                                [Field39] text NULL,
                                [Field40] text NULL,
                                [Field41] text NULL,
                                [Field42] text NULL,
                                [Field43] text NULL,
                                [Field44] text NULL,
                                [Field45] text NULL,
                                [Field46] text NULL,
                                [Field47] text NULL,
                                [Field48] text NULL,
                                [Field49] text NULL,
                                [Field50] text NULL,
                                [Field51] text NULL,
                                [Field52] text NULL,
                                [Field53] text NULL,
                                [Field54] text NULL,
                                [Field55] text NULL,
                                [Field56] text NULL,
                                [Field57] text NULL,
                                [Field58] text NULL,
                                [Field59] text NULL,
                                [Field60] text NULL,
                                [Field61] text NULL,
                                [Field62] text NULL,
                                [Field63] text NULL,
                                [Field64] text NULL,
                                [Field65] text NULL,
                                [Field66] text NULL,
                                [Field67] text NULL,
                                [Field68] text NULL,
                                [Field69] text NULL,
                                [Field70] text NULL,
                                [Field71] text NULL,
                                [Field72] text NULL,
                                [Field73] text NULL,
                                [Field74] text NULL,
                                [Field75] text NULL,
                                [Field76] text NULL,
                                [Field77] text NULL,
                                [Field78] text NULL,
                                [Field79] text NULL,
                                [Field80] text NULL,
                                [Field81] text NULL,
                                [Field82] text NULL,
                                [Field83] text NULL,
                                [Field84] text NULL,
                                [Field85] text NULL,
                                [Field86] text NULL,
                                [Field87] text NULL,
                                [Field88] text NULL,
                                [Field89] text NULL,
                                [Field90] text NULL,
                                [Field91] text NULL,
                                [Field92] text NULL,
                                [Field93] text NULL,
                                [Field94] text NULL,
                                [Field95] text NULL,
                                [Field96] text NULL,
                                [Field97] text NULL,
                                [Field98] text NULL,
                                [Field99] text NULL)";
        public const string TableAssessment = @"CREATE TABLE IF NOT EXISTS
                                [assessment] (
                                [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                [FileName] NVARCHAR(200) NOT NULL,
                                [FilePath] NVARCHAR(1000) NOT NULL,
                                [CreatedOn] DATETIME NOT NULL,
                                [ModifiedOn] DATETIME NOT NULL,
                                [AssessmentData] TEXT NULL,
                                [DisclosureFormData] TEXT NULL,
                                [Extension] TEXT NULL,
                                [Mid] NVARCHAR(20) NULL)";

        public const string TablePhysicanNpi = @"CREATE TABLE IF NOT EXISTS 
                                [physiciannpi] (
                                [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                [MPI] NVARCHAR(10) NULL ,
                                [NPI] NVARCHAR(10) NULL,
                                [ProviderType] NVARCHAR(2) NULL,
                                [ProviderTypeDescription] NVARCHAR(50) NULL,
                                [ProviderSpecialty] NVARCHAR(3) NULL,
                                [ProviderSpecialtyDescription] NVARCHAR(50) NULL,
                                [LastName] NVARCHAR(25) NULL,
                                [FirstName] NVARCHAR(13) NULL,
                                [MiddleName] NVARCHAR(1) NULL,
                                [Address1] NVARCHAR(200) NULL,
                                [Address2] NVARCHAR(100) NULL,
                                [City] NVARCHAR(30) NULL,
                                [State] NVARCHAR(2) NULL,
                                [Zip] NVARCHAR(10) NULL,
                                [ZipExtension] NVARCHAR(4) NULL,
                                [Phone] NVARCHAR(10) NULL,                              
                                [EffectiveDate] NVARCHAR(2000) NULL)";

        public const string InsertPhysicanNpiSchedule =
            @"INSERT INTO [physiciannpi] ([MPI],[NPI],[ProviderType], [ProviderSpecialty],[ProviderSpecialty], [ProviderSpecialtyDescription], [LastName], [FirstName], [MiddleName], [Address1], [Address2], [City], [State], [Zip], [ZipExtension], [Phone],  [EffectiveDate]) values ";

        public const string InsertPhysicanNpiValue =
            @"(|0|, |1|, |2|, |3|, |4|, |5|, |6|, |7|, |8|, |9|, |10|, |11|, |12|, |13|, |14|, |15|, |16|)";

        public const string TableProviderAgency = @"CREATE TABLE IF NOT EXISTS 
                                [provideragency] (
                                [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                [Name] NVARCHAR(150) NULL ,
                                [MPI] NVARCHAR(10) NULL ,
                                [NPI] NVARCHAR(10) NULL,
                                [Phone] NVARCHAR(20) NULL,
                                [Fax] NVARCHAR(20) NULL,
                                [Email] NVARCHAR(100) NULL,
                                [Address1] NVARCHAR(200) NULL,
                                [Address2] NVARCHAR(100) NULL,
                                [City] NVARCHAR(30) NULL,
                                [State] NVARCHAR(2) NULL,
                                [Zip] NVARCHAR(10) NULL,
                                [County] NVARCHAR(50) NULL,
                                [IsActive] BOOLEAN NULL,
                                [IsInvalid] BOOLEAN NULL,
                                [ZipPlus] NVARCHAR(5) NULL)";

        public const string InsertProviderAgencySchedule =
            @"INSERT INTO [provideragency] ([Name],[MPI],[NPI],[Phone], [Fax],[Email], [Address1], [Address2], [City], [State], [Zip], [County], [IsActive],
                            [IsInvalid], [ZipPlus]) values ";

        public const string InsertProviderAgencyValue =
            @"(|0|, |1|, |2|, |3|, |4|, |5|, |6|, |7|, |8|, |9|, |10|, |11|, |12|, |13|, |14|)";

        public const string TableProviderMpi = @"CREATE TABLE IF NOT EXISTS 
                                [providermpi] (
                                [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                [Mpi] NVARCHAR(9) NULL ,
                                [Npi] NVARCHAR(10) NULL ,
                                [ProviderType] NVARCHAR(2) NULL,
                                [ProviderTypeDescription] NVARCHAR(50) NULL,
                                [ProviderSpecialty] NVARCHAR(3) NULL,
                                [ProviderSpecialtyDescription] NVARCHAR(50) NULL,
                                [Name] NVARCHAR(50) NULL,
                                [Address1] NVARCHAR(100) NULL,
                                [Address2] NVARCHAR(100) NULL,
                                [City] NVARCHAR(30) NULL,
                                [State] NVARCHAR(2) NULL,
                                [Zip] NVARCHAR(10) NULL,
                                [ZipExtension] NVARCHAR(4) NULL,
                                [Phone] NVARCHAR(20) NULL,
                                [EffectiveDate] NVARCHAR(2000) NULL)";

        public const string InsertProviderMpiSchedule =
            @"INSERT INTO [providermpi] ([Mpi],[Npi],[ProviderType],[ProviderTypeDescription], [ProviderSpecialty],[ProviderSpecialtyDescription], [Name], 
                [Address1], [Address2], [City], [State], [Zip], [ZipExtension], [Phone], [EffectiveDate]) values ";

        public const string InsertProviderMpiValue =
            @"(|0|, |1|, |2|, |3|, |4|, |5|, |6|, |7|, |8|, |9|, |10|, |11|, |12|, |13|, |14|)";
    }
}
