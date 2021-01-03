using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ims.Api.Application.Modules.Infrastructure.Models.InvestmentTool
{
    public class InvestmentToolResponseModel : BaseResponseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int InvestmentToolTypeId { get; set; }
        public string InvestmentToolTypeName { get; set; }
        public Guid? CountryId { get; set; }
        public string CountryName { get; set; }
    }
}
