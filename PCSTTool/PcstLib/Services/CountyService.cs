using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcstLib.Sqlite;

namespace PcstLib.Services
{
    public class CountyService
    {
        public List<string> GetListCounty(int stateId)
        {
            using (var context = new DefaulDataContext())
            {
                var listIcd = context.Counties.Where(o => o.StateId == stateId).Select(t => t.Name).ToList();
                return listIcd;
            }
        }
    }
}
