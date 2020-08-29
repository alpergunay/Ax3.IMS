using Ax3.IMS.DataAccess.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ims.Domain.DomainModels
{
    public interface IStoreTypeRepository
    {
        Task<ICollection<StoreType>> GetAllAsync();

        Task<PagedResult<TD>> RetrievePagedResultAsync<TS, TD>(Expression<Func<TS, bool>> predicate,
            List<OrderBy> orderBy = null, Paging paging = null,
            params Expression<Func<TS, object>>[] includeExpressions) where TS : class;
    }
}
