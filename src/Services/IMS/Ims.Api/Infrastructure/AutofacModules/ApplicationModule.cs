using System.Reflection;
using Autofac;
using Ax3.IMS.Infrastructure.Core.Services;
using Ax3.IMS.Infrastructure.EventBus.Abstractions;
using Ims.Api.Application.Modules.Infrastructure.IntegrationEvents.Handlers;
using Ims.Api.Application.Modules.Infrastructure.Queries;
using Ims.Domain.DomainModels;
using Ims.Infrastructure.Idempotency;
using Ims.Infrastructure.Repositories;

namespace Ims.Api.Infrastructure.AutofacModules
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
            builder.RegisterType<AccountRepository>()
                .As<IAccountRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<StoreRepository>()
                .As<IStoreRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<StoreBranchRepository>()
                .As<IStoreBranchRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<InvestmentToolRepository>()
                .As<IInvestmentToolRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<AccountTransactionRepository>()
                .As<IAccountTransactionRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .InstancePerLifetimeScope();

            builder.Register(c => new ImsQueries(QueriesConnectionString))
                .As<IImsQueries>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserHttpService>()
                .As<IUserService>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(UserCreatedIntegrationEventHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));

            #endregion

            #region Validations



            #endregion

        }
    }
}
