using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLR.CFM.DCP.Import
{
    internal class SafetyArea
    {
        internal string ShortDesc { get; set; }
        internal string LongDesc { get; set; }
        internal string ID { get; set; }
        internal Zone Patrent { get; set; }
        internal SafetyArea(string id)
        {

        }
    }
}
