using AutoMapper;
using Ax3.IMS.DataAccess.EntityFramework;
using Ims.Domain.DomainModels;
using System;

namespace Ims.Infrastructure.Repositories
{
    public class AccountTransactionRepository : GenericRepository<ImsContext, AccountTransaction, Guid>,
        IAccountTransactionRepository
    {
        public AccountTransactionRepository(ImsContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}