using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PcstLib.Sqlite;
using PcstLib.Sqlite.Entities;
using PcstLib.Sqlite.ValueObject;
using PcstLib.Utility;

namespace PcstLib.Services
{
    public partial class AssessmentService
    {
        public int ImportData(string fileName, string dataDecrypt)
        {
            string encyptKey = ConfigurationManager.AppSettings["EncyptKey"];
            if (string.IsNullOrEmpty(encyptKey))
            {
                throw new Exception("EncyptKey not found in App.config");
            }
            var jsonData = JsonConvert.DeserializeObject<ExportData>(dataDecrypt);

            using (var context = new AssessmentContext())
            {
                var entity = new Assessment
                {
                    FileName = fileName,
                    FilePath = "",
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    AssessmentData = jsonData.AssessmentData,
                    DisclosureFormData = jsonData.DisclosureFormData,
                    Mid = jsonData.MemberNumber
                };
                context.Entry(entity).State = EntityState.Added;
                context.SaveChanges();

                return entity.Id;
            }

        }
    }
}
