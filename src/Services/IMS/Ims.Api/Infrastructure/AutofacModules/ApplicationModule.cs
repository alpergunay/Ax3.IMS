using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Ims.Domain.DomainModels;
using Ims.Infrastructure.Idempotency;
using Ims.Infrastructure.Repositories;

namespace Ims.Api.Infrastructure.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        public string QueriesConnectionString { get; }

        public ApplicationModule(string qconstr)
        {
            QueriesConnectionString = qconstr;
        }

        protected override void Load(ContainerBuilder builder)
        {
            #region Repositories
            builder.RegisterType<RequestManager>()
                .As<IRequestManager>()
                .InstancePerLifetimeScope();
            builder.RegisterType<StoreTypeRepository>()
                .As<IStoreTypeRepository>()
                .InstancePerLifetimeScope();

            #endregion

            #region Validations

            

            #endregion

        }
    }
}
