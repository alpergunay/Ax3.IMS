using Ims.Api.Application.Modules.Infrastructure.Models.AccountType;
using Ims.Domain.DomainModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Ims.Api.Controllers
{
    [Route("api/account-types")]
    [Authorize]
    [ApiController]
    public class AccountTypeController : ControllerBase
    {
        private readonly IAccountTypeRepository _repository;
        public AccountTypeController(IAccountTypeRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<AccountTypeResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<ICollection<AccountTypeResponseModel>> GetAccountTypesAsync()
        {
            return await _repository.GetAllAsync<AccountTypeResponseModel>();
        }
    }
}
