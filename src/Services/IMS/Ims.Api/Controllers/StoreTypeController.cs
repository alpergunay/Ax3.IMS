using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Ax3.IMS.DataAccess.Core;
using Ims.Api.Application.Modules.Infrastructure.Models.StoreType;
using Ims.Domain.DomainModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ims.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreTypeController : ControllerBase
    {
        private readonly IStoreTypeRepository _storeTypeRepository;
        private readonly ILogger<StoreTypeController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public StoreTypeController(IStoreTypeRepository storeTypeRepository,
            ILogger<StoreTypeController> logger,
            IMediator mediator,
            IMapper mapper)
        {
            _storeTypeRepository = storeTypeRepository;
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost]
        [ProducesResponseType(typeof(ICollection<StoreType>), (int)HttpStatusCode.OK)]
        public async Task<PagedResult<StoreTypeResponseModel>> GetStoreTypesAsync(Paging paging)
        {
            var rawResult = await _storeTypeRepository.RetrievePagedResultAsync<StoreType, StoreTypeResponseModel>(null, null,paging);
            return rawResult;
        }
    }
}
