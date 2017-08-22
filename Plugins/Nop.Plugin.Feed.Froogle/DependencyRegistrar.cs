using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using Nop.Core.Data;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Data;
using Nop.Plugin.Feed.Froogle.Data;
using Nop.Plugin.Feed.Froogle.Domain;
using Nop.Plugin.Feed.Froogle.Services;
using Nop.Web.Framework.Mvc;

namespace Nop.Plugin.Feed.Froogle
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            builder.RegisterType<GoogleService>().As<IGoogleService>().InstancePerHttpRequest();

            //data context
            this.RegisterPluginDataContext<GoogleProductObjectContext>(builder, "nop_object_context_google_product");

            //override required repository with our custom context
            builder.RegisterType<EfRepository<GoogleProductRecord>>()
                .As<IRepository<GoogleProductRecord>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>("nop_object_context_google_product"))
                .InstancePerHttpRequest();
        }

        public int Order
        {
            get { return 1; }
        }
    }
}
