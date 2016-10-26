using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLR.CFM.DCP.Import
{
    class Sequence
    {
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string ID { get; set; }
        public SafetyArea Patrent { get; set; }
        public Sequence(string id)
        {

        }
    }
}
