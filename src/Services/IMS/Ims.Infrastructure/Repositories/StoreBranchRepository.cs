using Ax3.IMS.DataAccess.EntityFramework;
using Ims.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Ims.Infrastructure.Repositories
{
    public class StoreBranchRepository : GenericRepository<ImsContext, StoreBranch, Guid>, IStoreBranchRepository
    {
        public StoreBranchRepository(ImsContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
