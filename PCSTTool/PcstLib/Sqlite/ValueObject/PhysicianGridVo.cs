using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcstLib.Utility;

namespace PcstLib.Sqlite.ValueObject
{
    public class PhysicianGridVo
    {
        public string Mpi { get; set; }
        public string Npi { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string ZipExtension { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string ClinicName { get; set; }
        public string EffectiveDateText { get; set; }
        public string PhoneInFormat { get { return Phone.ApplyFormatPhone(); } }
        public string FullAddress { get { return CaculatorHelper.GetFullAddress(Address1, Address2, City, State, Zip); } }
        public string FullName { get { return CaculatorHelper.GetFullName(FirstName, MiddleName, LastName); } }
        public string FaxInFormat { get { return Fax.ApplyFormatPhone(); } }
    }
}
