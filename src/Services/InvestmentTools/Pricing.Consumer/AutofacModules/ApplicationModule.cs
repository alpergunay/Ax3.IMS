using Autofac;
using Ax3.IMS.Infrastructure.EventBus.Abstractions;
using Pricing.Consumer.EventHandling.EventHandlers;
using System.Reflection;

namespace Pricing.Consumer.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        public string QueriesConnectionString { get; }

        public ApplicationModule(string connectionString)
        {
            QueriesConnectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(InvestmentToolPriceChangedIntegrationEventHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));
        }
    }
}
