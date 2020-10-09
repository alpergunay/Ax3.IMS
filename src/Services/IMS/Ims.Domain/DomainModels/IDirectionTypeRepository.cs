using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ims.Domain.DomainModels
{
    public interface IDirectionTypeRepository
    {
        Task<ICollection<T>> GetAllAsync<T>() where T : class;
    }
}
