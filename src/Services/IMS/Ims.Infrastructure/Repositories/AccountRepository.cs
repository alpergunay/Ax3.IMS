using AutoMapper;
using Ax3.IMS.DataAccess.EntityFramework;
using Ims.Domain.DomainModels;
using System;

namespace Ims.Infrastructure.Repositories
{
    public class AccountRepository : GenericRepository<ImsContext, Account, Guid>, IAccountRepository
    {
        public AccountRepository(ImsContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
