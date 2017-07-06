using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcstLib.Sqlite;

namespace PcstLib.Services
{
    public class PrimaryLanguageService
    {
        public List<string> GetListPrimaryLanguage()
        {
            using (var context = new DefaulDataContext())
            {
                var listPrimaryLanguage = context.PrimaryLanguages.OrderBy(p => p.Name).Select(t => t.Name).ToList();
                return listPrimaryLanguage;
            }
        }

    }
}
