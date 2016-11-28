using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLR.CFM.DCP.Import
{
    public class Sequence
    {
        public string ShortDesc { get; set; }

        public string LongDesc { get; set; }

        public string ID { get; set; }

        public SafetyArea Patrent { get; set; }

        public static string ClassID { get { return "SCADA_DCP_SEQ"; } }

        public Sequence(string id)
        {
            ID = id;
        }


    }
}
