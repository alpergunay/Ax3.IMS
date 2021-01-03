using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Ax3.IMS.DataAccess.EntityFramework;
using Ims.Domain.DomainModels;

namespace Ims.Infrastructure.Repositories
{
    public class InvestmentToolPriceRepository : GenericRepository<ImsContext, InvestmentToolPrice, Guid>, IInvestmentToolPriceRepository
    {
        public InvestmentToolPriceRepository(ImsContext context, IMapper mapper) : base(context, mapper)
        {
            
        }
    }
}
