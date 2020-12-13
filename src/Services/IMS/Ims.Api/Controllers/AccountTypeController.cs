using System;
using System.Collections;
using Ims.Api.Application.Modules.Infrastructure.Models.AccountType;
using Ims.Api.Application.Modules.Infrastructure.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ims.Api.Application.Modules.Infrastructure.Models.Account;
using Ims.Api.Services;
using Ims.Domain.DomainModels;
using Ims.Domain.Dto;
using Microsoft.EntityFrameworkCore.Internal;

namespace Ims.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class AccountTypeController : ControllerBase
    {
        private readonly IImsQueries _queries;
        private readonly IAccountTypeRepository _repository;
        private readonly IMapper _mapper;
        private readonly IIdentityService _identityService;
        public AccountTypeController(IImsQueries queries, IAccountTypeRepository repository, IMapper mapper,
            IIdentityService identityService)
        {
            _queries = queries;
            _repository = repository;
            _mapper = mapper;
            _identityService = identityService;
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

        [HttpGet()]
        [Route("account-types-with-accounts")]
        [ProducesResponseType(typeof(IEnumerable<AccountTypeWithAccountsResponseModel>), (int)HttpStatusCode.OK)]
        public IEnumerable<AccountTypeWithAccountsResponseModel> GetAccountTypesWithAccountsAsync([FromQuery] string typed,
            string investmentToolId)
        {
            var accountDto = _repository.GetWithAccounts(_identityService.GetUserName(), typed, investmentToolId);

            var accountTypeGroup = accountDto.GroupBy(a => new { a.AccountTypeName, a.AccountTypeId })
                .Select(g => new AccountTypeWithAccountsResponseModel()
                {
                    AccountTypeName = g.Key.AccountTypeName,
                    Id = g.Key.AccountTypeId
                }).ToList();

            foreach (var g in accountTypeGroup)
            {
                g.Accounts = accountDto.Where(at => at.AccountTypeName == g.AccountTypeName)
                    .ProjectTo<AccountLookupResponseModel>(_mapper.ConfigurationProvider).ToList();
            }
            return accountTypeGroup;
        }
    }
}
