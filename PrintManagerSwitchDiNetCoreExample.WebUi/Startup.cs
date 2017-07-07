using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ninject.Modules;
using PrintManagerSwitchDiNetCoreExample.Busnss.DependencyResolvers;
using PrintManagerSwitchDiNetCoreExample.WebUi.Utilities;

namespace PrintManagerSwitchDiNetCoreExample.WebUi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //--------Middleware--------
            //Bu alan middleware olarak yazılması daha doğru olacaktır.
            //Sabit olan modüller bu alana dizilecektir.
            var constantModule = new INinjectModule[]
            {
                new BusinessModule()
            };

            //Değişken olan modüller bu alana Dizelecektir.
            // 
            var veriableModules = new INinjectModule[]
            {
                new KonicaMinoltaBusinessModule(),
                new XeroxBusinessModule(),
                new BaseBusinessModule()
            };

            //Controller activator set ediliyor.
            //Ninject instance resolver set ediliyor.
            services.AddSingleton<IControllerActivator>(new CustomControllerActivator(new TypeActivatorCache(), new NinjectInstanceResolverFactory(veriableModules, constantModule)));
            //--------Middleware--------



            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Print}/{action=Index}/{id?}");
            });





        }
    }
}
