using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using Nop.Core.Data;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Data;
using Nop.Plugin.Tax.CountryStateZip.Data;
using Nop.Plugin.Tax.CountryStateZip.Domain;
using Nop.Plugin.Tax.CountryStateZip.Services;
using Nop.Web.Framework.Mvc;

namespace Nop.Plugin.Tax.CountryStateZip
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            builder.RegisterType<TaxRateService>().As<ITaxRateService>().InstancePerHttpRequest();

            //data context
            this.RegisterPluginDataContext<TaxRateObjectContext>(builder, "nop_object_context_tax_country_state_zip");

            //override required repository with our custom context
            builder.RegisterType<EfRepository<TaxRate>>()
                .As<IRepository<TaxRate>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>("nop_object_context_tax_country_state_zip"))
                .InstancePerHttpRequest();
        }

        public int Order
        {
            get { return 1; }
        }
    }
}
