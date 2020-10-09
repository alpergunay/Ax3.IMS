using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Ims.Api.Application.Modules.Infrastructure.Models.DirectionType;
using Ims.Api.Application.Modules.Infrastructure.Models.TransactionType;
using Ims.Domain.DomainModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ims.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectionTypeController : ControllerBase
    {
        private readonly IDirectionTypeRepository _repository;
        public DirectionTypeController(IDirectionTypeRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [Route("direction-types")]
        [ProducesResponseType(typeof(ICollection<DirectionTypeResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<ICollection<DirectionTypeResponseModel>> GetDirectionTypesAsync()
        {
            return await _repository.GetAllAsync<DirectionTypeResponseModel>();
        }
    }
}
