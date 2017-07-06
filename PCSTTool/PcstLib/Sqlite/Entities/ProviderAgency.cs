using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcstLib.Sqlite.Base;

namespace PcstLib.Sqlite.Entities
{
    public class ProviderAgency : Entity
    {
        public ProviderAgency()
        {
        }

        public string Mpi { get; set; }
        public string Npi { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string ZipPlus { get; set; }
        public string County { get; set; }
        public string Email { get; set; }
        public bool? IsInvalid { get; set; }
        public bool IsActive { get; set; }
        public string DeactiveReason { get; set; }
        public int IsApproval { get; set; }
        public string RejectReason { get; set; }
        public bool RegisFromWeb { get; set; }
    }
}
