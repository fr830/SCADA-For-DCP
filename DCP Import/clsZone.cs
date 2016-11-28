using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLR.CFM.DCP.Import
{
    public class Zone : CimplicityClass
    {
        public string ShortDesc { get; set; }

        public string LongDesc { get; set; }

        public string ID { get; set; }

        public string Resource { get; set; }

        public string ClassID { get { return "SCADA_DCP_ZON"; } }

        public Zone(string id)
        {

        }
    }
}
