using Autofac;

namespace Eicm.DataLayer
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CoreDbContext>().As<ICoreDbContext>();
        }
    }
}