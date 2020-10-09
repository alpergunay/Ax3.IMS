using System;
using AutoMapper;
using Ax3.IMS.DataAccess.EntityFramework;
using Ims.Domain.DomainModels;

namespace Ims.Infrastructure.Repositories
{
    public class AccountTypeRepository : GenericRepository<ImsContext, AccountType, Guid>, IAccountTypeRepository
    {
        public AccountTypeRepository(ImsContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
