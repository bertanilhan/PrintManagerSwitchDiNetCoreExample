using System;
using System.Collections.Generic;
using System.Text;
using PrintManagerSwitchDiNetCoreExample.Busnss.Abstract;

namespace PrintManagerSwitchDiNetCoreExample.Busnss.Concrete
{
    public class PrintManagerBase:IPrintService
    {
        public virtual string Print()
        {
            return "Print from base manager";
        }
    }
}
