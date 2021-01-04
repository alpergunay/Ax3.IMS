using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ax3.IMS.Infrastructure.Core.Services;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Ims.Api.Application.Modules.Infrastructure.Models;
using Ims.Api.Application.Modules.Infrastructure.Models.InvestmentTool;
using Ims.Api.Application.Modules.Infrastructure.Models.StoreBranch;
using Ims.Api.Application.Modules.Infrastructure.Queries;
using Ims.Domain.DomainModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ims.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InvestmentToolController : ImsControllerBase<InvestmentToolResponseModel, InvestmentTool>
    {
        private readonly IImsQueries _queries;
        private readonly IInvestmentToolRepository _investmentToolRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public InvestmentToolController(IImsQueries queries,
            IInvestmentToolRepository investmentToolRepository,
            IMapper mapper,
            IUserService userService) : base(investmentToolRepository, mapper)
        {
            _queries = queries;
            _investmentToolRepository = investmentToolRepository;
            _mapper = mapper;
            _userService = userService;
        }
        [Route("")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult> CreateInvestmentToolAsync([FromBody] CreateInvestmentToolRequestModel investmentToolModel)
        {
            var investmentTool = new InvestmentTool(investmentToolModel.Code, investmentToolModel.Name, investmentToolModel.Symbol,
                investmentToolModel.InvestmentToolTypeId, investmentToolModel.CountryId);
            _investmentToolRepository.Add(investmentTool);
            await _investmentToolRepository.UnitOfWork.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByIdAsync), new { id = investmentTool.Id }, null);
        }

        [Route("")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> UpdateInvestmentToolAsync([FromBody] UpdateInvestmentToolRequestModel investmentToolModel)
        {
            if (!Guid.TryParse(investmentToolModel.Id, out var investmentToolId))
            {
                return BadRequest();
            }

            var investmentTool = await _investmentToolRepository.FindOrDefaultAsync(investmentToolId);

            if (investmentTool == null)
            {
                return NotFound(new { Message = $"Investment Tool with id {investmentToolModel.Id} not found." });
            }
            investmentTool.Update(investmentToolModel.Code, investmentToolModel.Name);
            _investmentToolRepository.Update(investmentTool);
            await _investmentToolRepository.UnitOfWork.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByIdAsync), new { id = investmentTool.Id }, null);
        }
        [HttpGet()]
        [Route("filter")]
        [ProducesResponseType(typeof(IEnumerable<InvestmentToolResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<InvestmentToolResponseModel>> FilterInvestmentToolAsync([FromQuery] BaseFilterRequestModel<int> filter)
        {
            return await _queries.FilterInvestmentToolAsync<int>(filter);
        }
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(IEnumerable<InvestmentToolResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<InvestmentToolResponseModel>> GetInvestmentToolAsync()
        {
            return await _queries.GetInvestmentToolsAsync();
        }

        [HttpGet]
        [Route("list")]
        [ProducesResponseType(typeof(IEnumerable<InvestmentToolResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<object>> GetInvestmentToolListAsync(DataSourceLoadOptions loadOptions)
        {
            return await DataSourceLoader.LoadAsync(_investmentToolRepository.GetAllAsQueryable()
                .ProjectTo<InvestmentToolResponseModel>(_mapper.ConfigurationProvider), loadOptions);
        }
    }
}
