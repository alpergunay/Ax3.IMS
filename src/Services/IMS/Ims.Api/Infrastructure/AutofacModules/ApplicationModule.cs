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
            builder.RegisterType<AccountTypeRepository>()
                .As<IAccountTypeRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<DirectionTypeRepository>()
                .As<IDirectionTypeRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<InvestmentToolTypeRepository>()
                .As<IInvestmentToolTypeRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<TransactionTypeRepository>()
                .As<ITransactionTypeRepository>()
                .InstancePerLifetimeScope();
            #endregion

            #region Validations



            #endregion

        }
    }
}
