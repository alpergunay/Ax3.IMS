using Ims.Api.Application.Modules.Infrastructure.Models.TransactionType;
using Ims.Domain.DomainModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Ims.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionTypeController : ControllerBase
    {
        private readonly ITransactionTypeRepository _repository;
        public TransactionTypeController(ITransactionTypeRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(ICollection<TransactionTypeResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<ICollection<TransactionTypeResponseModel>> GetTransactionTypesAsync()
        {
            return await _repository.GetAllAsync<TransactionTypeResponseModel>();
        }
    }
}
