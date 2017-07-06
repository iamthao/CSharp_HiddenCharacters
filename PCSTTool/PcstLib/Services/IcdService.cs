using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcstLib.Sqlite;


namespace PcstLib.Services
{
    public class IcdService
    {
        public List<string> GetListIcd(string query)
        {
            using (var context = new DefaulDataContext())
            {
                var listIcd = context.Icds.Where(o => string.IsNullOrEmpty(query) || 
                    (o.Code + ":" + o.Description).ToLower().Contains(query.ToLower())).Select(s => s.Code + ":" + s.Description).Take(10).ToList();
                return listIcd;
            }
        }
    }
}
