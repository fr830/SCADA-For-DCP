﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLR.CFM.DCP.Import
{
    interface Station : CimplicityClass
    {

        Sequence Patrent { get; set; }
    }
}
