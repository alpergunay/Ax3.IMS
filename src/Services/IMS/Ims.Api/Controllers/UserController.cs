using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Ims.Api.Application.Modules.Infrastructure.Models.User;
using Ims.Domain.DomainModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ims.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ImsControllerBase<UserResponseModel, User>
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserController(ILogger<UserController> logger, IUserRepository userRepository, IMapper mapper) 
            : base(userRepository, mapper)
        {
            _logger = logger;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        [Route("")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> UpdateUserAsync([FromBody] UpdateUserRequestModel userModel)
        {
            if (!Guid.TryParse(userModel.Id, out var userId))
            {
                return BadRequest();
            }

            var user = await _userRepository.FindOrDefaultAsync(userId);

            if (user == null)
            {
                return NotFound(new { Message = $"User with id {userModel.Id} not found." });
            }
            user.SetUserInformation(userModel.CurrencyId, userModel.CountryId);
            _userRepository.Update(user);
            await _userRepository.UnitOfWork.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByIdAsync), new { id = user.Id.ToString()}, null);
        }
    }
}
