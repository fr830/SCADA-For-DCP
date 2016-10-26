using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLR.CFM.DCP.Import
{
    class SafetyArea
    {
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string ID { get; set; }
        public Zone Patrent { get; set; }
        public SafetyArea(string id)
        {

        }
    }
}
