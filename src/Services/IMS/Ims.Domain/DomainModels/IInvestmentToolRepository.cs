using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ax3.IMS.Domain;

namespace Ims.Domain.DomainModels
{
    public interface IInvestmentToolRepository : IRepository<InvestmentTool>
    {
        Task<InvestmentTool> FindByCodeAsync(string investmentToolCode);
    }
}
