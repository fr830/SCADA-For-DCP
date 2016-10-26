using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLR.CFM.DCP.Import
{
    class Plant
    {
        public readonly Dictionary<string, Plc> Plcs = new Dictionary<string, Plc>();
        public readonly Dictionary<string, Sequence> Sequnces = new Dictionary<string, Sequence>();


    }
}
