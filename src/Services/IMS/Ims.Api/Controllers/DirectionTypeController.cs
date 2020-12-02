using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Ims.Api.Application.Modules.Infrastructure.Models.DirectionType;
using Ims.Api.Application.Modules.Infrastructure.Models.TransactionType;
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
    public class DirectionTypeController : ControllerBase
    {
        private readonly IImsQueries _queries;
        public DirectionTypeController(IImsQueries queries)
        {
            _queries = queries;
        }
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(IEnumerable<DirectionTypeResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<DirectionTypeResponseModel>> GetDirectionTypesAsync()
        {
            return await _queries.GetDirectionTypesAsync();
        }
    }
}
