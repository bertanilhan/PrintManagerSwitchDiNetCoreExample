using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Ninject;
using Ninject.Modules;
using Ninject.Planning.Bindings.Resolvers;
using PrintManagerSwitchDiNetCoreExample.Busnss.DependencyResolvers;

namespace PrintManagerSwitchDiNetCoreExample.WebUi.Utilities
{
    public class NinjectInstanceResolverFactory : IInstanceResolverFactory
    {
        private IReadOnlyKernel _kernel;
        private readonly IKernelConfiguration _kernelConfiguration;
        private readonly INinjectModule[] _veriableModules;

        public NinjectInstanceResolverFactory(INinjectModule[] veriableModules, INinjectModule[] constantModules)
        {
            _veriableModules = veriableModules;
            _kernelConfiguration = new KernelConfiguration(constantModules);
            //bunu get instance içine alabilirsin çünkü her seferinde build  olamsı gerekiyor.

        }


        public object GetInstance(ControllerContext controllerContext, string query)
        {
            //.Net Core'da ControllerContex içinde klasik Mvc'den farklı olarak tüm bilgiler gelmektedir.
            //Current controller tipi bir değişkene aktarılıyor. 
            var controllerType = controllerContext.ActionDescriptor.ControllerTypeInfo.AsType();

            //Eğer query ile eşleşen yok ise base class'dan bilgiyi alarak sistemin hata vermesi engellenmiştir.
            switch (query)
            {
                case "Xerox":
                {
                    return GetInstanceHelper(controllerType, typeof(XeroxBusinessModule));
                }
                case "KonicaMinolta":
                {
                    return GetInstanceHelper(controllerType, typeof(KonicaMinoltaBusinessModule));
                }
                default:
                    return GetInstanceHelper(controllerType, typeof(BaseBusinessModule));
            }
        }

        private object GetInstanceHelper(Type controllerType, Type injectModule)
        {
            //Değişken modüller çakışmaması için ilk önce siliniyor.
            //Gelen parametrelere göre yeni modüller yükleniyor.
            CleanModules(); //Aspect Olabilir.

            //Modüller dizizinden istenilen modül alınıyor.
            var module = _veriableModules.SingleOrDefault(x => x.Name == injectModule.FullName);

            //IKernel'a mdül yüklenir.
            _kernelConfiguration.Load(module);

            //Kernel tekrar build edilir.
            _kernel = _kernelConfiguration.BuildReadonlyKernel();

            //Instance alınır.
            var instance = _kernel.Get(controllerType);
            return instance;
        }

        private void CleanModules()
        {
            foreach (var module in _veriableModules)
            {
                // Eğer değişken modüller var ise silinirler.
                if (_kernelConfiguration.HasModule(module.Name))
                {
                    _kernelConfiguration.Unload(module.Name);
                }
            }
        }


    }
}
