using AutoMapper;
using Ax3.IMS.Infrastructure.Core.Services;
using Ims.Api.Application.Modules.Infrastructure.Models.StoreBranch;
using Ims.Api.Application.Modules.Infrastructure.Queries;
using Ims.Domain.DomainModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Ims.Api.Application.Modules.Infrastructure.Models;
using Ims.Api.Application.Modules.Infrastructure.Models.Store;

namespace Ims.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StoreBranchController : ImsControllerBase<StoreBranchResponseModel, StoreBranch>
    {
        private readonly IImsQueries _queries;
        private readonly IStoreBranchRepository _storeBranchRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public StoreBranchController(IImsQueries queries,
            IStoreBranchRepository storeBranchRepository,
            IMapper mapper,
            IUserService userService) : base(storeBranchRepository, mapper)
        {
            _queries = queries;
            _storeBranchRepository = storeBranchRepository;
            _mapper = mapper;
            _userService = userService;
        }
        [Route("")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult> CreateStoreBranchAsync([FromBody] CreateStoreBranchRequestModel storeBranchModel)
        {
            if (!Guid.TryParse(storeBranchModel.StoreId, out var storeId))
            {
                return BadRequest();
            }
            var storeBranch = new StoreBranch(storeBranchModel.Name, storeId);
            _storeBranchRepository.Add(storeBranch);
            await _storeBranchRepository.UnitOfWork.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByIdAsync), new { id = storeBranch.Id }, null);
        }
        [Route("")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> UpdateStoreAsync([FromBody] UpdateStoreBranchRequestModel storeBranchModel)
        {
            if (!Guid.TryParse(storeBranchModel.Id, out var storeBranchId))
            {
                return BadRequest();
            }

            var storeBranch = await _storeBranchRepository.FindOrDefaultAsync(storeBranchId);

            if (storeBranch == null)
            {
                return NotFound(new { Message = $"Store with id {storeBranchModel.Id} not found." });
            }
            storeBranch.Update(storeBranchModel.Name, storeBranchModel.StoreId);
            _storeBranchRepository.Update(storeBranch);
            await _storeBranchRepository.UnitOfWork.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByIdAsync), new { id = storeBranch.Id }, null);
        }

        [HttpGet()]
        [Route("filter")]
        [ProducesResponseType(typeof(IEnumerable<StoreBranchResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<StoreBranchResponseModel>> FilterStoreBranchesAsync([FromQuery] BaseFilterRequestModel<string> queryString)
        {
            var filter = new BaseFilterRequestModel<Guid>
            {
                typed = queryString.typed,
                id = !Guid.TryParse(queryString.id, out var storeId) ? Guid.Empty : storeId
            };
            return await _queries.FilterStoreBranchesAsync<Guid>(filter);
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(IEnumerable<StoreBranchResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<StoreBranchResponseModel>> GetStoresAsync()
        {
            return await _queries.GetStoreBranchesAsync();
        }
        [HttpGet]
        [Route("list")]
        [ProducesResponseType(typeof(IEnumerable<StoreBranchResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<object>> GetStoreListAsync(DataSourceLoadOptions loadOptions)
        {
            return await DataSourceLoader.LoadAsync(_storeBranchRepository.GetAllAsQueryable()
                .ProjectTo<StoreBranchResponseModel>(_mapper.ConfigurationProvider), loadOptions);
        }

    }
}
