using System;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Autofac.Extras.NLog;
using Eicm.Api.Controllers;
using Eicm.BusinessLogic;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using Eicm.Repository;

[assembly: OwinStartup(typeof(Eicm.Api.Startup))]

namespace Eicm.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            var apiConfig = new HttpConfiguration();
            //var globalConfig = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterType<BaseApiController>().InstancePerRequest();
            //builder.RegisterType<TicketController>().InstancePerRequest();
            //var allAssembiles = AppDomain.CurrentDomain.GetAssemblies();
            //builder.RegisterAssemblyModules(allAssembiles);
            builder.RegisterType<TicketBusinessLogic>().As<ITicketBusinessLogic>();

            builder.RegisterType<TicketRepository>().As<ITicketRepository>();
            builder.RegisterType<TicketNoteBusinessLogic>().As<ITicketNoteBusinessLogic>();

            builder.RegisterType<TicketCommentsRepository>().As<ITicketCommentsRepository>();
            var container = builder.Build();

            apiConfig.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            //globalConfig.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            //builder.RegisterModule<NLogModule>();
            app.UseCors(CorsOptions.AllowAll);
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(apiConfig);
            app.UseWebApi(apiConfig);
        }
    }
}