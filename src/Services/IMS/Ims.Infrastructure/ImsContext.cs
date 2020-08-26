using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Ax3.IMS.DataAccess.EntityFramework;
using Ax3.IMS.Domain;
using Ax3.IMS.Infrastructure.Core.Services;
using Ims.Domain.DomainModels;
using Ims.Infrastructure.EntityConfigurations;

namespace Ims.Infrastructure
{
    public class ImsContext : BaseDbContext<ImsContext>,
        IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "ims";
        private readonly IMediator _mediator;
        private IDbContextTransaction _currentTransaction;
        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;
        public bool HasActiveTransaction => _currentTransaction != null;
        public DbSet<StoreType> StoreTypes { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<DirectionType> DirectionTypes { get; set; }
        public DbSet<InvestmentToolType> InvestmentToolTypes { get; set; }
        public DbSet<StoreBranch> StoreBranches { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<InvestmentTool> InvestmentTools { get; set; }
        public DbSet<InvestmentToolPrice> InvestmentToolPrices { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountTransaction> AccountTransactions { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Family> Families { get; set; }


        protected ImsContext(DbContextOptions<ImsContext> options, IUserService userService) : base(options,
            userService)
        {
        }


        public ImsContext() : base(new DbContextOptionsBuilder<ImsContext>()
            .UseNpgsql("Server=localhost;Database=ims;User ID=ims;Password=ax32020!").Options)
        {
        }

        public ImsContext(DbContextOptions<ImsContext> options) : base(options) { }

        public ImsContext(DbContextOptions<ImsContext> options, IMediator mediator, IUserService service)
            : base(options, service)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public override async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await _mediator.DispatchDomainEventsAsync(this);

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers)
            // performed through the DbContext will be committed
            var result = await base.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;

            _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

            return _currentTransaction;
        }

        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction)
                throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                await SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AccountEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AccountTransactionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AccountTypeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DirectionTypeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FamilyEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InvestmentToolEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InvestmentToolPriceEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InvestmentToolTypeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StoreBranchEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StoreEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StoreTypeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionTypeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            
        }
    }
}
