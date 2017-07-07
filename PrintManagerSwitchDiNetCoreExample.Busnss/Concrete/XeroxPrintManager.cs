using System;
using System.Collections.Generic;
using System.Text;

namespace PrintManagerSwitchDiNetCoreExample.Busnss.Concrete
{
    public class XeroxPrintManager:PrintManagerBase
    {
        public override string Print()
        {
            return "Print from xerox device";
        }
    }
}
