using AutoMapper;
using Ax3.IMS.DataAccess.Core;
using Ims.Api.Application.Modules.Infrastructure.Models.StoreType;
using Ims.Domain.DomainModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Ims.Api.Application.Modules.Infrastructure.Queries;

namespace Ims.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class StoreTypeController : ControllerBase
    {
        private readonly IStoreTypeRepository _storeTypeRepository;
        private readonly ILogger<StoreTypeController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IImsQueries _queries;

        public StoreTypeController(IStoreTypeRepository storeTypeRepository,
            ILogger<StoreTypeController> logger,
            IMediator mediator,
            IMapper mapper,
            IImsQueries queries)
        {
            _storeTypeRepository = storeTypeRepository;
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
            _queries = queries;
        }
        //TODO:Paging örneği için bırakılmıştır. Gerçek kullanım sonrasında kaldırılacaktır.
        [HttpPost]
        [ProducesResponseType(typeof(ICollection<StoreType>), (int)HttpStatusCode.OK)]
        public async Task<PagedResult<StoreTypeResponseModel>> GetStoreTypesAsync(Paging paging)
        {
            var rawResult = await _storeTypeRepository.RetrievePagedResultAsync<StoreType, StoreTypeResponseModel>(null, null,paging);
            return rawResult;
        }
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(IEnumerable<StoreTypeResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<StoreTypeResponseModel>> GetStoreTypesAsync()
        {
            return await _queries.GetStoreTypesAsync();
        }
        [HttpGet()]
        [Route("filter")]
        [ProducesResponseType(typeof(IEnumerable<StoreTypeResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<StoreTypeResponseModel>> FilterStoreTypesAsync([FromQuery] string typed)
        {
            return await _queries.FilterStoreTypesAsync(typed);
        }
        [HttpGet]
        [Route("list")]
        [ProducesResponseType(typeof(IEnumerable<StoreTypeResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<object>> GetStoreTypeListAsync(DataSourceLoadOptions loadOptions)
        {
            return await DataSourceLoader.LoadAsync(_storeTypeRepository.GetAllAsQueryable()
                .ProjectTo<StoreTypeResponseModel>(_mapper.ConfigurationProvider), loadOptions);
        }
    }
}
