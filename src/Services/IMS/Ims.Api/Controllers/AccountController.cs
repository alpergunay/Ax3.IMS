using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Ims.Api.Application.Modules.Infrastructure.Models.Account;
using Ims.Api.Application.Modules.Infrastructure.Queries;
using Ims.Api.Services;
using Ims.Domain.DomainModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ims.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _repository;
        private readonly ILogger<AccountController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IImsQueries _queries;
        private readonly IIdentityService _identityService;

        public AccountController(IAccountRepository repository,
            ILogger<AccountController> logger,
            IMediator mediator,
            IMapper mapper,
            IImsQueries queries,
            IIdentityService identityService)
        {
            _repository = repository;
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
            _queries = queries;
            _identityService = identityService;
        }
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(IEnumerable<AccountResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<AccountResponseModel>> GetStoreTypesAsync()
        {
            return await _queries.GetAccountsAsync(Guid.Parse(_identityService.GetUserIdentity()));
        }
    }
}
