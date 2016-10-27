using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLR.CFM.DCP.Import
{
    interface Station
    {
        string ShortDesc { get; set; }

        string LongDesc { get; set; }

        string ID { get; set; }

        string Resource { get; set; }

        string ClassID { get; }

        Sequence Patrent { get; set; }
    }
}
