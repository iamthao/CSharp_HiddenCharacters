using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcstLib.Sqlite.Base;

namespace PcstLib.Sqlite.Entities
{
    public class ProviderMpi : Entity
    {
        public ProviderMpi()
        {
        }

        public string Mpi { get; set; }
        public string Npi { get; set; }
        public string ProviderType { get; set; }
        public string ProviderTypeDescription { get; set; }
        public string ProviderSpecialty { get; set; }
        public string ProviderSpecialtyDescription { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string ZipExtension { get; set; }
        public string Phone { get; set; }
        public string EffectiveDateText { get; set; }
    }
}
