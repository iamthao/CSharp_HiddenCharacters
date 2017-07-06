using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcstLib.Sqlite;
namespace PcstLib.Services
{
    public class FrequencyService
    {
        public List<string> GetListFrequency()
        {
            using (var context = new DefaulDataContext())
            {
                var listFrequency = context.Frequencies.OrderBy(p => p.OrderNumber).Select(t => t.Name).ToList();
                return listFrequency;
            }
        }
    }
}
