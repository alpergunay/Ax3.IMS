using Ims.Api.Application.Modules.Infrastructure.Models.AccountType;
using Ims.Api.Application.Modules.Infrastructure.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Ims.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class AccountTypeController : ControllerBase
    {
        private readonly IImsQueries _queries;
        public AccountTypeController(IImsQueries queries)
        {
            _queries = queries;
        }
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(IEnumerable<AccountTypeResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<AccountTypeResponseModel>> GetAccountTypesAsync()
        {
            return await _queries.GetAccountTypesAsync();
        }
        [HttpGet()]
        [Route("filter")]
        [ProducesResponseType(typeof(IEnumerable<AccountTypeResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<AccountTypeResponseModel>> FilterAccountTypesAsync([FromQuery] string typed)
        {
            return await _queries.FilterAccountTypesAsync(typed);
        }
    }
}
