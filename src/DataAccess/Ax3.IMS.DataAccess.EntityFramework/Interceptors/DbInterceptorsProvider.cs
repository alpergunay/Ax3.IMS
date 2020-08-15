using System.Collections.Generic;
using System.Linq;

namespace Ax3.IMS.DataAccess.EntityFramework.Interceptors
{
    public static class DbInterceptorsProvider
    {
        private static readonly object Sync = new object();

        private static IDbInterceptor[] interceptors = new IDbInterceptor[0];

        public static IEnumerable<IDbInterceptor> Get()
        {
            return interceptors;
        }

        public static void Add(IDbInterceptor interceptor)
        {
            lock (Sync)
            {
                interceptors = interceptors.Concat(new[] { interceptor }).ToArray();
            }
        }
    }
}