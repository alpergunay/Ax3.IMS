using Ax3.IMS.DataAccess.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ax3.IMS.Domain;

namespace Ims.Domain.DomainModels
{
    public interface IStoreTypeRepository : IRepository<StoreType>
    {
        Task<ICollection<T>> GetAllAsync<T>() where T : class;
        Task<PagedResult<TD>> RetrievePagedResultAsync<TS, TD>(Expression<Func<TS, bool>> predicate,
            List<OrderBy> orderBy = null, Paging paging = null,
            params Expression<Func<TS, object>>[] includeExpressions) where TS : class;

    }
}
