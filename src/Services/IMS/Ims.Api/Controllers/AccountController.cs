using AutoMapper;
using Ims.Api.Application.Modules.Infrastructure.Models.Account;
using Ims.Api.Application.Modules.Infrastructure.Queries;
using Ims.Api.Services;
using Ims.Domain.DomainModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Ims.Api.Application.Modules.Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;

namespace Ims.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ImsControllerBase<AccountResponseModel, Account>
    {
        private readonly IImsQueries _queries;
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly IIdentityService _identityService;

        public AccountController(IImsQueries queries,
            IAccountRepository accountRepository,
            IMapper mapper,
            IIdentityService identityService) : base(accountRepository, mapper)
        {
            _queries = queries;
            _accountRepository = accountRepository;
            _mapper = mapper;
            _identityService = identityService;
        }
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(IEnumerable<AccountResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<AccountResponseModel>> GetAccountsAsync()
        {
            return await _queries.GetAccountsAsync(Guid.Parse(_identityService.GetUserIdentity()));
        }

        [Route("")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> CreateAccountAsync([FromBody] CreateAccountRequestModel accountModel)
        {
            if (!Guid.TryParse(accountModel.StoreBranchId, out var storeBranchId))
            {
                return BadRequest();
            }
            if (!Guid.TryParse(accountModel.InvestmentToolId, out var investmentToolId))
            {
                return BadRequest();
            }

            var account = new Account(storeBranchId, accountModel.AccountTypeId, investmentToolId,
                accountModel.AccountNo, accountModel.AccountName);
            _accountRepository.Add(account);
            await _accountRepository.UnitOfWork.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByIdAsync), new { id = account.Id }, null);
        }

        [Route("")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> UpdateAccountAsync([FromBody] UpdateAccountRequestModel accountModel)
        {
            if (!Guid.TryParse(accountModel.Id, out var accountId))
            {
                return BadRequest();
            }

            var account = await _accountRepository.FindOrDefaultAsync(accountId);

            if (account == null)
            {
                return NotFound(new { Message = $"Store with id {accountModel.Id} not found." });
            }
            account.Update(accountModel.AccountNo, accountModel.AccountName);
            _accountRepository.Update(account);
            await _accountRepository.UnitOfWork.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByIdAsync), new { id = account.Id }, null);
        }

        [HttpGet()]
        [Route("filter")]
        [ProducesResponseType(typeof(IEnumerable<AccountResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<AccountLookupResponseModel>> FilterAccountsAsync([FromQuery] BaseFilterRequestModel<string> filter)
        {
            filter.id = _identityService.GetUserName();
            return await _queries.FilterAccountsAsync(filter);
        }

        [HttpGet]
        [Route("list")]
        [ProducesResponseType(typeof(IEnumerable<AccountResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<object>> GetStoreListAsync(DataSourceLoadOptions loadOptions)
        {
            return await DataSourceLoader.LoadAsync(_accountRepository.GetAllAsQueryable()
                .ProjectTo<AccountResponseModel>(_mapper.ConfigurationProvider), loadOptions);
        }
    }
}
