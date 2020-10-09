using AutoMapper;
using Ax3.IMS.DataAccess.EntityFramework;
using Ims.Domain.DomainModels;
using System;

namespace Ims.Infrastructure.Repositories
{
    public class InvestmentToolTypeRepository : GenericRepository<ImsContext, InvestmentToolType, Guid>, IInvestmentToolTypeRepository
    {
        public InvestmentToolTypeRepository(ImsContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
