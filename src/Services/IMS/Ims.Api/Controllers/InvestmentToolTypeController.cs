using Ims.Api.Application.Modules.Infrastructure.Models.InvestmentToolType;
using Ims.Domain.DomainModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Ims.Api.Application.Modules.Infrastructure.Queries;

namespace Ims.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class InvestmentToolTypeController : ControllerBase
    {
        private readonly IImsQueries _queries;
        public InvestmentToolTypeController(IImsQueries queries)
        {
            _queries = queries;
        }
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(IEnumerable<InvestmentToolTypeResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<InvestmentToolTypeResponseModel>> GetInvestmentToolTypesAsync()
        {
            return await _queries.GetInvestmentToolTypesAsync();
        }
    }
}
