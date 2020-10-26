using Ims.Api.Application.Modules.Infrastructure.Models.StoreType;
using Ims.Domain.DomainModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Ims.Api.Application.Modules.Infrastructure.Queries;

namespace Ims.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IImsQueries _queries;
        public StoreController(IImsQueries queries)
        {
            _queries = queries;
        }
    }
}
