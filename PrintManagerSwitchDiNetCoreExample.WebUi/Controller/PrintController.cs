using PrintManagerSwitchDiNetCoreExample.Busnss.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintManagerSwitchDiNetCoreExample.WebUi.Controller
{

    public class PrintController:Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IPrintService _printService;

        public PrintController(IPrintService printService)
        {
            _printService = printService;
        }

        public string Index()
        {
            return _printService.Print();
        }
    }
}
