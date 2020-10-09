using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ims.Domain.DomainModels
{
    public interface IInvestmentToolTypeRepository
    {
        Task<ICollection<T>> GetAllAsync<T>() where T : class;
    }
}
