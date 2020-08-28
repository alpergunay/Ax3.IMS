using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ax3.IMS.DataAccess.Core;
using Ax3.IMS.DataAccess.EntityFramework;
using Ax3.IMS.Domain;
using Ims.Domain.DomainModels;

namespace Ims.Infrastructure.Repositories
{
    public class StoreTypeRepository : GenericRepository<ImsContext,StoreType,Guid>, IStoreTypeRepository
    {
        private ImsContext _context;
        public StoreTypeRepository(ImsContext context) : base(context)
        {
            _context = context;
        }
    }
}
