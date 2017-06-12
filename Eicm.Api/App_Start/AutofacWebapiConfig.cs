using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Eicm.BusinessLogic;
using Eicm.DataLayer;
using Eicm.Repository;

namespace Eicm.Api
{
    public class AutofacWebapiConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<CoreDbContext>()
                .As<ICoreDbContext>()
                .InstancePerRequest();

            builder.RegisterType<TicketBusinessLogic>()
                .As<ITicketBusinessLogic>()
                .InstancePerRequest();

            builder.RegisterType<TicketNoteBusinessLogic>()
                .As<ITicketNoteBusinessLogic>()
                .InstancePerRequest();

            builder.RegisterType<TicketRepository>()
                .As<ITicketRepository>()
                .InstancePerRequest();

            builder.RegisterType<TicketCommentsRepository>()
                .As<ITicketCommentsRepository>()
                .InstancePerRequest();

            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();

            return Container;
        }

    }
}