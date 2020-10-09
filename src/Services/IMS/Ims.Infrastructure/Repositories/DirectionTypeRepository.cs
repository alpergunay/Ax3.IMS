using AutoMapper;
using Ax3.IMS.DataAccess.EntityFramework;
using Ims.Domain.DomainModels;
using System;

namespace Ims.Infrastructure.Repositories
{
    public class DirectionTypeRepository : GenericRepository<ImsContext, DirectionType, Guid>, IDirectionTypeRepository
    {
        public DirectionTypeRepository(ImsContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
