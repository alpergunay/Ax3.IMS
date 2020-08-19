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

        protected ImsContext(DbContextOptions<ImsContext> options, IUserService userService) : base(options,
            userService)
        {
        }

        protected ImsContext(DbContextOptions<ImsContext> options) : base(options)
        {
        }

        public ImsContext() : base(new DbContextOptionsBuilder<ImsContext>()
            .UseNpgsql("Server=localhost;Database=Test;Integrated Security=True;").Options)
        {
        }

        public ImsContext(DbContextOptions<ImsContext> options, IMediator mediator, IUserService service)
            : base(options, service)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
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

        }
    }
}
