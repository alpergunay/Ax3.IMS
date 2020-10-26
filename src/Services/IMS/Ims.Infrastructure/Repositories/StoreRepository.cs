using AutoMapper;
using Ax3.IMS.DataAccess.EntityFramework;
using Ims.Domain.DomainModels;
using System;

namespace Ims.Infrastructure.Repositories
{
    public class StoreRepository : GenericRepository<ImsContext, Store, Guid>, IStoreRepository
    {
        public StoreRepository(ImsContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
