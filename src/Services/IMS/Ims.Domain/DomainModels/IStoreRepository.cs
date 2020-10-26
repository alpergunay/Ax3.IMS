using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ims.Domain.DomainModels
{
    public interface IStoreRepository
    {
        Task<ICollection<T>> GetAllAsync<T>() where T : class;
        Store Add(Store entity);
        Store Delete(Store entity);
        void Update(Store entity);
    }
}
