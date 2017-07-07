using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PrintManagerSwitchDiNetCoreExample.WebUi.Utilities
{
    public class CustomInstanceResolverFactory:IInstanceResolverFactory
    {
        public object GetInstance(ControllerContext controllerContext, string query)
        {
            throw new NotImplementedException();
        }
    }
}
