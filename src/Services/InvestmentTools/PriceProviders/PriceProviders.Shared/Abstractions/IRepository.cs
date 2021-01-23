using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriceProviders.Shared.Abstractions
{
    public interface IRepository<T> where T: IEntity
    {
        Task SaveAsync(T entity);
        Task<T> GetAsync(string entityId);
        Task<List<T>> GetAllAsync();
        Task<T> ScanWithKey(string nameOfKey, string key);
    }
}
