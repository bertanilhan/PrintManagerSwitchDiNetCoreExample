using Microsoft.AspNetCore.Mvc;

namespace PrintManagerSwitchDiNetCoreExample.WebUi.Utilities
{
    public interface IInstanceResolverFactory
    {
        object GetInstance(ControllerContext controllerContext, string query);
    }
}
