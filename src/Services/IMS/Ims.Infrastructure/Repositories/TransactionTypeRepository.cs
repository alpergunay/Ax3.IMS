using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Ax3.IMS.DataAccess.EntityFramework;
using Ims.Domain.DomainModels;

namespace Ims.Infrastructure.Repositories
{
    public class TransactionTypeRepository : GenericRepository<ImsContext, TransactionType, Guid>, ITransactionTypeRepository
    {
        public TransactionTypeRepository(ImsContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
