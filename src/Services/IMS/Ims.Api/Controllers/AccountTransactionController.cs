﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Ims.Api.Application.Modules.Infrastructure.Commands;
using Ims.Api.Application.Modules.Infrastructure.Models.Account;
using Ims.Api.Application.Modules.Infrastructure.Queries;
using Ims.Api.Services;
using Ims.Domain.DomainModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ims.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountTransactionController : ImsControllerBase<AccountResponseModel, AccountTransaction>
    {
        private readonly IImsQueries _queries;
        private readonly IAccountTransactionRepository _accountTransactionRepository;
        private readonly IMapper _mapper;
        private readonly IIdentityService _identityService;
        private readonly IMediator _mediator;
        public AccountTransactionController(IImsQueries queries,
            IAccountTransactionRepository accountTransactionRepository,
            IMapper mapper,
            IIdentityService identityService,
            IMediator mediator) : base(accountTransactionRepository, mapper)
        {
            _queries = queries;
            _accountTransactionRepository = accountTransactionRepository;
            _mapper = mapper;
            _identityService = identityService;
            _mediator = mediator;
        }
        [Route("investment-tool-to-account")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<bool>> PutInvestmentToolToAccount([FromBody] PutInvestmentToolToAccountCommand transactionCommand)
        {
            return await _mediator.Send(transactionCommand);
        }
    }
}