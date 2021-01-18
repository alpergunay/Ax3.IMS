using AutoMapper;
using Ax3.IMS.DataAccess.EntityFramework;
using Ims.Domain.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Ims.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<ImsContext, User, Guid>, IUserRepository
    {
        public UserRepository(ImsContext context, IMapper mapper) : base(context, mapper)
        {
            
        }

        public override Task<User> FindOrDefaultAsync(Guid entityId)
        {
            return Context.Users
                .Include(u => u.Country)
                .Include(u => u.LocalCurrency)
                .FirstOrDefaultAsync(u=>u.Id == entityId);
        }
    }
}
