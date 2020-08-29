using Ax3.IMS.DataAccess.Core;
using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;


namespace Ax3.IMS.DataAccess.EntityFramework
{
    public static class Pagination
    {
        public static async Task<PagedResult<TD>> PaginateAsync<TS, TD>(this IQueryable<TS> collection, Paging query, IMapper mapper)
            => await collection.PaginateAsync<TS, TD>(mapper, query.Page, query.PageSize);

        public static async Task<PagedResult<TD>> PaginateAsync<TS, TD>(this IQueryable<TS> collection, IMapper mapper,
            int page = 1, int resultsPerPage = 10 )
        {
            if (page <= 0)
            {
                page = 1;
            }
            if (resultsPerPage <= 0)
            {
                resultsPerPage = 10;
            }
            var isEmpty = await collection.AnyAsync() == false;
            if (isEmpty)
            {
                return PagedResult<TD>.Empty;
            }
            var totalResults = await collection.CountAsync();
            var totalPages = (int)Math.Ceiling((decimal)totalResults / resultsPerPage);

            //TODO:Datayı burada project edip bu şekilde dönebilirsin....AutoMapper'ın ProjectTo methodu kullanılabilir.

            var data = await collection.Limit(page, resultsPerPage)
                .ProjectTo<TD>(mapper.ConfigurationProvider)
                .ToListAsync();

            return PagedResult<TD>.Create(data, page, resultsPerPage, totalPages, totalResults);
        }

        public static IQueryable<TS> Limit<TS>(this IQueryable<TS> collection, Paging query)
            => collection.Limit(query.Page, query.PageSize);

        public static IQueryable<TS> Limit<TS>(this IQueryable<TS> collection,
            int page = 1, int resultsPerPage = 10)
        {
            if (page <= 0)
            {
                page = 1;
            }
            if (resultsPerPage <= 0)
            {
                resultsPerPage = 10;
            }
            var skip = (page - 1) * resultsPerPage;
            var data = collection.Skip(skip)
                .Take(resultsPerPage);

            return data;
        }
    }
}
