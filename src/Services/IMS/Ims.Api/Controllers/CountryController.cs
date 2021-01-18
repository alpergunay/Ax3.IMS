using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Ims.Api.Application.Modules.Infrastructure.Models;
using Ims.Api.Application.Modules.Infrastructure.Queries;
using Microsoft.AspNetCore.Authorization;

namespace Ims.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CountryController : ControllerBase
    {
        private readonly IImsQueries _queries;
        public CountryController(IImsQueries queries)
        {
            _queries = queries;
        }
        [HttpGet()]
        [Route("filter")]
        [ProducesResponseType(typeof(IEnumerable<CountryResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<CountryResponseModel>> FilterStoresAsync([FromQuery] string typed)
        {
            return await _queries.FilterCountriesAsync(typed);
        }
    }
}
