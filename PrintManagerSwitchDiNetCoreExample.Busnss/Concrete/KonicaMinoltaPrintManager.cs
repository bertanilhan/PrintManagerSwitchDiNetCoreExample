﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PrintManagerSwitchDiNetCoreExample.Busnss.Concrete
{
    public class KonicaMinoltaPrintManager:PrintManagerBase
    {
        public override string Print()
        {
            return "Print from Konica Minolta device";
        }
    }
}
