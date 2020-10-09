using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Ims.Api.Application.Modules.Infrastructure.Models.AccountType;
using Ims.Api.Application.Modules.Infrastructure.Models.InvestmentToolType;
using Ims.Domain.DomainModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ims.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentToolTypeController : ControllerBase
    {
        private readonly IInvestmentToolTypeRepository _repository;
        public InvestmentToolTypeController(IInvestmentToolTypeRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [Route("investment-tool-types")]
        [ProducesResponseType(typeof(ICollection<InvestmentToolTypeResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<ICollection<InvestmentToolTypeResponseModel>> GetInvestmentToolTypesAsync()
        {
            return await _repository.GetAllAsync<InvestmentToolTypeResponseModel>();
        }
    }
}
