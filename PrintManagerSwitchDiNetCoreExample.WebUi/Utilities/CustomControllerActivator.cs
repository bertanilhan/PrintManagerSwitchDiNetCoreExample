using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Internal;

namespace PrintManagerSwitchDiNetCoreExample.WebUi.Utilities
{
    public class CustomControllerActivator:DefaultControllerActivator
    {
        private readonly IInstanceResolverFactory _resolverFactory;
        public CustomControllerActivator(ITypeActivatorCache typeActivatorCache, IInstanceResolverFactory resolverFactory) : base(typeActivatorCache)
        {
            _resolverFactory = resolverFactory;
        }

        public override object Create(ControllerContext controllerContext)
        {
            var query = controllerContext.HttpContext.Request.Query["Device"].ToString();

            return _resolverFactory.GetInstance(controllerContext, query);
        }
    }
}
