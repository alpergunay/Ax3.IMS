using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Ax3.IMS.Domain;
using Ax3.IMS.Domain.Types;
using Ims.Api.Application.Modules.Infrastructure.Models;
using Ims.Api.Application.Modules.Infrastructure.Models.Store;
using Ims.Api.Application.Modules.Infrastructure.Models.StoreBranch;
using Microsoft.AspNetCore.Mvc;

namespace Ims.Api.Controllers
{
    public class ImsControllerBase<T, TR> : ControllerBase 
        where T : BaseResponseModel 
        where TR : Entity
    {
        private readonly IRepository<TR> _repository;
        private readonly IMapper _mapper;
        public ImsControllerBase(IRepository<TR> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<T>> GetByIdAsync(string id)
        {
            if (!Guid.TryParse(id, out var entityId))
            {
                return BadRequest();
            }

            var storeBranch = await _repository.FindOrDefaultAsync(entityId);
            if (storeBranch != null)
            {
                return _mapper.Map<T>(storeBranch);
            }
            return NotFound();
        }
        
    }
}
