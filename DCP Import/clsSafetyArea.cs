using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLR.CFM.DCP.Import
{
    public class SafetyArea : CimplicityClass
    {
        public string ShortDesc { get; set; }

        public string LongDesc { get; set; }

        public string ID { get; set; }

        public string Resource { get; set; }

        public string ClassID { get; }

        public SafetyArea(string id)
        {

        }
    }
}
