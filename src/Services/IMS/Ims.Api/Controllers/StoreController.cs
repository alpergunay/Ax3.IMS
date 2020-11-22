using AutoMapper;
using Ims.Api.Application.Modules.Infrastructure.Models.Store;
using Ims.Api.Application.Modules.Infrastructure.Queries;
using Ims.Domain.DomainModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Ax3.IMS.Infrastructure.Core.Services;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Ims.Api.Application.Modules.Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;

namespace Ims.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StoreController : ControllerBase
    {
        private readonly IImsQueries _queries;
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public StoreController(IImsQueries queries,
            IStoreRepository storeRepository,
            IMapper mapper,
            IUserService userService)
        {
            _queries = queries;
            _storeRepository = storeRepository;
            _mapper = mapper;
            _userService = userService;
        }
        [Route("")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult> CreateStoreAsync([FromBody] CreateStoreRequestModel storeModel)
        {
            var store = new Store(storeModel.Name, storeModel.StoreTypeId);
            _storeRepository.Add(store);
            await _storeRepository.UnitOfWork.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByIdAsync), new { id = store.Id }, null);
        }
        [Route("")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> UpdateStoreAsync([FromBody] UpdateStoreRequestModel storeModel)
        {
            if (!Guid.TryParse(storeModel.Id, out var storeId))
            {
                return BadRequest();
            }

            var store =await _storeRepository.FindOrDefaultAsync(storeId);

            if (store == null)
            {
                return NotFound(new { Message = $"Store with id {storeModel.Id} not found." });
            }
            store.Update(storeModel.Name, storeModel.StoreTypeId);
            _storeRepository.Update(store);
            await _storeRepository.UnitOfWork.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByIdAsync), new { id = store.Id }, null);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(StoreResponseModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<StoreResponseModel>> GetByIdAsync(string id)
        {
            if (!Guid.TryParse(id, out var storeId))
            {
                return BadRequest();
            }

            var store = await _storeRepository.FindOrDefaultAsync(storeId);
            if (store != null)
            {
                return _mapper.Map<StoreResponseModel>(store);
            }
            return NotFound();
        }
        [HttpGet()]
        [Route("filter")]
        [ProducesResponseType(typeof(IEnumerable<StoreResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<StoreResponseModel>> FilterStoresAsync([FromQuery] BaseFilterRequestModel<int> filter)
        {
            return await _queries.FilterStoresAsync<int>(filter);
        }
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(IEnumerable<StoreResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<StoreResponseModel>> GetStoresAsync()
        {
            return await _queries.GetStoresAsync();
        }
        [HttpGet]
        [Route("list")]
        [ProducesResponseType(typeof(IEnumerable<StoreResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<object>> GetStoreListAsync(DataSourceLoadOptions loadOptions)
        {
            return await DataSourceLoader.LoadAsync(_storeRepository.GetAllAsQueryable()
                .ProjectTo<StoreResponseModel>(_mapper.ConfigurationProvider), loadOptions);
        }

    }
}
