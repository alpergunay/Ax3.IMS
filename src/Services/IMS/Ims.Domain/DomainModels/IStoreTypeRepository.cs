using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ims.Domain.DomainModels
{
    public interface IStoreTypeRepository
    {
        Task<ICollection<StoreType>> GetAllAsync();
    }
}
