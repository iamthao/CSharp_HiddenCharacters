﻿using PcstLib.Sqlite.Base;
using PcstLib.Sqlite.Entities;

namespace PcstLib.Sqlite.Maps
{
    public class ProviderMpiMap : SqliteCustomizeMaping<ProviderMpi>
    {
        public ProviderMpiMap()
        {
            ToTable("providermpi");
            Property(s => s.Mpi).HasColumnName("Mpi");
            Property(s => s.Npi).HasColumnName("Npi");
            Property(s => s.Name).HasColumnName("Name");
            Property(s => s.ProviderType).HasColumnName("ProviderType");
            Property(s => s.ProviderTypeDescription).HasColumnName("ProviderTypeDescription");
            Property(s => s.ProviderSpecialty).HasColumnName("ProviderSpecialty");
            Property(s => s.ProviderSpecialtyDescription).HasColumnName("ProviderSpecialtyDescription");
            Property(s => s.Address1).HasColumnName("Address1");
            Property(s => s.Address2).HasColumnName("Address2");
            Property(s => s.City).HasColumnName("City");
            Property(s => s.State).HasColumnName("State");
            Property(s => s.Zip).HasColumnName("Zip");
            Property(s => s.ZipExtension).HasColumnName("ZipExtension");
            Property(s => s.Phone).HasColumnName("Phone");
            Property(s => s.EffectiveDateText).HasColumnName("EffectiveDate");
        }
    }
}