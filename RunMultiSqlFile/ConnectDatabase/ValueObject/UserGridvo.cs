using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectDatabase.ValueObject
{
    public class UserGridVo : ReadGridVo
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
