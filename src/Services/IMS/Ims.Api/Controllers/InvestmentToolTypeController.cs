using Ims.Api.Application.Modules.Infrastructure.Models.InvestmentToolType;
using Ims.Domain.DomainModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Ims.Api.Application.Modules.Infrastructure.Models;
using Ims.Api.Application.Modules.Infrastructure.Models.StoreType;
using Ims.Api.Application.Modules.Infrastructure.Queries;

namespace Ims.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class InvestmentToolTypeController : ControllerBase
    {
        private readonly IImsQueries _queries;
        private readonly IInvestmentToolTypeRepository _repository;
        private readonly IMapper _mapper;
        public InvestmentToolTypeController(IImsQueries queries,
            IInvestmentToolTypeRepository repository,
            IMapper mapper)
        {
            _queries = queries;
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(IEnumerable<InvestmentToolTypeResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<InvestmentToolTypeResponseModel>> GetInvestmentToolTypesAsync()
        {
            return await _queries.GetInvestmentToolTypesAsync();
        }

        [HttpGet]
        [Route("list")]
        [ProducesResponseType(typeof(IEnumerable<InvestmentToolTypeResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<object>> GetInvestmentToolTypeListAsync(DataSourceLoadOptions loadOptions)
        {
            return await DataSourceLoader.LoadAsync(_repository.GetAllAsQueryable()
                .ProjectTo<InvestmentToolTypeResponseModel>(_mapper.ConfigurationProvider), loadOptions);
        }

        [HttpGet()]
        [Route("filter")]
        [ProducesResponseType(typeof(IEnumerable<InvestmentToolTypeResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<InvestmentToolTypeResponseModel>> FilterInvestmentToolTypesAsync([FromQuery] string typed)
        {
            return await _queries.FilterInvestmentToolTypesAsync(typed);
        }
    }
}
