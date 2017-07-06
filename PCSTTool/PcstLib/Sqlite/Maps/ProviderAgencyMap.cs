using PcstLib.Sqlite.Base;
using PcstLib.Sqlite.Entities;

namespace PcstLib.Sqlite.Maps
{
    public class ProviderAgencyMap : SqliteCustomizeMaping<ProviderAgency>
    {
        public ProviderAgencyMap()
        {
            ToTable("provideragency");
            Property(s => s.Mpi).HasColumnName("MPI");
            Property(s => s.Npi).HasColumnName("NPI");
            Property(s => s.Name).HasColumnName("Name");
            Property(s => s.Phone).HasColumnName("Phone");
            Property(s => s.Fax).HasColumnName("Fax");
            Property(s => s.Address1).HasColumnName("Address1");
            Property(s => s.Address2).HasColumnName("Address2");
            Property(s => s.City).HasColumnName("City");
            Property(s => s.State).HasColumnName("State");
            Property(s => s.Zip).HasColumnName("Zip");
            Property(s => s.ZipPlus).HasColumnName("ZipPlus");
            Property(s => s.County).HasColumnName("County");
            Property(s => s.IsActive).HasColumnName("IsActive");
            Property(s => s.IsInvalid).HasColumnName("IsInvalid");
            Property(s => s.DeactiveReason).HasColumnName("DeactiveReason");
            Property(s => s.IsApproval).HasColumnName("IsAprroval");
            Property(s => s.RejectReason).HasColumnName("RejectReason");
            Property(s => s.RegisFromWeb).HasColumnName("RegisFromWeb");
        }
    }
}
