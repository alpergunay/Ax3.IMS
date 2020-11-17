using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ax3.IMS.DataAccess.EntityFramework;
using Ims.Domain.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Ims.Infrastructure.Repositories
{
    public class InvestmentToolRepository : GenericRepository<ImsContext, InvestmentTool, Guid>, IInvestmentToolRepository
    {
        public InvestmentToolRepository(ImsContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override async Task<InvestmentTool> FindOrDefaultAsync(Guid entityId)
        {
            var store = await Context.InvestmentTools
                .Include(it => it.InvestmentToolType)
                .FirstOrDefaultAsync(x => x.Id == entityId);
            return store;
        }

    }
}
