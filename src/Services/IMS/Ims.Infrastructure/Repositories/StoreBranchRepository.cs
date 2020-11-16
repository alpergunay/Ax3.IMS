using Ax3.IMS.DataAccess.EntityFramework;
using Ims.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ims.Infrastructure.Repositories
{
    public class StoreBranchRepository : GenericRepository<ImsContext, StoreBranch, Guid>, IStoreBranchRepository
    {
        public StoreBranchRepository(ImsContext context, IMapper mapper) : base(context, mapper)
        {

        }
        public override async Task<StoreBranch> FindOrDefaultAsync(Guid entityId)
        {
            var store = await Context.StoreBranches
                .Include(s => s.Store)
                .Include(st=>st.Store.StoreType)
                .FirstOrDefaultAsync(x => x.Id == entityId);
            return store;
        }
    }
}
