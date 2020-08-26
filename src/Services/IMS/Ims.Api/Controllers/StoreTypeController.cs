using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
        public StoreTypeController(IStoreTypeRepository storeTypeRepository,
            ILogger<StoreTypeController> logger,
            IMediator mediator)
        {
            _storeTypeRepository = storeTypeRepository;
            _logger = logger;
            _mediator = mediator;
        }
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<StoreType>), (int)HttpStatusCode.OK)]
        public async Task<ICollection<StoreType>> GetStoreTypesAsync()
        {
            return await _storeTypeRepository.GetAllAsync();
        }
    }
}
