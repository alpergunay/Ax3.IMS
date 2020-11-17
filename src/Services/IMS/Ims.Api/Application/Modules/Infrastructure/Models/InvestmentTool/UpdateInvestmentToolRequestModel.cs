using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ims.Api.Application.Modules.Infrastructure.Models.InvestmentTool
{
    public class UpdateInvestmentToolRequestModel
    {
        public string Id { get; set; }
        public int InvestmentToolTypeId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
