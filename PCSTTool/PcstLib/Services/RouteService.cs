using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcstLib.Sqlite;
namespace PcstLib.Services
{
     public class RouteService
    {
        public List<string> GetListRoute()
        {
            using (var context = new DefaulDataContext())
            {
                var listRoute = context.Routes.OrderBy(p => p.Name).Select(t => t.Name).ToList();
                return listRoute;
            }
        }
    }
}
