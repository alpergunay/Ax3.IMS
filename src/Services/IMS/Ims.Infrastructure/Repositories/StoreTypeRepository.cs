using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ax3.IMS.DataAccess.Core;
using Ax3.IMS.DataAccess.EntityFramework;
using Ax3.IMS.Domain;
using Ims.Domain.DomainModels;

namespace Ims.Infrastructure.Repositories
{
    public class StoreTypeRepository : GenericRepository<ImsContext,StoreType,Guid>, IStoreTypeRepository
    {
        public StoreTypeRepository(ImsContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
