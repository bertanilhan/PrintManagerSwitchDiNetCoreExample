using System;
using System.Collections.Generic;
using System.Text;
using Ninject.Modules;
using PrintManagerSwitchDiNetCoreExample.Busnss.Abstract;
using PrintManagerSwitchDiNetCoreExample.Busnss.Concrete;

namespace PrintManagerSwitchDiNetCoreExample.Busnss.DependencyResolvers
{
    public class KonicaMinoltaBusinessModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IPrintService>().To<KonicaMinoltaPrintManager>().InSingletonScope();
        }
    }
}
