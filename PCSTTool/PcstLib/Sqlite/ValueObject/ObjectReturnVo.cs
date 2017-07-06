using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcstLib.Sqlite.Entities;

namespace PcstLib.Sqlite.ValueObject
{
    public class ObjectReturnVo
    {
        public int Id { get; set; }
        public List<MessageErrorVo> Error { get; set; }
    }
}
