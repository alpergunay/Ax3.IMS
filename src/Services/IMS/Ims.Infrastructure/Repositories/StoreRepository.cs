using AutoMapper;
using Ax3.IMS.DataAccess.EntityFramework;
using Ims.Domain.DomainModels;
using System;
using System.Threading.Tasks;
using Ax3.IMS.Domain;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Extensions;

namespace Ims.Infrastructure.Repositories
{
    public class StoreRepository : GenericRepository<ImsContext, Store, Guid>, IStoreRepository
    {
        public StoreRepository(ImsContext context, IMapper mapper) : base(context, mapper)
        {
            
        }

        public override async Task<Store> FindOrDefaultAsync(Guid entityId)
        {
            var store = await Context.Stores
                .Include(s=>s.StoreType)
                .FirstOrDefaultAsync(x => x.Id == entityId);
            return store;
        }
    }
}
